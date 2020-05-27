using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ProxyActivateColliderTrigger : MonoBehaviour
{
    public Collider colliderTarget;
    public Collider colliderTarget2;
    public Renderer RendererToChange;
    public Renderer glowRenderer;

    public float toneTime;

    public bool triggered;

    [Header("Original Values - resets to this after everything is done")]
    public float originalMinDistanceValue = 30;
    public float originalMaxDistanceValue = 50;
    public float originalEmmisionStrengthValue = 50;

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
        RendererToChange.sharedMaterial.SetFloat(storedVals["minDistance"].field, originalMinDistanceValue);
        RendererToChange.sharedMaterial.SetFloat(storedVals["maxDistance"].field, originalMaxDistanceValue);

        glowRenderer.sharedMaterial.SetFloat("Vector1_C05E6C68", originalEmmisionStrengthValue);
    }

    private void OnTriggerEnter(Collider collision)
    {
        DeactivateEverything(collision);
    }

    private void DeactivateEverything(Collider collision)
    {
        if (!triggered)
        {
            if (collision.CompareTag(StaticVariables.Tags.Player))
            {
                //colliderTarget.enabled = true;
                //RendererToChange.sharedMaterial.SetFloat("Vector1_1DEA01FF", 0.1f);
                //RendererToChange.sharedMaterial.SetFloat("Vector1_4F9399E", 0.2f);

                //glowRenderer.sharedMaterial.SetFloat("Vector1_C05E6C68", 0f);

                StartCoroutine(toneDownLights(toneTime));

                triggered = true;
            }
        }
    }

    public void ActivateEverything()
    {

        //disable colliders
        colliderTarget.enabled = false;
        colliderTarget2.enabled = false;

        ////nothing worked so we're just resetting values manually, gotta change  this if we change fields
        //RendererToChange.sharedMaterial.SetFloat(storedVals["minDistance"].field, originalMinDistanceValue);
        //RendererToChange.sharedMaterial.SetFloat(storedVals["maxDistance"].field, originalMaxDistanceValue);

        //glowRenderer.sharedMaterial.SetFloat("Vector1_C05E6C68", originalEmmisionStrengthValue);

        StartCoroutine(toneUpLights(toneTime));
    }

    private void OnDestroy()
    {
        //nothing worked so we're just doin this manually
        RendererToChange.sharedMaterial.SetFloat(storedVals["minDistance"].field, originalMinDistanceValue);
        RendererToChange.sharedMaterial.SetFloat(storedVals["maxDistance"].field, originalMaxDistanceValue);

        glowRenderer.sharedMaterial.SetFloat("Vector1_C05E6C68", originalEmmisionStrengthValue);
    }

    private IEnumerator toneDownLights(float toneDownTime)
    {
        yield return null;
        float timer = 0;

        while (timer < toneDownTime)
        {
            Debug.Log("toning down");
            float normalizedTime = timer / toneDownTime;
            //nothing worked so we're just resetting values manually, gotta change  this if we change fields
            RendererToChange.sharedMaterial.SetFloat(storedVals["minDistance"].field, originalMinDistanceValue * (1-normalizedTime));
            RendererToChange.sharedMaterial.SetFloat(storedVals["maxDistance"].field, originalMaxDistanceValue * (1-normalizedTime));

            glowRenderer.sharedMaterial.SetFloat("Vector1_C05E6C68", originalEmmisionStrengthValue * (1-normalizedTime));

            timer += Time.deltaTime;

            yield return null;
        }
        //nothing worked so we're just resetting values manually, gotta change  this if we change fields
        RendererToChange.sharedMaterial.SetFloat(storedVals["minDistance"].field, 0.1f);
        RendererToChange.sharedMaterial.SetFloat(storedVals["maxDistance"].field, 0.2f);

        glowRenderer.sharedMaterial.SetFloat("Vector1_C05E6C68", 0);

    }

    private IEnumerator toneUpLights(float toneUpTime)
    {
        yield return null;
        float timer = 0;

        while (timer < toneUpTime)
        {

            float normalizedTime = timer / toneUpTime;
            //nothing worked so we're just resetting values manually, gotta change  this if we change fields
            RendererToChange.sharedMaterial.SetFloat(storedVals["minDistance"].field, originalMinDistanceValue * normalizedTime);
            RendererToChange.sharedMaterial.SetFloat(storedVals["maxDistance"].field, originalMaxDistanceValue * normalizedTime);

            glowRenderer.sharedMaterial.SetFloat("Vector1_C05E6C68", originalEmmisionStrengthValue * normalizedTime);

            timer += Time.deltaTime;

            yield return null;
        }
        //nothing worked so we're just resetting values manually, gotta change  this if we change fields
        RendererToChange.sharedMaterial.SetFloat(storedVals["minDistance"].field, originalMinDistanceValue);
        RendererToChange.sharedMaterial.SetFloat(storedVals["maxDistance"].field, originalMaxDistanceValue);

        glowRenderer.sharedMaterial.SetFloat("Vector1_C05E6C68", originalEmmisionStrengthValue);
    }
}
