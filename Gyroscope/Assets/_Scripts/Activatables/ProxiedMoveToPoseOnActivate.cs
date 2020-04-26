using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxiedMoveToPoseOnActivate : ProxiedActivateableBase
{
    [SerializeField] private AnimationCurve Easing;
    [SerializeField] private Vector3 LocalOffsetOnInactive;

    private Vector3 StartPos;
    private Vector3 TargetPos;

    private void Start()
    {
        StartPos = transform.position;
        TargetPos = StartPos + transform.TransformVector(LocalOffsetOnInactive);
    }

    public override void UpdateActivation(float activation)
    {
        float t = Easing.Evaluate(activation);
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
