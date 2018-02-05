using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private Transform startPoint;
    
    [SerializeField]
    private Transform endPoint;

    [SerializeField]
    private int pathId;
    public int PathId
    {
        get
        {
            return pathId;


        }
    }

    public Vector3[] GetPoints()
    {
        Vector3[] points = new Vector3[2];
        points[0] = startPoint.position;
        points[1] = endPoint.position;
        return points;

    }
}
