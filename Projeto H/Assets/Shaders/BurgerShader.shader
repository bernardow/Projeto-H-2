Shader "Unlit/BurgerShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _ColorSlider("ColorSlider", Range(0, 1)) = 0
        _Gloss("Gloss", Range(0,1)) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            Tags
            {
                "LightMode" = "UniversalForward"
            }
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fwdbase
            

            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"

            struct MeshData
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct Interpolators
            {
                float2 uv : TEXCOORD0;
                
                float4 vertex : SV_POSITION;
                float3 normals : TEXCOORD3;
                float3 wPos : TEXCOORD2;
                SHADOW_COORDS(2)
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _ColorSlider;
            float _Gloss;
            
            Interpolators vert (MeshData v)
            {
                Interpolators o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.normals = UnityObjectToWorldNormal(v.normal);
                o.wPos = mul(unity_ObjectToWorld, v.vertex);
                
                TRANSFER_SHADOW(o)
                return o;
            }

            float4 frag (Interpolators i) : SV_Target
            {
                //Diffuse Light
                float3 N = normalize(i.normals);
                float3 L = _WorldSpaceLightPos0;
                float3 V = normalize(_WorldSpaceCameraPos - i.wPos);
                float3 H = normalize(L + V);
                float3 lambert = dot(N,L);
                float3 diffuseLight = lambert * _LightColor0;

                //Specular Light
                float3 specularExponent = saturate(dot(H,N)) * (lambert > 0);
                _Gloss = exp2(_Gloss * 20);
                specularExponent = saturate(pow(specularExponent, _Gloss) );
                
                float shadow = SHADOW_ATTENUATION(i);
                // sample the texture
                float4 col = tex2D(_MainTex, float2(_ColorSlider, i.uv.y));
               
                return float4(col * (diffuseLight + specularExponent + shadow), 1);
            }
            ENDCG
        }
        UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
    }
}
