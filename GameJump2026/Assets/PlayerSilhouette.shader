Shader "Custom/PlayerSilhouette"
{
    SubShader
    {
        Tags { "Queue"="Transparent" }

        Pass
        {
            // SOLO dibuja si está detrás de otra geometría
            ZTest Greater

            Cull Off
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

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
                float4 pos : SV_POSITION;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                return fixed4(0, 0, 0, 0.6);
            }

            ENDCG
        }
    }
}