Shader "Custom/Water" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_BlendColor ("BlendColor", Color) = (1,1,1,1)
		_Softness ("Softness", Range(0.01, 3.0)) = 1.01
		_FadeLimit ("FadeLimit", Range(0.0, 1.0)) = 0.3
		_WaveSpeed ("WaveSpeed", Range(0.0, 4.0)) = 1
		_WaveAmplitude ("WaveAmplitude", Range(0.0, 4.0)) = 1
		_WaveOffset ("WaveOffset", Range(0.0, 4.0)) = 1
		_MainTex("Texture", 2D) = "white" {}
	}

	SubShader {
		Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Standard vertex:vert alpha:fade nolightmap
		#pragma target 3.0

		struct Input {
			float2 uv_MainTex;
			float4 screenPos;
			float eyeDepth;
		};

		sampler2D_float _CameraDepthTexture;
		fixed4 _Color;
		fixed4 _BlendColor;
		float _FadeLimit;
		float _Softness;
		float _WaveSpeed;
		float _WaveAmplitude;
		float _WaveOffset;
		sampler2D _MainTex;

		void vert(inout appdata_full v, out Input o) {
			UNITY_INITIALIZE_OUTPUT(Input, o);
			COMPUTE_EYEDEPTH(o.eyeDepth);

			float3 v0 = mul(unity_ObjectToWorld, v.vertex).xyz;
			float phase1 = 0.1 * sin((_Time.y * _WaveSpeed) + (v0.x * _WaveOffset) + (v0.z * _WaveOffset));
			float phase2 = 0.1 * cos((_Time.y * _WaveSpeed) + (v0.x * _WaveOffset) + (v0.z * _WaveOffset));

			v.vertex.y = v.vertex.y + (phase1 + phase2) * _WaveAmplitude;
			v.vertex.x = v.vertex.x + phase2 * _WaveAmplitude;
			v.vertex.z = v.vertex.z - phase2 * _WaveAmplitude;
		}

		void surf (Input IN, inout SurfaceOutputStandard o) {
			o.Albedo = _Color.rgb;
			o.Alpha = 0.7;
			o.Metallic = 0;
			o.Smoothness = 0;

			float rawZ = SAMPLE_DEPTH_TEXTURE_PROJ(_CameraDepthTexture, UNITY_PROJ_COORD(IN.screenPos));
			float sceneZ = LinearEyeDepth(rawZ);
			float partZ = IN.eyeDepth;

			float fade = 1.0;
			if (rawZ > 0.0) {
				fade = saturate(_Softness * (sceneZ - partZ));
			}

			if (fade < _FadeLimit) {
				o.Albedo = _Color.rgb * fade + _BlendColor * (1 - fade);
			}
		}
		ENDCG
	}
	FallBack "Diffuse"
}
