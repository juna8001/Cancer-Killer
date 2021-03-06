Shader "TSF/BaseOutline1"
{
    Properties 
    {

		[MaterialToggle(_TEX_ON)] _DetailTex ("Enable Detail texture", Float) = 0 	//1
		_MainTex ("Detail", 2D) = "white" {}        								//2
		_ToonShade ("Shade", 2D) = "white" {}  										//3
		[MaterialToggle(_COLOR_ON)] _TintColor ("Enable Color Tint", Float) = 0 	//4
		_Color ("Base Color", Color) = (1,1,1,1)									//5	
		[MaterialToggle(_VCOLOR_ON)] _VertexColor ("Enable Vertex Color", Float) = 0//6        
		_Brightness ("Brightness 1 = neutral", Float) = 1.0							//7	
		_OutlineColor ("Outline Color", Color) = (0.5,0.5,0.5,1.0)					//10
		_Outline ("Outline width", Float) = 0.01									//11

    }
 
    SubShader
    {
        Tags { "RenderType"="Opaque" "LightMode" = "ForwardBase"}
		LOD 250 
        Lighting Off
        Fog { Mode Off }
        
        UsePass "TSF/Base1/BASE"
        	
        Pass
        {
            Cull Front
            ZWrite On
            CGPROGRAM
			#include "UnityCG.cginc"
			#pragma fragmentoption ARB_precision_hint_fastest
			#pragma glsl_no_auto_normalization
            #pragma vertex vert
 			#pragma fragment frag
			#pragma multi_compile_fog
			#pragma multi_compile_fwdbase
			//#include "AutoLight.cginc"
			#include "UnityLightingCommon.cginc"
			
            struct appdata_t 
            {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct v2f 
			{
				float4 pos : SV_POSITION;
				UNITY_FOG_COORDS(1)
				fixed4 diff : COLOR1;
				
			};

            fixed _Outline;

            v2f vert (appdata_t v) 
            {
                v2f o;
			    o.pos = v.vertex;
			    o.pos.xyz += normalize(v.normal.xyz) *_Outline*0.01;
			    o.pos = mul(UNITY_MATRIX_MVP, o.pos);
				
				half3 worldNormal = UnityObjectToWorldNormal(v.normal);
				half nl = max(0, dot(worldNormal, _WorldSpaceLightPos0.xyz));
				o.diff = nl * _LightColor0;
				
				UNITY_TRANSFER_FOG(o, o.pos);
				
			    return o;
            }
            
            fixed4 _OutlineColor;
            
            fixed4 frag(v2f i) :COLOR 
			{ 
				fixed4 c = _OutlineColor;
				UNITY_APPLY_FOG(i.fogCoord, c);
				
				
				c *= i.diff;
			
		    	return c;
			}
            
            ENDCG
        }
    }
	Fallback "VertexLit"
}