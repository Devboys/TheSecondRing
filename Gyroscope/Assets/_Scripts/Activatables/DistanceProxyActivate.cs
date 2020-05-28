using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceProxyActivate : ActivateableBase
{
    [SerializeField] private List<ProxiedActivateableBase> proxiedObjects;
    [SerializeField] private Vector2 MinMaxDistanceEffect;

    [SerializeField] private GameObject target;

    public AudioClip soundToPlay;

    float prevT;

    float minT;

    AudioSource aSource;

    private float moveTresh = 0.001f;

    private void Start()
    {
        minT = 1;
        aSource = this.GetComponent<AudioSource>();
        aSource.clip = soundToPlay;
    }

    public override void Activate(GameObject activator, float intensity)
    {
        target = activator;
    }

    public override void Disable()
    {
        target = null;
    }

    public void Update()
    {
        
        float t = 1;
        if (target != null)
        {
            float dist = Vector3.Distance(target.transform.position, transform.position);
            t = StaticMath.NormalizeValue(dist, MinMaxDistanceEffect.x, MinMaxDistanceEffect.y);
        }

        t = Mathf.Clamp01(t);

        if (t < minT) minT = t;

        foreach(ProxiedActivateableBase activateable in proxiedObjects)
        {
            activateable.UpdateActivation(minT);
        }

        //measure distance
        float moveFactor = prevT - minT;
        if(moveFactor > moveTresh && !aSource.isPlaying)
        {
            aSource.Play();
        }
        else if(moveFactor < moveTresh && aSource.isPlaying )
        {
            aSource.Stop();
        }
        prevT = minT;

    }
}
