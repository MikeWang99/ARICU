using UnityEngine;
using UnityEngine.UI; // ���ʹ��UI�ı�
using TMPro; // ���ʹ��TextMeshPro
using Microsoft.MixedReality.Toolkit.UI;

public class SliderValueDisplay : MonoBehaviour
{
    public PinchSlider pinchSlider; // ��PinchSlider������
    public TextMeshPro valueText; // ��TextMeshPro�����ã����ʹ�ñ�׼UI�ı��������Ϊpublic Text valueText;

    void Start()
    {
        pinchSlider.OnValueUpdated.AddListener(UpdateValueDisplay);
        UpdateValueDisplay(null); // ��ʼ����
    }

    private void UpdateValueDisplay(SliderEventData eventData)
    {
        float value = 100 + pinchSlider.SliderValue * 40; // SliderValue��0��1֮�䣬ת��Ϊ100��140
        valueText.text = Mathf.RoundToInt(value).ToString(); // ת��Ϊ�����������ı���ʾ
    }
}
