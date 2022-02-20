Shader "Unlit/Shader_Fog"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _ColorA ("ColorA", Color) = (1,1,1,1)
        _ColorB ("ColorB", Color) = (1,1,1,1)
        _Offset ("UV Offset", Range(0,1)) = 1
        _RandSet ("RandSet", Float) = 10
        
        
    }
    SubShader
    {
        Tags { 
            //"RenderType"="Opaque" 
            "RenderType" = "Transparent"
            "Queue" = "Transparent"
        }
        
        Pass
        {
            Cull Off
            ZWrite Off
            Blend One One
            
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            
            #include "UnityCG.cginc"

            #define TAU 6.28318503718
            float _randSet;  
            float4 _Color;
            float4 _ColorA;
            float4 _ColorB;
            float _Offset;
            uniform float _RandSet;
            
            struct MeshData
            {
                float4 vertex : POSITION;
                float3 normals : NORMAL;
                float2 uv0 : TEXCOORD0;
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
                o.normal = UnityObjectToWorldNormal(v.normals);
                o.uv = v.uv0;
                //o.uv = (v.uv0 + _Offset);
                return o;
            }

            fixed4 frag (Interpolators i) : SV_Target
            {
                // float2 uvCenter = i.uv * 2 - 1;
                // float3 radialCircle = 1 - ( length( uvCenter)  );
                // float3 colorChange = radialCircle - _Color;
                // radialCircle.x -= 0.01f;
                // return float4 (radialCircle, 1);

                //float yOffset = cos(i.uv.y * TAU* 4 + _Time.y)  ;
                float xOffset = cos(i.uv.x +_Time.y *  2 * _RandSet) ;
                float yOffset = cos(i.uv.y + _Time.y *  2 * _RandSet);
                float2 uvCenter = i.uv * 2 - 1;
               uvCenter.x *= xOffset;
                uvCenter.y *= yOffset;
                float3 radialCircle = 1 - ( length( uvCenter)  );

                //return xOffset * yOffset / 0.1;

                return float4 (radialCircle.xxx, 1);
                //return float4 (colorChange.xx,colorChange.z - 0.1f, 1);
                // float offset = 0.5f;
                // return float4(i.uv + offset, 0, 1);
                
                // sample the texture
               // float t = cos(i.uv.x * 25);
                //float4 outColor = lerp(_ColorA, _ColorB, i.uv.x);
                //float4 gradient = lerp( _ColorA, _ColorB, t);
                //return  gradient;
                //return outColor;
               // return i .uv.x;
            }
            ENDCG
        }
    }
}
