Shader "Custom/WorldPosColorAlbedo" {
	Properties {

	}

	SubShader {
		Tags { "RenderType"="Opaque" }
		
		CGPROGRAM
		#pragma surface surf Lambert

		struct Input {
			float3 worldPos;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			o.Albedo = fixed4( abs(fmod(IN.worldPos.x, 1.0)), 1, 1, 1);
		}
		ENDCG
	}
	FallBack "Diffuse"
}