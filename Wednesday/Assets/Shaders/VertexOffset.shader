Shader "Custom/VertexOffset" {
	Properties {
		_MainTex("Texture", 2D) = "white" {}
		_BumpMap("BumpMap", 2D) = "bump" {}
		_Metal("Metal", Float) = 1
		_Smooth("Smooth", Float) = 1
		_USpeed("USpeed", Float) = 1
		_VSpeed("VSpeed", Float) = 1
		_UVScale("UVScale", Float) = 1
		_Amount("Amount", Float) = -1.1
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows vertex:vert
		#pragma target 3.0

		struct Input {
			float2 uv_MainTex;
			float2 uv_BumpMap;
		};

		sampler2D _MainTex;
		sampler2D _BumpMap;

		float2 uv_MainTex;
		float2 uv_BumpMap;

		float _Metal;
		float _Smooth;
		float _USpeed;
		float _VSpeed;
		float _UVScale;
		float _Amount;

		void vert (inout appdata_full v) {
			v.vertex.xyz += v.normal * _Amount;
		}

		void surf (Input IN, inout SurfaceOutputStandard o) {
			float2 albedoOffset = (IN.uv_MainTex * _UVScale) + float2(_USpeed, _VSpeed) * _Time.y;
			float2 bumpOffset = (IN.uv_BumpMap * _UVScale) + float2(_USpeed, _VSpeed) * _Time.y;

			o.Albedo = tex2D(_MainTex, albedoOffset);
			o.Normal = tex2D(_BumpMap, bumpOffset);
			o.Metallic = _Metal;
			o.Smoothness = _Smooth;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
