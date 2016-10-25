// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/Unlit/UnlitDisplacementAlpha"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_MaskTex("Mask Texture", 2D) = "white" {}
		_DisplaceTex("Displacement Texture", 2D) = "white" {}
		_Magnitude("Magnitude", Range(0,0.1)) = 1
		_Speed("Speed", Range(0,20)) = 1
	}
	SubShader
	{
		Tags
		{
			"Queue" = "Transparent"
			"RenderType" = "Transparent"
		}

		Pass
		{
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};
			
			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float4 worldPos : COLOR;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			sampler2D _MaskTex;
			sampler2D _DisplaceTex;
			float _Magnitude;
			float _Speed;

			float4 frag (v2f i) : SV_Target
			{
				float4 col = tex2D(_MainTex, i.uv);
				float4 mask = tex2D(_MaskTex, i.uv.xy);
				if(mask.x > 0){
					float2 distuv = float2(i.uv.x + _Time.x * _Speed + i.worldPos.x * 0.3f, i.uv.y);

					float2 disp = tex2D(_DisplaceTex, distuv).xy;
					disp = ((disp * 2) - 1) * _Magnitude;
					disp.y = 0;

					col = tex2D(_MainTex, i.uv + disp);
				}
				return col;
			}
			ENDCG
		}
	}
}
