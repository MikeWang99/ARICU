using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LineRenderer line = gameObject.GetComponent<LineRenderer>();
        line.SetPosition(0, new Vector3(0, 1, 0));
        line.SetPosition(1, new Vector3(1, 0, 0));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
