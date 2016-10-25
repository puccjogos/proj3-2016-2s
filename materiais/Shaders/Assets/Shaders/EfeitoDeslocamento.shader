Shader "Exemplos/EfeitoDeslocamento"
{
	Properties
	{
		_MainTex ("Textura", 2D) = "white" {}
		_Deslocamento("Textura de deslocamento", 2D) = "white" {}
		_Magnitude("Magnitude", Range(0, 0.1)) = 1
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
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
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			sampler _Deslocamento;
			float _Magnitude;

			fixed4 frag (v2f i) : SV_Target
			{
				float2 desl = tex2D(_Deslocamento, i.uv * _Time.y).xy;
				desl = ((desl * 2) -1) * _Magnitude;

				fixed4 col = tex2D(_MainTex, i.uv + desl);
				return col;
			}
			ENDCG
		}
	}
}
