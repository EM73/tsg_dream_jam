Shader "Custom/ChromaKey" {
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _Transparent ("Transparent Color", Color) = (1,1,1,1)
        _Strength ("Strength", float) = 0.2
        
    }
    SubShader {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 200
        
        CGPROGRAM
        #pragma surface surf Lambert alpha
 
        sampler2D _MainTex;
        fixed4 _Transparent;
        float _Strength;
 
        struct Input {
            float2 uv_MainTex;
        };
 
        void surf (Input IN, inout SurfaceOutput o) {
            half4 c = tex2D (_MainTex, IN.uv_MainTex);
            fixed4 col = _Transparent;
            o.Albedo = c.rgb;
            
            if (length(abs(c.rgb - col.rgb)) < _Strength)
            {
                o.Alpha = 0.0;  
            }
            else
            {
                o.Alpha = c.a;
            }               
        }
        ENDCG
    } 
    FallBack "Diffuse"
}