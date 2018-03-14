Shader "Custom/ColorCyclingAlbedo" {
	Properties {
		_Colour ("My Colour", Color) = (1,1,1,1)
		_CyclingSpeed ("Cycling Speed", float) = 1.5
	}

	SubShader {
		Tags { "RenderType"="Opaque" }
		
		CGPROGRAM
		#pragma surface surf Lambert

		struct Input {
			float2 color : COLOR;
		};

		fixed4 _Colour;
		float _CyclingSpeed;

		void surf (Input IN, inout SurfaceOutput o) {
			o.Albedo = fixed4(_SinTime.x * _CyclingSpeed,
			_SinTime.y * _CyclingSpeed,
			_SinTime.z * _CyclingSpeed,
			1);
		}
		ENDCG
	}
	FallBack "Diffuse"
}