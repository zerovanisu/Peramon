Shader "Unlit/PaperTurnMilkShader"
{
	Properties
	{
		//正面圖
		_MainTex ("Texture", 2D) = "white" {}
		//旋轉角度
        _Cutoff ("Alpha Cutoff", Range(0,1)) = 0.5
		_AngleX("AngleX", Range(0,180)) = 0
		_AngleX2("AngleX2", Range(0,180)) = 0
		_AngleY("AngleY", Range(0,180)) = 0
		_AngleY2("AngleY2", Range(0,180)) = 0
		//彎曲程度
		_WeightY("Weight Y", Range(0,5)) = 0.2
		//收縮程度（值越大翻頁時紙張越往內部靠攏)具體情況可測試
		_WeightX("Weight X", Range(-1,1)) = 0
		//波長（值越大翻頁時的彎曲次數越多）
		_WaveLength("WaveLength", Range(-2,2)) = 0.4
		_SizeX("SizeX", Range(1,5)) = 3
		_SizeY("SizeY", Range(1,5)) = 5

		_DisappearOffsetX ("Disappear OffsetX",Range(-15,15)) = 15
		_DisappearOffsetX2 ("Disappear OffsetX2",Range(-15,15)) = 15
		_DisappearOffsetY ("Disappear OffsetY",Range(-15,15)) = 15
		_DisappearOffsetY2 ("Disappear OffsetY2",Range(-15,15)) = 15
	}
	SubShader
	{
		//關閉批處理（因爲修改了頂點位置)
		Tags { "RenderType"="TransparentCutout" "IgnoreProjector" = "True" "Queue" = "Geometry" "DisableBatching" = "True"}
		LOD 100
		Blend SrcAlpha OneMinusSrcAlpha
		//渲染正面
		Pass
		{
			Cull Off
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
				float3 uv : TEXCOORD0;				
				float4 vertex : SV_POSITION;
				float3 worldPos:TEXCOORD2;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _AngleX;
			float _AngleX2;
			float _AngleY;
			float _AngleY2;
			float _WeightY;
			float _WeightX;
			float _WaveLength;
			float _SizeX;
			float _SizeY;
			float _DisappearOffsetX;
			float _DisappearOffsetX2;
			float _DisappearOffsetY;
			float _DisappearOffsetY2;
			
			v2f vert (appdata v)
			{
				v2f o;
				if(_AngleX > 0){
					//對頂點進行往X正方向偏移5個單位是爲了離開旋轉中心點,不然翻頁時的旋轉點是會在紙張中心進行圍繞Z軸旋轉（Z軸是紙張垂直線）
					v.vertex += _AngleX < 0 ? float4(-_SizeX, 0, 0, 0) : float4(_SizeX, 0, 0, 0);
					float s;
					float c;
					//使用sincos獲取 sin(弧度), cos(弧度)  ，radians(角度)=弧度 ,_AngleX前加負號是控制旋轉方向，可根據DX是右手法則順時針旋轉，故應該逆向翻頁要取負數
					sincos(radians(-_AngleX), s, c);
					//圍繞Z軸旋轉變換矩陣
					float4x4 rotate = {
						c,s,0,0,
						-s,c,0,0,
						0,0,1,0,
						0,0,0,1
					};
					//weight：_AngleX在[0,90]變換區間時，weight會從0變爲1；_AngleX在[90,180]變換區間時，weight會從1變爲0. 
					//weight可理解爲是剛開始翻頁（0°）到翻頁到垂直時（90°）時，對其彎曲程度從小變大；（這個是對頂點Y值影響的結果）
					//同理，收縮程度也是一樣道理
					float weight = 1 - abs(90 - _AngleX) / 90;
					v.vertex.y += sin(v.vertex.x * _WaveLength) * weight * _WeightY;
					v.vertex.x -= v.vertex.x * weight * _WeightX;
					//在進行偏移之後，再對頂點進行圍繞Z軸旋轉_AngleX角度
					v.vertex = mul(rotate, v.vertex);

					//之後要偏移回來，因爲我們已經做完了上面的旋轉操作了
					v.vertex -= _AngleX < 0 ? float4(-_SizeX, 0, 0, 0) : float4(_SizeX, 0, 0, 0);
	
				}	

				else if(_AngleX2 > 0){
					//對頂點進行往X正方向偏移5個單位是爲了離開旋轉中心點,不然翻頁時的旋轉點是會在紙張中心進行圍繞Z軸旋轉（Z軸是紙張垂直線）
					v.vertex += _AngleX2 < 0 ? float4(3, 0, 0, 0) : float4(-3, 0, 0, 0);
					float s;
					float c;
					//使用sincos獲取 sin(弧度), cos(弧度)  ，radians(角度)=弧度 ,_AngleX前加負號是控制旋轉方向，可根據DX是右手法則順時針旋轉，故應該逆向翻頁要取負數
					sincos(radians(_AngleX2), s, c);
					//圍繞Z軸旋轉變換矩陣
					float4x4 rotate = {
						c,s,0,0,
						-s,c,0,0,
						0,0,1,0,
						0,0,0,1
					};
					//weight：_AngleX在[0,90]變換區間時，weight會從0變爲1；_AngleX在[90,180]變換區間時，weight會從1變爲0. 
					//weight可理解爲是剛開始翻頁（0°）到翻頁到垂直時（90°）時，對其彎曲程度從小變大；（這個是對頂點Y值影響的結果）
					//同理，收縮程度也是一樣道理
					float weight = 1 - abs(90 - _AngleX2) / 90;
					v.vertex.y += sin(v.vertex.x * -_WaveLength) * weight * _WeightY;
					v.vertex.x -= v.vertex.x * weight * _WeightX;
					//在進行偏移之後，再對頂點進行圍繞Z軸旋轉_AngleX角度
					v.vertex = mul(rotate, v.vertex);

					//之後要偏移回來，因爲我們已經做完了上面的旋轉操作了
					v.vertex -= _AngleX2 < 0 ? float4(3, 0, 0, 0) : float4(-3, 0, 0, 0);
	
				}	
				
				if(_AngleY > 0){
					//對頂點進行往X正方向偏移5個單位是爲了離開旋轉中心點,不然翻頁時的旋轉點是會在紙張中心進行圍繞Z軸旋轉（Z軸是紙張垂直線）
					v.vertex += _AngleY < 0 ? float4(0, 0, -_SizeY, 0) : float4(0, 0, _SizeY, 0);
					float s;
					float c;
					//使用sincos獲取 sin(弧度), cos(弧度)  ，radians(角度)=弧度 ,_AngleX前加負號是控制旋轉方向，可根據DX是右手法則順時針旋轉，故應該逆向翻頁要取負數
					sincos(radians(-_AngleY), s, c);
					//圍繞X軸旋轉變換矩陣
                    float4x4 rotate = {
                        1,0,0,0,
                        0,c,-s,0,
                        0,s,c,0,
                        0,0,0,1
                    };
					//weight：_AngleX在[0,90]變換區間時，weight會從0變爲1；_AngleX在[90,180]變換區間時，weight會從1變爲0. 
					//weight可理解爲是剛開始翻頁（0°）到翻頁到垂直時（90°）時，對其彎曲程度從小變大；（這個是對頂點Y值影響的結果）
					//同理，收縮程度也是一樣道理
					float weight = 1 - abs(90 - _AngleY) / 90;
					v.vertex.y += sin(v.vertex.z * _WaveLength) * weight * _WeightY;
					v.vertex.z -= v.vertex.z * weight * _WeightX;
					//在進行偏移之後，再對頂點進行圍繞Z軸旋轉_AngleX角度
					v.vertex = mul(rotate, v.vertex);

					//之後要偏移回來，因爲我們已經做完了上面的旋轉操作了
					v.vertex -= _AngleY < 0 ? float4(0, 0, -_SizeY, 0) : float4(0, 0, _SizeY, 0);
	
				}	


				else if(_AngleY2 > 0){
					//對頂點進行往X正方向偏移5個單位是爲了離開旋轉中心點,不然翻頁時的旋轉點是會在紙張中心進行圍繞Z軸旋轉（Z軸是紙張垂直線）
					v.vertex += _AngleY2 < 0 ? float4(0, 0, _SizeY, 0) : float4(0, 0, -_SizeY, 0);
					float s;
					float c;
					//使用sincos獲取 sin(弧度), cos(弧度)  ，radians(角度)=弧度 ,_AngleX前加負號是控制旋轉方向，可根據DX是右手法則順時針旋轉，故應該逆向翻頁要取負數
					sincos(radians(_AngleY2), s, c);
					//圍繞X軸旋轉變換矩陣
                    float4x4 rotate = {
                        1,0,0,0,
                        0,c,-s,0,
                        0,s,c,0,
                        0,0,0,1
                    };
					//weight：_AngleX在[0,90]變換區間時，weight會從0變爲1；_AngleX在[90,180]變換區間時，weight會從1變爲0. 
					//weight可理解爲是剛開始翻頁（0°）到翻頁到垂直時（90°）時，對其彎曲程度從小變大；（這個是對頂點Y值影響的結果）
					//同理，收縮程度也是一樣道理
					float weight = 1 - abs(90 - _AngleY2) / 90;
					v.vertex.y += sin(v.vertex.z * -_WaveLength) * weight * _WeightY;
					v.vertex.z -= v.vertex.z * weight * _WeightX;
					//在進行偏移之後，再對頂點進行圍繞Z軸旋轉_AngleX角度
					v.vertex = mul(rotate, v.vertex);

					//之後要偏移回來，因爲我們已經做完了上面的旋轉操作了
					v.vertex -= _AngleY2 < 0 ? float4(0, 0, _SizeY, 0) : float4(0, 0, -_SizeY, 0);
	
				}	
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv.xy = TRANSFORM_TEX(v.uv, _MainTex);	

				if(_DisappearOffsetX != 15)
					o.uv.z = _DisappearOffsetX - v.vertex.x;
				else if(_DisappearOffsetY != 15)
					o.uv.z = _DisappearOffsetY - v.vertex.z;
				else if(_DisappearOffsetX2 != 15)
					o.uv.z = _DisappearOffsetX2 + v.vertex.x;
				else if(_DisappearOffsetY2 != 15)
					o.uv.z = _DisappearOffsetY2 + v.vertex.z;

					

				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{				
				fixed4 col = tex2D(_MainTex, i.uv);
				clip(i.uv.z);
		
				return col;
			}
			ENDCG
		}


		
	}
}