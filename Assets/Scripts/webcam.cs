using UnityEngine;

public class webcam : MonoBehaviour
{
    private WebCamTexture webCamTexture;

    void Start()
    {
        // ����һ��WebCamTextureʵ��
        webCamTexture = new WebCamTexture();

        // ��WebCamTexture�����������Renderer������Ա�����������ʾ��Ƶ��
        GetComponent<Renderer>().material.mainTexture = webCamTexture;

        // ��ʼ��������ͷ��Ƶ��
        webCamTexture.Play();
    }

    void OnDestroy()
    {
        // ֹͣ�����ͷ���Դ
        webCamTexture.Stop();
    }
}
