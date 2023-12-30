Shader "Hidden/HPSliderShader"
{
    Properties
    {

        _Texture("Texture", 2D) = "white"{}

        _LeftColor1("LeftColor1", Color) = (1,1,1,1)
        _LeftColor2("LeftColor2", Color) = (1,1,1,1)
        _LeftColor3("LeftColor3", Color) = (1,1,1,1)

        
        _RightColor1("RightColor1", Color) = (1,1,1,1)
        _RightColor2("RightColor2", Color) = (1,1,1,1)
        _RightColor3("RightColor3", Color) = (1,1,1,1)

        _Value("_Value", float) = 0
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Transparent"
            "Queue"="Geometry"
        }
        // No culling or depth
        //Cull Off ZWrite Off ZTest Always

        Cull Off

        Lighting Off

        Blend SrcAlpha OneMinusSrcAlpha

        ZTest [unity_GUIZTestMode]

        ZWrite Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 _LeftColor1;
            fixed4 _LeftColor2;
            fixed4 _LeftColor3;

            fixed4 _RightColor1;
            fixed4 _RightColor2;
            fixed4 _RightColor3;

            sampler2D _Texture;

            float _Value;

            float4 frag (v2f i) : SV_Target
            {
                fixed4 col1 = lerp(_LeftColor1, _LeftColor2, _Value / 0.5);
                fixed4 col2 = lerp(_RightColor1, _RightColor2, _Value / 0.5);

                if(_Value > 0.5f)
                {
                    col1 = lerp(_LeftColor2, _LeftColor3, (_Value - 0.5) / 0.5);
                    col2 = lerp(_RightColor2, _RightColor3, (_Value - 0.5) / 0.5);
                }

                fixed4 col = lerp(col1, col2, i.uv.x);

                fixed4 tex = tex2D(_Texture, i.uv);

                //col.a = tex.a;

                col.a = tex.a;

                return col; // float4(col.rgb, tex.a);
            }
            ENDCG
        }
    }
}
