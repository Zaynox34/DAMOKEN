Shader "Unlit/NewUnlitShader"
{
    Properties
    {
        
    }
    Subshader
    {
       UsePass "VertexLit/SHADOWCOLLECTOR"
       UsePass "VertexLit/SHADOWCASTER"
    }

        Fallback off
}
