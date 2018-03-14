Shader "Custom/CRT" {
    Properties {
        _MainTex("Base (RGB)", 2D) = "white" {}
        _Scanline("Scanline", Float) = 0.75
		_RedIntensity("RedIntensity", Float) = 1
		_GreenIntensity("GreenIntensity", Float) = 1
		_BlueIntensity("BlueIntensity", Float) = 1
		_Contrast("Contrast", Float) = 1
		_Brightness("Brightness", Float) = 0
    }
    SubShader {
        Pass {
            ZTest Always Cull Off ZWrite Off Fog { Mode off}
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma fragmentoption ARB_precision_hint_fastest
            #include "UnityCG.cginc"
            #pragma target 3.0
 
            struct uniforms
            {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
                float4 scr_pos  : TEXCOORD1;
            };
 
            sampler2D _MainTex;
            float _Scanline;
			float _RedIntensity;
			float _GreenIntensity;
			float _BlueIntensity;
			float _Contrast;
			float _Brightness;
 
            uniforms vert(appdata_img v) {
                uniforms o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = MultiplyUV(UNITY_MATRIX_TEXTURE0, v.texcoord);
                o.scr_pos = ComputeScreenPos(o.pos);
                return o;
            }
 
            half4 frag(uniforms i) : COLOR
            {
                float2 pixelpos = i.scr_pos.xy *_ScreenParams.xy / i.scr_pos.w;
                half4 color = tex2D(_MainTex, i.uv);   

				color += (_Brightness / 255);

				color -= color - _Contrast * (color - 1.0) * color * (color - 0.5);

			    int xRow = (int) pixelpos.x % 3.0;
				if (xRow == 0)
                                color *= float4(_RedIntensity, 0.5, 0.5, 1); 
				if (xRow == 1)
                                color *= float4(0.5, _GreenIntensity, 0.5, 1);
				if (xRow == 2)
                                color *= float4(0.5, 0.5, _BlueIntensity, 1);
                if ((int)pixelpos.y % 3.0 == 0)
                                color *= float4(_Scanline, _Scanline, _Scanline, 1); 

                return color;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
} 