using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCameraControl : MonoBehaviour
{
    public RawImage rawImage;
    WebCamTexture webCamTexture;
    // Start is called before the first frame update
    void Start()
    {
        //camera texture
        webCamTexture = new WebCamTexture();
        rawImage.texture = webCamTexture;

        //set camera size
        webCamTexture.requestedHeight = 1280;
        webCamTexture.requestedWidth = 720;

        //show camera
        webCamTexture.Play();

        float scale;
        Vector2 size;
        if (webCamTexture.width > webCamTexture.height) {
            // 横長映像 横のサイズに合わせる
            size = rawImage.GetComponent<RectTransform>().sizeDelta;
            scale = size.x / webCamTexture.width;
            size.y = webCamTexture.height * scale;
            rawImage.GetComponent<RectTransform>().sizeDelta = size;
        } else {
            // 縦長映像 縦のサイズに合わせる
            size = rawImage.GetComponent<RectTransform>().sizeDelta;
            scale = size.y / webCamTexture.height;
            size.x = webCamTexture.width * scale;
            rawImage.GetComponent<RectTransform>().sizeDelta = size;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
