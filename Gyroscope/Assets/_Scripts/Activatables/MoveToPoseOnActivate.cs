using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoseOnActivate : ActivateableBase
{
    [SerializeField]private AnimationCurve Easing;
    [SerializeField] private Transform Target;

    [SerializeField]private Vector3 LocalOffsetOnInactive;
    [SerializeField] private Transform ActivatorTrans;
    private Vector3 StartPos;
    private Vector3 TargetPos;
    [SerializeField]private float MaxSpeed;
    [SerializeField]private Vector2 MinMaxDistanceEffect;

    private Vector3 GetTargetPos => Target != null ? Target.position : StartPos;
    private Vector3 GetTargetPosGizmos => Target != null ? Target.position : transform.position;
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
            t = StaticMath.NormalizeValue(Vector3.Distance(ActivatorTrans.position, GetTargetPos), MinMaxDistanceEffect.x,
                MinMaxDistanceEffect.y);
        }

        t = Easing.Evaluate(Mathf.Clamp01(t));
        transform.position = Vector3.Lerp(StartPos, TargetPos , t);
    }

    private void OnDrawGizmosSelected()
    {
        if (GetComponent<Collider>() == null)
        {
            return;
        }
        
        Gizmos.DrawWireCube(transform.position + transform.TransformVector(LocalOffsetOnInactive), GetComponent<Collider>().bounds.size);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GetTargetPosGizmos, MinMaxDistanceEffect.y);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(GetTargetPosGizmos, MinMaxDistanceEffect.x);
        Gizmos.DrawSphere(GetTargetPosGizmos, 1);

        Gizmos.DrawLine(GetTargetPosGizmos, transform.position + transform.TransformVector(LocalOffsetOnInactive));
    }
}
