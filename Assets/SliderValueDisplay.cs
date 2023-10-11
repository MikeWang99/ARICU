using UnityEngine;
using UnityEngine.UI; // 如果使用UI文本
using TMPro; // 如果使用TextMeshPro
using Microsoft.MixedReality.Toolkit.UI;

public class SliderValueDisplay : MonoBehaviour
{
    public PinchSlider pinchSlider; // 对PinchSlider的引用
    public TextMeshPro valueText; // 对TextMeshPro的引用，如果使用标准UI文本，请更改为public Text valueText;

    void Start()
    {
        pinchSlider.OnValueUpdated.AddListener(UpdateValueDisplay);
        UpdateValueDisplay(null); // 初始更新
    }

    private void UpdateValueDisplay(SliderEventData eventData)
    {
        float value = 100 + pinchSlider.SliderValue * 40; // SliderValue在0和1之间，转换为100到140
        valueText.text = Mathf.RoundToInt(value).ToString(); // 转换为整数并更新文本显示
    }
}
