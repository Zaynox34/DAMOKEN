using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

/*[System.Serializable]
public class VolumetricLightScatteringSettings
{
    [Header("Proprieties")]
    [Range(0.1f,1f)]
    public float resolutionScale =0.5f;
    [Range(0.0f, 1.0f)]
    public float intensity = 0.5f;
    [Range(0.0f, 1.0f)]
    public float blurWidth = 0.5f;
}
public class CustomRenderPassFeature : ScriptableRendererFeature
{

    class LightScatteringPass : ScriptableRenderPass
    {
        // This method is called before executing the render pass.
        // It can be used to configure render targets and their clear state. Also to create temporary render target textures.
        // When empty this render pass will render to the active camera render target.
        // You should never call CommandBuffer.SetRenderTarget. Instead call <c>ConfigureTarget</c> and <c>ConfigureClear</c>.
        // The render pipeline will ensure target setup and clearing happens in a performant manner.
        private readonly RenderTargetHandle occluders = RenderTargetHandle.CameraTarget;
        private readonly float resolutionScale;
        private readonly float intensity;
        private readonly float blurWidth;
        private readonly Material occludersMaterial;
        public LightScatteringPass(VolumetricLightScatteringSettings settings)
        {
            occluders.Init("_OccludersMap");
            resolutionScale = settings.resolutionScale;
            intensity = settings.intensity;
            blurWidth = settings.blurWidth;
            occludersMaterial = new Material(Shader.Find("Unlit/UnlitColor"));

        }
        public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
        {
            // 1
            RenderTextureDescriptor cameraTextureDescriptor =
                renderingData.cameraData.cameraTargetDescriptor;

            // 2
            cameraTextureDescriptor.depthBufferBits = 0;

            // 3
            cameraTextureDescriptor.width = Mathf.RoundToInt(
                cameraTextureDescriptor.width * resolutionScale);
            cameraTextureDescriptor.height = Mathf.RoundToInt(
                cameraTextureDescriptor.height * resolutionScale);

            // 4
            cmd.GetTemporaryRT(occluders.id, cameraTextureDescriptor,
                FilterMode.Bilinear);

            // 5
            ConfigureTarget(occluders.Identifier());
        }

        // Here you can implement the rendering logic.
        // Use <c>ScriptableRenderContext</c> to issue drawing commands or execute command buffers
        // https://docs.unity3d.com/ScriptReference/Rendering.ScriptableRenderContext.html
        // You don't have to call ScriptableRenderContext.submit, the render pipeline will call it at specific points in the pipeline.
        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            // 1
            if (!occludersMaterial)
            {
                return;
            }

            // 2
            CommandBuffer cmd = CommandBufferPool.Get();

            // 3
            using (new ProfilingScope(cmd,
                new ProfilingSampler("CustomRenderPassFeature")))
            {
                context.ExecuteCommandBuffer(cmd);
                cmd.Clear();

                Camera camera = renderingData.cameraData.camera;
                context.DrawSkybox(camera);
                // TODO: 2
            }

            // 4
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }

        // Cleanup any allocated resources that were created during the execution of this render pass.
        public override void OnCameraCleanup(CommandBuffer cmd)
        {
        }
    }

    LightScatteringPass m_ScriptablePass;
    public VolumetricLightScatteringSettings settings = new VolumetricLightScatteringSettings();
    /// <inheritdoc/>
    public override void Create()
    {
        m_ScriptablePass = new LightScatteringPass(settings);
        m_ScriptablePass.renderPassEvent =
        RenderPassEvent.BeforeRenderingPostProcessing;

        // Configures where the render pass should be injected.
        m_ScriptablePass.renderPassEvent = RenderPassEvent.AfterRenderingOpaques;
    }

    // Here you can inject one or multiple render passes in the renderer.
    // This method is called when setting up the renderer once per-camera.
    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        renderer.EnqueuePass(m_ScriptablePass);
    }
}*/


