using TMPro;
using UnityEngine;

public class HeartRate : MonoBehaviour
{
    // Reference to TextMeshPro component
    public TextMeshPro textMesh;

    // Heart Rate value
    public float heartRate = 60.0f;

    private void Start()
    {
        if (textMesh == null)
        {
            Debug.LogError("textMesh is not set!");
        }
    }
    private void Awake()
    {
        if (textMesh == null)
        {
            textMesh = GetComponent<TextMeshPro>();
        }
    }


    private void Update()
    {
        // For demo purposes, this randomly changes the heart rate value between 1 and 100 every 0.5 seconds.
        if (Time.time % 0.5f < 0.1f) // This is a simple way to do something every 0.5 seconds
        {
            heartRate = Random.Range(1.0f, 100.0f);
        }

        // Here, you should update heartRate value according to your heart rate sensor data instead of random value

        // Set the text of the Text Mesh Pro object to display the current heart rate
        textMesh.text = heartRate.ToString("F1");
    }
}
