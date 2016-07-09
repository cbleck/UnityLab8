Shader "Diplomado/Alpha"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_NormalTex("Textura de normales", 2D) = "bump"{}
		_TransVal("Transparencia",Range(0, 1)) = 0.5
	}
		SubShader
	{
		CGPROGRAM
		#pragma surface surf Lambert //alpha
		sampler2D _MainTex;
		sampler2D _NormalTex;
		float _TransVal;
		struct Input {
			float2 uv_MainTex;
			float2 uv_NormalTex;
		};
		void surf(Input IN, inout SurfaceOutput o) {
			half4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.r * _TransVal;
			float3 normalMap = UnpackNormal(tex2D(_NormalTex, IN.uv_NormalTex));
			o.Normal = normalMap.rgb;
		}
		ENDCG

	}
}
