Shader "Diplomado/CGDiffuse"
{
	Properties
	{
		_MainTex ("Textura Base", 2D) = "white" {}
		_color ("Color", Color) = (1,1,1,1)
	}
		SubShader
	{
		Tags { "RenderType" = "Opaque" }
		CGPROGRAM
		#pragma surface surf Lambert
		sampler2D _MainTex;
		float4 _color;

		struct Input {
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutput o) {
			half4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb *_color.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}

	Fallback "Diffuse"
}
