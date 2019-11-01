// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Lda6lge/ToonFire/Simple"
{
	Properties
	{
		_MainTex("MainTex", 2D) = "white" {}
		_Color("Color", Color) = (1,0.5799189,0.1985294,1)
		_ColorOut("ColorOut", Color) = (1,0.4140974,0.1985294,1)
		_Emission("Emission", Float) = 1.6
		_Speed("Speed", Float) = 2
		_Noise1Tiling("Noise1Tiling", Vector) = (0,0,0,0)
		_Noise1Speed("Noise1Speed", Vector) = (0,0,0,0)
		_Noise2Tiling("Noise2Tiling", Vector) = (0,0,0,0)
		_Noise2Speed("Noise2Speed", Vector) = (0,0,0,0)
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		[Enum(UnityEngine.Rendering.CompareFunction)]_ZTest("ZTest", Float) = 4
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Custom"  "Queue" = "AlphaTest+0" "IsEmissive" = "true"  }
		Cull Off
		ZTest [_ZTest]
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Unlit keepalpha noshadow nolightmap  nodynlightmap nodirlightmap 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform float _ZTest;
		uniform float4 _ColorOut;
		uniform float4 _Color;
		uniform sampler2D _MainTex;
		uniform float4 _MainTex_ST;
		uniform float2 _Noise1Tiling;
		uniform float _Speed;
		uniform float2 _Noise1Speed;
		uniform float2 _Noise2Tiling;
		uniform float2 _Noise2Speed;
		uniform float _Emission;
		uniform float _Cutoff = 0.5;


		float3 mod2D289( float3 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float2 mod2D289( float2 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float3 permute( float3 x ) { return mod2D289( ( ( x * 34.0 ) + 1.0 ) * x ); }

		float snoise( float2 v )
		{
			const float4 C = float4( 0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439 );
			float2 i = floor( v + dot( v, C.yy ) );
			float2 x0 = v - i + dot( i, C.xx );
			float2 i1;
			i1 = ( x0.x > x0.y ) ? float2( 1.0, 0.0 ) : float2( 0.0, 1.0 );
			float4 x12 = x0.xyxy + C.xxzz;
			x12.xy -= i1;
			i = mod2D289( i );
			float3 p = permute( permute( i.y + float3( 0.0, i1.y, 1.0 ) ) + i.x + float3( 0.0, i1.x, 1.0 ) );
			float3 m = max( 0.5 - float3( dot( x0, x0 ), dot( x12.xy, x12.xy ), dot( x12.zw, x12.zw ) ), 0.0 );
			m = m * m;
			m = m * m;
			float3 x = 2.0 * frac( p * C.www ) - 1.0;
			float3 h = abs( x ) - 0.5;
			float3 ox = floor( x + 0.5 );
			float3 a0 = x - ox;
			m *= 1.79284291400159 - 0.85373472095314 * ( a0 * a0 + h * h );
			float3 g;
			g.x = a0.x * x0.x + h.x * x0.y;
			g.yz = a0.yz * x12.xz + h.yz * x12.yw;
			return 130.0 * dot( m, g );
		}


		inline half4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return half4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			float2 uv0_MainTex = i.uv_texcoord * _MainTex_ST.xy + _MainTex_ST.zw;
			float mulTime40 = _Time.y * _Speed;
			float2 panner37 = ( mulTime40 * _Noise1Speed + i.uv_texcoord);
			float2 uv_TexCoord46 = i.uv_texcoord * _Noise1Tiling + panner37;
			float simplePerlin2D44 = snoise( uv_TexCoord46 );
			float smoothstepResult50 = smoothstep( -3.0 , 1.0 , simplePerlin2D44);
			float2 panner38 = ( mulTime40 * _Noise2Speed + i.uv_texcoord);
			float2 uv_TexCoord48 = i.uv_texcoord * _Noise2Tiling + panner38;
			float simplePerlin2D47 = snoise( uv_TexCoord48 );
			float smoothstepResult51 = smoothstep( -2.0 , 5.0 , simplePerlin2D47);
			float clampResult32 = clamp( ( i.uv_texcoord.y * 2.0 ) , 0.0 , 2.0 );
			float2 appendResult18 = (float2(0.0 , ( ( smoothstepResult50 * smoothstepResult51 ) * clampResult32 )));
			float4 tex2DNode11 = tex2D( _MainTex, ( uv0_MainTex + appendResult18 ) );
			float4 lerpResult5 = lerp( _ColorOut , _Color , tex2DNode11.r);
			o.Emission = ( lerpResult5 * _Emission ).rgb;
			o.Alpha = 1;
			clip( saturate( ( tex2DNode11.r + tex2DNode11.g ) ) - _Cutoff );
		}

		ENDCG
	}
}
/*ASEBEGIN
Version=17000
66;246;1310;728;1689.153;273.3192;1.591447;True;False
Node;AmplifyShaderEditor.RangedFloatNode;41;-3811.957,207.0911;Float;False;Property;_Speed;Speed;4;0;Create;True;0;0;False;0;2;3;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;39;-3741.104,-27.60583;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleTimeNode;40;-3647.871,211.8641;Float;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;55;-3601.275,86.6079;Float;False;Property;_Noise2Speed;Noise2Speed;8;0;Create;True;0;0;False;0;0,0;0.3,-0.5;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.Vector2Node;54;-3612.974,-162.9921;Float;False;Property;_Noise1Speed;Noise1Speed;6;0;Create;True;0;0;False;0;0,0;-0.2,-0.3;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.PannerNode;38;-3366.498,221.4537;Float;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0.5,-0.3;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PannerNode;37;-3355.969,-13.19551;Float;False;3;0;FLOAT2;0,0;False;2;FLOAT2;-0.1,-0.3;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector2Node;56;-3378.778,-184.3825;Float;False;Property;_Noise1Tiling;Noise1Tiling;5;0;Create;True;0;0;False;0;0,0;5,5;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.Vector2Node;57;-3333.184,117.6915;Float;False;Property;_Noise2Tiling;Noise2Tiling;7;0;Create;True;0;0;False;0;0,0;2,2;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TextureCoordinatesNode;48;-3128.347,213.7482;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;3,3;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;46;-3144.355,-49.25508;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;11,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.NoiseGeneratorNode;47;-2860.946,197.0483;Float;True;Simplex2D;False;False;2;0;FLOAT2;100,100;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;44;-2868.755,-85.45514;Float;True;Simplex2D;False;False;2;0;FLOAT2;100,100;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;34;-2559.573,397.2535;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;50;-2626.724,-110.4733;Float;True;3;0;FLOAT;0;False;1;FLOAT;-3;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;33;-2303.211,393.3534;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;51;-2550.605,165.9135;Float;True;3;0;FLOAT;0;False;1;FLOAT;-2;False;2;FLOAT;5;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;26;-2219.687,-98.85191;Float;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ClampOpNode;32;-2140.968,375.1506;Float;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;24;-1923.182,92.34252;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;18;-1680.432,88.41473;Float;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;16;-1933.722,-257.4823;Float;True;0;20;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;14;-1509.991,1.514697;Float;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TexturePropertyNode;20;-1526.842,-267.2179;Float;True;Property;_MainTex;MainTex;0;0;Create;True;0;0;False;0;None;e0dfbe92d5ab2bb4d899f9159c554673;False;white;Auto;Texture2D;0;1;SAMPLER2D;0
Node;AmplifyShaderEditor.SamplerNode;11;-1285.609,-18.57595;Float;True;Property;_TextureSample1;Texture Sample 1;2;0;Create;True;0;0;False;0;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;13;-1154.109,-611.1343;Float;False;Property;_ColorOut;ColorOut;2;0;Create;True;0;0;False;0;1,0.4140974,0.1985294,1;1,0.6068966,0.2499999,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;12;-1150.709,-402.0341;Float;False;Property;_Color;Color;1;0;Create;True;0;0;False;0;1,0.5799189,0.1985294,1;0.9044118,0.8090175,0.5586073,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;5;-707.009,-276.7342;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;6;-694.6721,-33.51542;Float;False;Property;_Emission;Emission;3;0;Create;True;0;0;False;0;1.6;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;8;-747.5159,72.05225;Float;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;53;-369.6015,99.18637;Float;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;59;176.2113,38.09356;Float;False;Property;_ZTest;ZTest;10;1;[Enum];Create;True;0;1;UnityEngine.Rendering.CompareFunction;True;0;4;4;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;4;-398.0143,-106.7397;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;-106.7,-176.4;Float;False;True;2;Float;;0;0;Unlit;Lda6lge/ToonFire/Simple;False;False;False;False;False;False;True;True;True;False;False;False;False;False;False;False;False;False;False;False;False;Off;0;False;-1;0;True;59;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;False;0;True;Custom;;AlphaTest;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;True;58;255;False;-1;255;False;-1;5;False;-1;3;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;9;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;40;0;41;0
WireConnection;38;0;39;0
WireConnection;38;2;55;0
WireConnection;38;1;40;0
WireConnection;37;0;39;0
WireConnection;37;2;54;0
WireConnection;37;1;40;0
WireConnection;48;0;57;0
WireConnection;48;1;38;0
WireConnection;46;0;56;0
WireConnection;46;1;37;0
WireConnection;47;0;48;0
WireConnection;44;0;46;0
WireConnection;50;0;44;0
WireConnection;33;0;34;2
WireConnection;51;0;47;0
WireConnection;26;0;50;0
WireConnection;26;1;51;0
WireConnection;32;0;33;0
WireConnection;24;0;26;0
WireConnection;24;1;32;0
WireConnection;18;1;24;0
WireConnection;14;0;16;0
WireConnection;14;1;18;0
WireConnection;11;0;20;0
WireConnection;11;1;14;0
WireConnection;5;0;13;0
WireConnection;5;1;12;0
WireConnection;5;2;11;1
WireConnection;8;0;11;1
WireConnection;8;1;11;2
WireConnection;53;0;8;0
WireConnection;4;0;5;0
WireConnection;4;1;6;0
WireConnection;0;2;4;0
WireConnection;0;10;53;0
ASEEND*/
//CHKSM=860AD7BCF6F778B6E485FC3E27191E038B04BCD4