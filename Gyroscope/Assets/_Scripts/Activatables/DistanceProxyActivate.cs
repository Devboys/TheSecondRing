using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceProxyActivate : ActivateableBase
{
    [SerializeField] private List<ProxiedActivateableBase> proxiedObjects;
    [SerializeField] private Vector2 MinMaxDistanceEffect;

    [SerializeField] private GameObject target;

    public override void Activate(GameObject activator)
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

        foreach(ProxiedActivateableBase activateable in proxiedObjects)
        {
            activateable.UpdateActivation(t);
        }
    }
}
