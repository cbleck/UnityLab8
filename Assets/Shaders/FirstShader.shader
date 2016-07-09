Shader "Diplomado/FirstShader"
{
	Properties{
		_MainTex("Textura RGB", 2D) = "white"{}
		_Color("Color Base", Color) = (1,1,1,1)
	}

	Subshader{
			
		Tags{"Render Type"= "Opaque"}

		Pass{
			Material{
				Diffuse[_Color]
			}
			Lighting On
			SetTexture[_MainTex]{
				combine previous * texture
			}
		}
	}

	Fallback "Diffuse"
}