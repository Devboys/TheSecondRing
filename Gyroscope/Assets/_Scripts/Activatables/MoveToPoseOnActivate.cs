using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoseOnActivate : ActivateableBase
{
    [SerializeField]private AnimationCurve Easing;
    [SerializeField]private Vector3 LocalOffsetOnInactive;
    [SerializeField] private Transform ActivatorTrans;
    private Vector3 StartPos;
    private Vector3 TargetPos;
    [SerializeField]private Vector2 MinMaxDistanceEffect;
    public override void Activate(GameObject activator)
    {
        ActivatorTrans = activator.transform;
    }

    public override void Disable()
    {
        ActivatorTrans = null;
    }

    private void Start()
    {
        StartPos = transform.position;
        TargetPos = StartPos + transform.TransformVector(LocalOffsetOnInactive);
    }

    private void Update()
    {
        float t = 1;
        if (ActivatorTrans != null)
        { 
            t = StaticMath.NormalizeValue(Vector3.Distance(ActivatorTrans.position, StartPos), MinMaxDistanceEffect.x,
                MinMaxDistanceEffect.y);
        }

        t = Easing.Evaluate(Mathf.Clamp01(t));
        transform.position = Vector3.Lerp(StartPos, TargetPos , t);
    }
}
