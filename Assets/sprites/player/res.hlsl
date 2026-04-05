#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

void GetDisplayResolution_float(out float2 Resolution)
{
    Resolution = _ScreenSize.xy;
}