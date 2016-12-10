Shader "Sprites/Bilboard"
{
	Properties
	{
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Tint", Color) = (1,1,1,1)
		[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
		_ScaleX ("Scale X", Float) = 1.0
		_ScaleY ("Scale Y", Float) = 1.0
	}

	SubShader
	{
		Tags
		{ 
			"Queue"="Transparent" 
			"IgnoreProjector"="True" 
			"RenderType"="Transparent" 
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
			"LightMode" = "ForwardBase"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Blend One OneMinusSrcAlpha

		Pass
		{
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 2.0
			#pragma multi_compile _ PIXELSNAP_ON
			#pragma multi_compile _ ETC1_EXTERNAL_ALPHA
			#include "UnityCG.cginc"
			#pragma multi_compile_fog
			#pragma multi_compile_fwdbase
			#include "AutoLight.cginc"
			
			struct appdata_t
			{
				float4 vertex   : POSITION;
				float3 normal   : NORMAL; 
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				fixed4 color    : COLOR;
				float2 texcoord  : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				LIGHTING_COORDS(2,3)
			};
			
			fixed4 _Color;
			float _ScaleX;
			float _ScaleY;

			v2f vert(appdata_t IN)
			{
				v2f OUT;
				
				OUT.vertex = mul(UNITY_MATRIX_P, 
				mul(UNITY_MATRIX_MV, float4(0.0, 0.0, 0.0, 1.0)) + float4(IN.vertex.x, IN.vertex.y, -IN.vertex.z, 0.0) * float4(_ScaleX, _ScaleY, 1.0, 1.0));
				
				OUT.texcoord = IN.texcoord;
				OUT.color = _Color;
				#ifdef PIXELSNAP_ON
				OUT.vertex = UnityPixelSnap (OUT.vertex);
				#endif
				
				UNITY_TRANSFER_FOG(OUT, OUT.vertex);
				
				TRANSFER_VERTEX_TO_FRAGMENT(OUT);
				
				return OUT;
			}

			sampler2D _MainTex;
			sampler2D _AlphaTex;

			fixed4 SampleSpriteTexture (float2 uv)
			{
				fixed4 color = tex2D (_MainTex, uv);

				#if ETC1_EXTERNAL_ALPHA
				// get the color from an external texture (usecase: Alpha support for ETC1 on android)
				color.a = tex2D (_AlphaTex, uv).r;
				#endif //ETC1_EXTERNAL_ALPHA

				return color;
			}

			fixed4 frag(v2f IN) : SV_Target
			{
				fixed4 c = SampleSpriteTexture (IN.texcoord) * IN.color;
				c.rgb *= c.a;
				UNITY_APPLY_FOG(IN.fogCoord, c);
				
				return LIGHT_ATTENUATION(IN) * c;
				
				return c;
			}
		ENDCG
		
		}
		
	}
	Fallback "VertexLit"
}
