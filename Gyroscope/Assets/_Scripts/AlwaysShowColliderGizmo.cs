using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysShowColliderGizmo : MonoBehaviour
{
    public bool onSelected;
    public bool isTrigger;


    void OnDrawGizmos()
    {
        if (!onSelected)
        {
            Gizmos.color = isTrigger ? Color.yellow : Color.red;
            Matrix4x4 prevMatrix = Gizmos.matrix;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
            Gizmos.matrix = prevMatrix;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (onSelected)
        {
            Gizmos.color = isTrigger ? Color.yellow : Color.red;
            Matrix4x4 prevMatrix = Gizmos.matrix;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
            Gizmos.matrix = prevMatrix;
        }
    }
}
