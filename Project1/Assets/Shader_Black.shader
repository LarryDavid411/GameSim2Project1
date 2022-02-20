Shader "Unlit/Color"
{
   Properties
    {
        _ColorA ("ColorA", Color) = (1,1,1,1)
        _ColorB ("ColorB", Color) = (1,1,1,1)
        _Scale ("UV Scale", Float) = 1
        _Offset ("UV Offset", Float) = 0
        _ColorStart ("Color Start", Range(0,1)) = 0
        _ColorEnd("Color End", Range(0,1)) = 1
        _RandSet ("RandSet", Float) = 10
        _RedFade ("ColorRed", Color) = (0,0,0,0)
        

    }
    SubShader
    {
        Tags { 
           // "RenderType"="Opaque" 
            "RenderType"="Transparent" // Tag to inform the render pipeline of what type this is
            "Queue"="Transparent" // changes the render order
        }

        Pass
        {
            Cull Off
            ZWrite Off
            //Ztest LEqual
            Blend One One // Additive
            //Blend DstColor Zero // Multiipy
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            #define TAU 6.28318503718
            
            //sampler2D _MainTex;
            //float4 _MainTex_ST;
            float4 _ColorA;
            float4 _ColorB;
            float _ColorStart;
            float _ColorEnd;
            uniform float _TimeMod;
            uniform float _RandSet;
            uniform float _redFade;
            
            
            //float _Scale;
            //float _Offset;
            
            struct MeshData
            {
                float4 vertex : POSITION; // local space vertex position
                float3 normals : NORMAL; // local space normal direction
                // float4 tangent : TANGENT; // tangent direction (xzy) tangent sign(w)
                // float4 color : COLOR; // vertex color
                float4 uv0 : TEXCOORD0; // uv0 diffuse/normal map textures
                // float4 uv1 : TEXCOORD1; // uv1 coordinates lightmap coordinates
                // float4 uv2 : TEXCOORD2; // uv2 coordinates lightmap coordinates
                // float4 uv3 : TEXCOORD3; // uv3 coordinates lightmap coordinates
            };

            struct Interpolators
            {
                float4 vertex : SV_POSITION;
                float3 normal : TEXCOORD0;
                float2 uv : TEXCOORD1;
                
            };


            Interpolators vert (MeshData v)
            {
                Interpolators o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                //o.normal = _Color.rgb;
                o.normal = UnityObjectToWorldNormal(v.normals);
                //o.normal = mul((float3x3)unity_ObjectToWorld, v.normals);
                //o.uv = (v.uv0 + _Offset) *_Scale;
                o.uv = v.uv0;
                
                return o;
            }

            float InverseLerp( float a, float b, float v)
            {
                return (v-a)/(b-a);
            }
            
            fixed4 frag (Interpolators i) : SV_Target
            {
                float4 redFadeOutput = _ColorA + _redFade;
                return redFadeOutput;
                //return _Color;
                //return float4(i.normal, 1);
                //float4 outColor = lerp(_ColorA, _ColorB, i.uv.x);
                //return float4(i.uv, 0, 1);

                // float t = InverseLerp(_ColorStart, _ColorEnd, i.uv.x);
                // float t = saturate( InverseLerp(_ColorStart, _ColorEnd, i.uv.x) );
                // float xOffset = cos(i.uv.y * TAU * 8);
                // float t1 = cos(i.uv.x * 25+ xOffset * 21) ;
                // t1 *= i.uv.y;
                // float topBottomRemover = (abs(i.normal.y) < 0.999);
                // float waves = t1 * topBottomRemover;
                // // frac
                // //t = frac(t);
                // //return t1 * topBottomRemover;
                //  float4 gradient = lerp( _ColorA, _ColorB, t);
                // return  gradient;
                //return i.uv.x;
                
               // return outColor;
            }
            ENDCG
            }
        }
    
        
}
