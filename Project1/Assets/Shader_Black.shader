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
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            
            //sampler2D _MainTex;
            //float4 _MainTex_ST;
            float4 _ColorA;
            float4 _ColorB;
            float _ColorStart;
            float _ColorEnd;
            
            //float _Scale;
            //float _Offset;
            
            struct MeshData
            {
                float4 vertex : POSITION;
                float3 normals : NORMAL;
                float4 uv0 : TEXCOORD0;
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
                //return _Color;
                //return float4(i.normal, 1);
                //float4 outColor = lerp(_ColorA, _ColorB, i.uv.x);
                //return float4(i.uv, 0, 1);

                // float t = InverseLerp(_ColorStart, _ColorEnd, i.uv.x);
                float t = saturate( InverseLerp(_ColorStart, _ColorEnd, i.uv.x) );

                // frac
                //t = frac(t);
                //return t;
                float4 outColor = lerp( _ColorA, _ColorB, t);
                //return i.uv.x;
                
                return outColor;
            }
            ENDCG
            }
        }
    
        
}
