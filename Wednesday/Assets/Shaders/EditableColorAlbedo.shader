Shader "Custom/EditableColorAlbedo" {
	Properties {
		_Colour ("My Colour", Color) = (1,1,1,1)
	}

	SubShader {
		Tags { "RenderType"="Opaque" }
		
		CGPROGRAM
		#pragma surface surf Lambert

		struct Input {
			float2 color : COLOR;
		};

		fixed4 _Colour;

		void surf (Input IN, inout SurfaceOutput o) {
			o.Albedo = _Colour;
		}
		ENDCG
	}
	FallBack "Diffuse"
}