using UnityEngine;

public class webcam : MonoBehaviour
{
    private WebCamTexture webCamTexture;

    void Start()
    {
        // 创建一个WebCamTexture实例
        webCamTexture = new WebCamTexture();

        // 将WebCamTexture赋给此物体的Renderer组件，以便在物体上显示视频流
        GetComponent<Renderer>().material.mainTexture = webCamTexture;

        // 开始捕获摄像头视频流
        webCamTexture.Play();
    }

    void OnDestroy()
    {
        // 停止捕获并释放资源
        webCamTexture.Stop();
    }
}
