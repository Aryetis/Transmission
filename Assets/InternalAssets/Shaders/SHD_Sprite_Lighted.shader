Shader "Custom/Sprite (Lighted)" {

	Properties {

		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Cutoff ("Alpha cutoff", Range(0, 1)) = 0.5
	}

	SubShader {

		Tags { "RenderType"="Opaque" "Queue"="AlphaTest"}
		LOD 200

		Cull Off

		CGPROGRAM
		#pragma surface surf SimpleLambert fullforwardshadows alphatest:_Cutoff
		#pragma exclude_renderers flash
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutput o) {

			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}

		half4 LightingSimpleLambert (SurfaceOutput s, half3 lightDir, half atten) {

			half4 c;
			c.rgb = s.Albedo * _LightColor0.rgb * atten;
			c.a = s.Alpha;
			return c;
		}

		ENDCG
	}
	FallBack "Diffuse"
}
