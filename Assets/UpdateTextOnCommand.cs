using TMPro;
using UnityEngine;

public class UpdateTextOnCommand : MonoBehaviour
{
    public TextMeshPro yourTextMeshPro; // �������TextMeshPro����

    public void UpdateTextTo140()
    {
        if (yourTextMeshPro != null)
        {
            yourTextMeshPro.text = "140";
        }
    }
}
