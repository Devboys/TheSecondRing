﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoseOnActivate : ActivateableBase
{
    [SerializeField] private AnimationCurve Easing;
    [SerializeField] private Vector3 LocalOffsetOnInactive;
    [SerializeField] private Transform ActivatorTrans;
    [SerializeField] private Vector2 MinMaxDistanceEffect;


    private Vector3 StartPos;
    private Vector3 TargetPos;

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
            float dist = Vector3.Distance(ActivatorTrans.position, StartPos);
            t = StaticMath.NormalizeValue(dist, MinMaxDistanceEffect.x, MinMaxDistanceEffect.y);
        }

        t = Mathf.Clamp01(t);
        t = Easing.Evaluate(t);
        transform.position = Vector3.Lerp(StartPos, TargetPos , t);
    }

    private void OnDrawGizmos()
    {
        //draw final position
        float gizmoSize = 0.5f;

        if (TargetPos != null)
        {
            //draw target pos
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(TargetPos, gizmoSize);

            //draw start pos
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(StartPos, gizmoSize);

            //draw current pos;
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, gizmoSize / 2f);
        }
        else
        {
            //draw target pos
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(TargetPos, gizmoSize);

            //draw current Pos;
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(TargetPos, gizmoSize);
        }
    }
}
