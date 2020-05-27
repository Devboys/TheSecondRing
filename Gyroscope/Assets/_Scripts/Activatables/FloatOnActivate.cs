using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class FloatOnActivate : ActivateableBase
{
    private Transform target;
    private bool isActive;
    public float force;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isActive)
        {

            var forceCalc = force * (1 - Mathf.Clamp01(StaticMath.NormalizeValue(
                                 Vector3.Distance(target.position, transform.position), 5,
                                 12)));
            rb.AddForce(-transform.position.normalized * forceCalc);
        }
    }

    public override void Activate(GameObject activator, float intensity)
    {
        isActive = true;
        target = activator.transform;

    }

    public override void Disable()
    {
        isActive = false;
    }
}
