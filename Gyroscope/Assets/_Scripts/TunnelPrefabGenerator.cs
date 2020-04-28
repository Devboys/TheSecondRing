using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelPrefabGenerator : MonoBehaviour
{
    public bool GenerateSpawnPoints;
    public bool SpawnPrefabs;
    public float density;
    public float minSpread;
    public GameObject Prefab;

    public List<PathElement> Path;
    private List<Vector3> Spawnpoints = new List<Vector3>();

    private void OnDrawGizmos()
    {
        if (Path == null)
        {
            return;
        }

        for (int i = 0; i < Path.Count; i++)
        {
            var element = Path[i];
            DrawCircle(element.PathCircle);
            if (i == 0)
                continue;

            var prevElement = Path[i - 1];

            DrawConnectedCircles(element.PathCircle, prevElement.PathCircle);
            DrawPointsBetweenPositions(prevElement.Element,element.Element, minSpread);

        }
    }

    void DrawPointsBetweenPositions(Transform p1, Transform p2, float pRadius)
    {
        int iter = (int)(Vector3.Distance(p1.position, p2.position) / minSpread);
        for (int i = 0; i < iter; i++)
        {
            var list = PointsOnCircle(pRadius);
            for (int j = 0; j < list.Count; j++)
            {

                Gizmos.DrawSphere(p1.position + p1.forward * (iter * minSpread) + p1.rotation * list[j], minSpread);
            }
        }
    }

    private void DrawCircle(PathCircle pathCircle)
    {
        for (int i = 0; i < pathCircle.Positions.Count; i++)
        {
            var cur = pathCircle.Positions[i];
            var prev = pathCircle.Positions[pathCircle.Positions.Count - 1];
            if (i > 0)
            {
                prev = pathCircle.Positions[i - 1];
            }
            Gizmos.DrawLine(cur, prev);
        }
    }

    private void DrawConnectedCircles(PathCircle p, PathCircle c)
    {
        for (int i = 0; i < p.Positions.Count; i++)
        {
            Gizmos.DrawLine(p.Positions[i], c.Positions[i]);
        }
    }

    private List<Vector3> PointsOnCircle(float radius)
    {
        var p = new List<Vector3>();
        var minDeg = 1;
        var referencePoint = Vector3.up * radius;
        var testPoint = GetPointFromDegree(minDeg);
        while (Vector3.Distance(testPoint, referencePoint) < minSpread)
        {
            minDeg += 1;
        }

        int iter = 360 / minDeg;

        for (int i = 0; i < iter; i++)
        {
            p.Add(GetPointFromDegree(minDeg * i));
        }

        return p;
    }

    Vector3 GetPointFromDegree(float degree)
    {
        return new Vector3(Mathf.Cos(degree * Mathf.Deg2Rad), Mathf.Sin(degree * Mathf.Deg2Rad), 0);
    }
}


[System.Serializable]
public class PathElement
{
    public float Radius;
    public Transform Element;

    public PathCircle PathCircle { get { return new PathCircle(Radius,Element); } }
}

public class PathCircle
{
    public List<Vector3> Positions = new List<Vector3>();

    public PathCircle(float radius, Transform trans)
    {
        Positions = new List<Vector3> { Vector3.up * radius, (Vector3.up + Vector3.right).normalized * radius,
        Vector3.right * radius, (Vector3.right + Vector3.down).normalized * radius,
        Vector3.down * radius, (Vector3.down + Vector3.left).normalized * radius,
        Vector3.left * radius, (Vector3.left + Vector3.up).normalized * radius};

        for (int i = 0; i < Positions.Count; i++)
        {
            Positions[i] = trans.rotation * Positions[i];
            Positions[i] += trans.position;
        }
    }
}