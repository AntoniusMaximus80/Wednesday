Shader "Custom/FixedColorAlbedo" {
	Properties {
	}

	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert
		#pragma target 3.0

		struct Input {
			float2 color : COLOR;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			o.Albedo = fixed4(0,1,0,1);
		}
		ENDCG
	}
	FallBack "Diffuse"
}