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
    public float originalActivatorEmissionStrength = 4.19f;
    public Vector3 originalActivatorScale = new Vector3(25, 25, 25);

    public string minDistanceValHash;
    public string maxDistanceValHash;
    public string emmisionStrengthHash;

    Activator _activator;

    private void Start()
    {

        //nothing worked so were just doing this manually
        RendererToChange.sharedMaterial.SetFloat(minDistanceValHash, originalMinDistanceValue);
        RendererToChange.sharedMaterial.SetFloat(maxDistanceValHash, originalMaxDistanceValue);

        glowRenderer.sharedMaterial.SetFloat(emmisionStrengthHash, originalEmmisionStrengthValue);

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
                _activator = FindObjectOfType<Activator>();

                colliderTarget.enabled = true;

                StartCoroutine(toneDownLights(toneTime));

                triggered = true;
            }
        }
    }

    public void ActivateEverything()
    {
        _activator = FindObjectOfType<Activator>();
        //disable colliders
        colliderTarget.enabled = false;
        colliderTarget2.enabled = false;

        StartCoroutine(toneUpLights(toneTime));
    }

    private void OnDestroy()
    {
        //nothing worked so we're just doin this manually
        RendererToChange.sharedMaterial.SetFloat(minDistanceValHash, originalMinDistanceValue);
        RendererToChange.sharedMaterial.SetFloat(maxDistanceValHash, originalMaxDistanceValue);

        glowRenderer.sharedMaterial.SetFloat(emmisionStrengthHash, originalEmmisionStrengthValue);
    }

    private IEnumerator toneDownLights(float toneDownTime)
    {
        yield return null;
        float timer = 0;

        while (timer < toneDownTime)
        {
            float normalizedTime = timer / toneDownTime;

            //nothing worked so we're just resetting values manually, gotta change  this if we change fields
            RendererToChange.sharedMaterial.SetFloat(minDistanceValHash, originalMinDistanceValue * (1-normalizedTime));
            RendererToChange.sharedMaterial.SetFloat(maxDistanceValHash, originalMaxDistanceValue * (1-normalizedTime));

            glowRenderer.sharedMaterial.SetFloat(emmisionStrengthHash, originalEmmisionStrengthValue * (1-normalizedTime));

            _activator.transform.localScale = originalActivatorScale * (1 - normalizedTime);

            timer += Time.deltaTime;

            yield return null;
        }
        //nothing worked so we're just resetting values manually, gotta change  this if we change fields
        RendererToChange.sharedMaterial.SetFloat(minDistanceValHash, 0.1f);
        RendererToChange.sharedMaterial.SetFloat(maxDistanceValHash, 0.2f);

        glowRenderer.sharedMaterial.SetFloat(emmisionStrengthHash, 0);

        _activator.transform.localScale = Vector3.zero;

    }

    private IEnumerator toneUpLights(float toneUpTime)
    {
        yield return null;
        float timer = 0;

        while (timer < toneUpTime)
        {
            float normalizedTime = timer / toneUpTime;

            //nothing worked so we're just resetting values manually, gotta change  this if we change fields
            RendererToChange.sharedMaterial.SetFloat(minDistanceValHash, originalMinDistanceValue * normalizedTime);
            RendererToChange.sharedMaterial.SetFloat(maxDistanceValHash, originalMaxDistanceValue * normalizedTime);

            glowRenderer.sharedMaterial.SetFloat(emmisionStrengthHash, originalEmmisionStrengthValue * normalizedTime);

            _activator.transform.localScale = originalActivatorScale * normalizedTime;

            timer += Time.deltaTime;


            yield return null;
        }
        //nothing worked so we're just resetting values manually, gotta change  this if we change fields
        RendererToChange.sharedMaterial.SetFloat(minDistanceValHash, originalMinDistanceValue);
        RendererToChange.sharedMaterial.SetFloat(maxDistanceValHash, originalMaxDistanceValue);

        glowRenderer.sharedMaterial.SetFloat(emmisionStrengthHash, originalEmmisionStrengthValue);

        _activator.transform.localScale = originalActivatorScale;
    }
}
