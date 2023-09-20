using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RES : MonoBehaviour
{
    public TextMeshPro textMesh;
    public TextAsset DataFile;
    private int HR;
    private int Count = 0;
    private List<int> HRData = new List<int>();
    private float nextUpdate = 0.0f;
    private float updateInterval = 5.0f;  // Update every 5 seconds

    private void Start()
    {
        if (textMesh == null)
        {
            Debug.LogError("textMesh is not set!");
        }

        if (DataFile == null)
        {
            Debug.LogError("DataFile is not set!");
        }
        else
        {
            LoadDataFromCSV();
        }
    }

    private void Awake()
    {
        if (textMesh == null)
        {
            textMesh = GetComponent<TextMeshPro>();
        }
    }

    private void LoadDataFromCSV()
    {
        string[] lines = DataFile.text.Split(new[] { "\r\n", "\r", "\n" }, System.StringSplitOptions.RemoveEmptyEntries);
        for (int i = 1; i < lines.Length; i++)
        {
            string[] entries = lines[i].Split(',');
            if (int.TryParse(entries[6], out int parsedHR))
            {
                HRData.Add(parsedHR);
            }
            else
            {
                Debug.LogWarning("Could not parse HR value: " + entries[0]);
            }
        }
    }

    private void Update()
    {
        if (Time.time >= nextUpdate)
        {
            nextUpdate += updateInterval;
            if (Count < HRData.Count)
            {
                HR = HRData[Count];
                Count++;
            }
            else
            {
                Debug.LogWarning("Reached end of HRData list.");
            }
        }

        textMesh.text = HR.ToString();
    }
}
