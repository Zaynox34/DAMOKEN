using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections.Generic;

public class ScreenSpaceOutlines : ScriptableRendererFeature
{
    class CustomRenderPass : ScriptableRenderPass
    {
        // This method is called before executing the render pass.
        // It can be used to configure render targets and their clear state. Also to create temporary render target textures.
        // When empty this render pass will render to the active camera render target.
        // You should never call CommandBuffer.SetRenderTarget. Instead call <c>ConfigureTarget</c> and <c>ConfigureClear</c>.
        // The render pipeline will ensure target setup and clearing happens in a performant manner.
        public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
        {
        }

        // Here you can implement the rendering logic.
        // Use <c>ScriptableRenderContext</c> to issue drawing commands or execute command buffers
        // https://docs.unity3d.com/ScriptReference/Rendering.ScriptableRenderContext.html
        // You don't have to call ScriptableRenderContext.submit, the render pipeline will call it at specific points in the pipeline.
        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
        }

        // Cleanup any allocated resources that were created during the execution of this render pass.
        public override void OnCameraCleanup(CommandBuffer cmd)
        {
        }
    }
    [System.Serializable]
    private class ViewSpaceNormalsTextureSettings
    {
        [Header("Proprieties")]
        public RenderTextureFormat colorFormat;
        public int depthBufferBits;
        public Color backgroundColor;
        public FilterMode filterMode;
    }
    //CustomRenderPass m_ScriptablePass;

    private class ViewSpaceNormalTexturePass : ScriptableRenderPass
    {
        //ViewSpaceNOrmalsTexturePass variables
        private ViewSpaceNormalsTextureSettings normalsTextureSettings;
        private readonly List<ShaderTagId> shaderTagIdList;
        private readonly RenderTargetHandle normals;
        private readonly Material normalsMaterials;
        private FilteringSettings filteringSettings;
        public ViewSpaceNormalTexturePass(RenderPassEvent renderPassEvent,LayerMask outlinesLayerMask, ViewSpaceNormalsTextureSettings settings)
        {
            /*Debug.Log("1"+ settings);*/
            this.normalsTextureSettings = settings;
            normalsMaterials =new Material(Shader.Find("Shader Graphs/ViewSpaceNormalsShader"));
            
            shaderTagIdList = new List<ShaderTagId> {
                new ShaderTagId("UniversalForward"),
                new ShaderTagId("UniversalForwardOnly"),
                new ShaderTagId("LightweightForward"),
                new ShaderTagId("SRPDefaultunlit")
            };
            this.renderPassEvent = renderPassEvent;
            normals.Init("_SceneViewSpaceNormals");
            filteringSettings = new FilteringSettings(RenderQueueRange.opaque, outlinesLayerMask);
            
        }
        public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
        {
            RenderTextureDescriptor normalsTextureDescriptor = cameraTextureDescriptor;
            //Debug.Log(normalsTextureSettings);
            normalsTextureDescriptor.colorFormat = normalsTextureSettings.colorFormat;
            normalsTextureDescriptor.depthBufferBits = normalsTextureSettings.depthBufferBits;
            cmd.GetTemporaryRT(normals.id, normalsTextureDescriptor,normalsTextureSettings.filterMode);
            ConfigureTarget(normals.Identifier());
            ConfigureClear(ClearFlag.All, normalsTextureSettings.backgroundColor);
        }
        public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
        {
        }

        
        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            
            if (!normalsMaterials)
            {
                Debug.Log("pas de normals");
                return;
            }
                
            CommandBuffer cmd = CommandBufferPool.Get();
            using(new ProfilingScope(cmd,new ProfilingSampler("SceneViewSpaceNormalsTextureCreation")))
            {
                context.ExecuteCommandBuffer(cmd);
                cmd.Clear();
                
                DrawingSettings drawSettings = CreateDrawingSettings(shaderTagIdList, ref renderingData, renderingData.cameraData.defaultOpaqueSortFlags);
                drawSettings.overrideMaterial = normalsMaterials;
                //FilteringSettings filteringSettings = FilteringSettings.defaultValue;
                context.DrawRenderers(renderingData.cullResults, ref drawSettings, ref filteringSettings);
                context.ExecuteCommandBuffer(cmd);
                CommandBufferPool.Release(cmd);
                //Debug.Log("aé");
            }
        }

        
        public override void OnCameraCleanup(CommandBuffer cmd)
        {
            cmd.ReleaseTemporaryRT(normals.id);
        }
    }
    private class ScreenSpaceOutlinesPass : ScriptableRenderPass
    {
        private readonly Material screenSpaceOutlineMaterial;
        private RenderTargetIdentifier cameraColorTarget;
        private RenderTargetIdentifier temporaryBuffer;
        private int temporaryBufferID = Shader.PropertyToID("_TemporaryBuffer");
        public ScreenSpaceOutlinesPass(RenderPassEvent renderPassEvent)
        {
            this.renderPassEvent = renderPassEvent;
            screenSpaceOutlineMaterial = new Material(Shader.Find("Shader Graphs/OutlineShader"));
        }
        public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
        {
            cameraColorTarget = renderingData.cameraData.renderer.cameraColorTarget;
        }

        
        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            
            if (!screenSpaceOutlineMaterial)
                Debug.Log("pas de outlines");
                return;

            CommandBuffer cmd = CommandBufferPool.Get();
            using (new ProfilingScope(cmd, new ProfilingSampler("ScreenSpaceOutlines")))
            {
                Blit(cmd, cameraColorTarget, cameraColorTarget,screenSpaceOutlineMaterial);
                Blit(cmd, temporaryBuffer, cameraColorTarget, screenSpaceOutlineMaterial);
                
            }
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }

       
        public override void OnCameraCleanup(CommandBuffer cmd)
        {
        }
    }
    /// ScreeenSpaceOutlineVariables
    [SerializeField] private RenderPassEvent renderPassEvent;
    private ViewSpaceNormalTexturePass viewSpaceNormalTexturePass;
    private ScreenSpaceOutlinesPass screenSpaceOutlinesPass;
    [SerializeField] private ViewSpaceNormalsTextureSettings viewSpaceNormalsTextureSettings;
    [SerializeField] private LayerMask outlinesLayerMask;
    public override void Create()
    {

        //m_ScriptablePass = new CustomRenderPass();

        // Configures where the render pass should be injected.
        //m_ScriptablePass.renderPassEvent = RenderPassEvent.AfterRenderingOpaques;

        viewSpaceNormalTexturePass = new ViewSpaceNormalTexturePass(renderPassEvent, outlinesLayerMask, viewSpaceNormalsTextureSettings);
       
        screenSpaceOutlinesPass = new ScreenSpaceOutlinesPass(renderPassEvent);
    }

    // Here you can inject one or multiple render passes in the renderer.
    // This method is called when setting up the renderer once per-camera.
    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        //renderer.EnqueuePass(m_ScriptablePass);
        
        renderer.EnqueuePass(viewSpaceNormalTexturePass);
        
        renderer.EnqueuePass(screenSpaceOutlinesPass);
        
    }
}


