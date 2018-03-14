Shader "Custom/AnimatedSurfaceAlbedo" {
	Properties {
		Colour ("My Colour", Colour)
		AnimationSpeed ("Animation Speed", float) = 1
	}

	SubShader {
		Tags { "RenderType"="Opaque" }
		
		CGPROGRAM
		#pragma surface surf Lambert

		struct Input {
			fixed4 worldPos;
		};

		float Colour;
		float AnimationSpeed;

		void surf (Input IN, inout SurfaceOutput o) {
			float multiplierX = _Time.y * TimeX;
			float multiplierY = _Time.y * TimeY;

			o.Albedo = fixed4(fmod(abs(IN.worldPos.x + multiplierX), 1.0),
							  fmod(abs(IN.worldPos.y + multiplierY), 1.0),
							  1,
							  1) * Colour;
		}
		ENDCG
	}
	FallBack "Diffuse"
}