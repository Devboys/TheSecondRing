using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePowerwhoo : MonoBehaviour
{
    public float number;
    public float numberTwo;

    Material material;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Renderer>().sharedMaterial.SetFloat("Vector1_1DEA01FF", number);
        gameObject.GetComponent<Renderer>().sharedMaterial.SetFloat("Vector1_4F9399E", numberTwo);

    }
}
