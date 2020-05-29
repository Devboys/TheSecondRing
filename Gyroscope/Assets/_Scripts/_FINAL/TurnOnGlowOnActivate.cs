using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnGlowOnActivate : ActivateableBase
{
    public string emmissionStrengthHash;
    public string otheremmisive;

    public Renderer rendToChange;
    public Renderer otherRenderer;

    public float maxEmmisive;
    public float minEmmisive;
    public float numSeconds = 1;

    bool isActive;
    float currentEmmisive;

    public void Update()
    {
        if (isActive)
        {
            currentEmmisive = Mathf.MoveTowards(currentEmmisive, maxEmmisive, (Time.deltaTime * maxEmmisive) / numSeconds);
        }
        else
        {
            currentEmmisive = Mathf.MoveTowards(currentEmmisive, minEmmisive, (Time.deltaTime * maxEmmisive) / numSeconds);
        }

        rendToChange.material.SetFloat(emmissionStrengthHash, currentEmmisive);
        if(otherRenderer)
            otherRenderer.material.SetFloat(otheremmisive, currentEmmisive);

    }

    public override void Activate(GameObject activator, float intensity)
    {
        isActive = true;
    }

    public override void Disable()
    {
        isActive = false;
        
    }
}
