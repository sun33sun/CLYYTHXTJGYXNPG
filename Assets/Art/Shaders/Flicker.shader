Shader "Unlit/Flicker"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Speed("Speed",Float) = 50
        _Color("Color",Color) = (1,1,1,1)
        _MinValue("MinValue",Range(0,1)) = 0.5
        _MaxValue("MaxValue",Range(0,1)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Speed;
            float4 _Color;
            float _MinValue;
            float _MaxValue;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float time = _Time.x * _Speed;
                float4 col = clamp(sin(time),_MinValue,_MaxValue) * _Color.rgba;
                return col;
            }
            ENDCG
        }
    }
}
