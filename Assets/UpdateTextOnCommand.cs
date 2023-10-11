using TMPro;
using UnityEngine;

public class UpdateTextOnCommand : MonoBehaviour
{
    public TextMeshPro yourTextMeshPro; // �������TextMeshPro����

    public void UpdateTextTo100()
    {
        if (yourTextMeshPro != null)
        {
            yourTextMeshPro.text = "100";
        }
    }

    public void UpdateTextTo110()
    {
        if (yourTextMeshPro != null)
        {
            yourTextMeshPro.text = "110";
        }
    }

    public void UpdateTextTo90()
    {
        if (yourTextMeshPro != null)
        {
            yourTextMeshPro.text = "90";
        }
    }

}
