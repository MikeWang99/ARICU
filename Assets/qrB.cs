
using UnityEngine;
using System.Collections;
using ZXing;
using UnityEngine.UI;


public class qrB : MonoBehaviour
{

    /// <summary> ����RGBA </summary>
    public Color32[] data;
    /// <summary> �ж��Ƿ���Կ�ʼɨ�� </summary>
    private bool isScan;
    /// <summary> canvas�ϵ�RawImage����ʾ�����׽����ͼ�� </summary>
    public RawImage cameraTexture;
    /// <summary> canvas�ϵ�Text����ʾ��ȡ�Ķ�ά���ڲ���Ϣ </summary>
    public Text QRcodeText;
    /// <summary> �����׽����ͼ�� </summary>
    private WebCamTexture webCameraTexture;
    /// <summary> ZXing�еķ������ɶ�ȡ��ά���е����� </summary>
    private BarcodeReader barcodeReader;
    /// <summary> ��ʱ��0.5sɨ��һ�� </summary>
    private float timer = 0;

    /// <summary>
    /// ��ʼ��
    /// </summary>
    /// <returns></returns>
    void Start()
    {
        barcodeReader = new BarcodeReader();
        //yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);//������Ȩʹ������ͷ
        Application.RequestUserAuthorization(UserAuthorization.WebCam);//������Ȩʹ������ͷ

        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            WebCamDevice[] devices = WebCamTexture.devices;//��ȡ����ͷ�豸
            string devicename = devices[0].name;
            webCameraTexture = new WebCamTexture(devicename, 400, 300);//��ȡ����ͷ��׽���Ļ���
            cameraTexture.texture = webCameraTexture;
            webCameraTexture.Play();
            isScan = true;
        }

    }
    /// <summary>
    /// ѭ��ɨ�裬0.5��ɨ��һ��
    /// </summary>
    void Update()
    {
        if (isScan)
        {
            timer += Time.deltaTime;

            if (timer > 0.5f) //0.5��ɨ��һ��
            {
                StartCoroutine(ScanQRcode());//ɨ��
                timer = 0;
            }
        }
    }

    IEnumerator ScanQRcode()
    {
        data = webCameraTexture.GetPixels32();//�����׽��������
        DecodeQR(webCameraTexture.width, webCameraTexture.height);
        yield return 0;
    }

    /// <summary>
    /// ʶ���ά�벢��ʾ���а��������֡�URL����Ϣ
    /// </summary>
    /// <param name="width">�����׽��������Ŀ��</param>
    /// <param name="height">�����׽��������ĸ߶�</param>
    private void DecodeQR(int width, int height)
    {
        var br = barcodeReader.Decode(data, width, height);
        if (br != null)
        {
            QRcodeText.text = br.Text;
        }

    }

}

