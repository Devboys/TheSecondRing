using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnActive : ActivateableBase
{
    public AnimationCurve curve;
    private bool isActive;
    private Transform target;
    public Vector3 axis;
    public float speed;
    void Update()
    {
        if (!isActive) return;
        
        var calcSpeed = speed * (1 - Mathf.Clamp01(StaticMath.NormalizeValue(Vector3.Distance(target.position, transform.position), 5,
            20)));
        transform.Rotate(axis, calcSpeed * Time.deltaTime);
    }

    public override void Activate(GameObject activator)
    {
        isActive = true;
        target = activator.transform;
    }

    public override void Disable()
    {
        isActive = false;
    }
}