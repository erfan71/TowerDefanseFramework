using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    // Use this for initialization
   
    [SerializeField]
    Place[] places;
    public Place[] Places
    {
        get
        {
            return places;
        }
    }
    [SerializeField]
    Path[] pathes;
    public Path[] Pathes
    {
        get
        {
            return pathes;
        }
    }

	void Start () {

       
		
	}

   public Path GetPath(int pathId)
    {
        foreach(Path path in pathes)
        {
            if ( path.PathId==pathId)
            {
                return path;
            }
        }
        return null;
    }

    private void OnDestroy()
    {
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
