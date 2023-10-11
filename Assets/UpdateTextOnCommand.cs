using TMPro;
using UnityEngine;

public class UpdateTextOnCommand : MonoBehaviour
{
    public TextMeshPro yourTextMeshPro; // 引用你的TextMeshPro对象

    public void UpdateTextTo140()
    {
        if (yourTextMeshPro != null)
        {
            yourTextMeshPro.text = "140";
        }
    }
}
