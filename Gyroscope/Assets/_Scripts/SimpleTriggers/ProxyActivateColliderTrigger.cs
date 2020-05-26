using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ProxyActivateColliderTrigger : MonoBehaviour
{
    public Collider colliderTarget;
    public Renderer RendererToChange;
    public Renderer glowRenderer;

    public bool triggered;

    Dictionary<string, matPair> storedVals;

    private struct matPair
    {
        public matPair(string s, float v)
        {
            field = s;
            value = v;
        }

        public string field;
        public float value;
    }

    private void Start()
    {
        storedVals = new Dictionary<string, matPair>();

        //add all material floats to stored dictionary for later use.
        storedVals.Add("minDistance", new matPair("Vector1_1DEA01FF", RendererToChange.sharedMaterial.GetFloat("Vector1_1DEA01FF"))); //minDistance on crystalReact
        storedVals.Add("maxDistance", new matPair("Vector1_4F9399E", RendererToChange.sharedMaterial.GetFloat("Vector1_4F9399E"))); //maxDistance on crystalReact;

        storedVals.Add("emmisionStrength", new matPair("Vector1_C05E6C68", glowRenderer.sharedMaterial.GetFloat("Vector1_C05E6C68"))); //emmision brightness on 

        //nothing worked so were just doing this manually
        RendererToChange.sharedMaterial.SetFloat(storedVals["minDistance"].field, 30);
        RendererToChange.sharedMaterial.SetFloat(storedVals["maxDistance"].field, 50);

        glowRenderer.sharedMaterial.SetFloat(storedVals["emmisionStrength"].field, 50);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!triggered)
        {
            if (collision.CompareTag(StaticVariables.Tags.Player))
                colliderTarget.enabled = true;
            Debug.Log("Triggered!");
            RendererToChange.sharedMaterial.SetFloat("Vector1_1DEA01FF", 0.1f);
            RendererToChange.sharedMaterial.SetFloat("Vector1_4F9399E", 0.2f);

            glowRenderer.sharedMaterial.SetFloat("Vector1_C05E6C68", 0f);

            triggered = true;
        }
    }

    private void OnDestroy()
    {
        //reset all shared changes to shared materials based on values recorded at start...
        // we do this because sharedMaterial changes asset itself, so changes carry over to non-playmode 
        RendererToChange.sharedMaterial.SetFloat(storedVals["minDistance"].field, 30);
        RendererToChange.sharedMaterial.SetFloat(storedVals["maxDistance"].field, 50);

        glowRenderer.sharedMaterial.SetFloat(storedVals["emmisionStrength"].field, 50);
    }
}
