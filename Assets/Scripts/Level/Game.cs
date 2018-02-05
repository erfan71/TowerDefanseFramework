using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    // Use this for initialization

    [SerializeField]
    private Level level;
    public Level Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }

   

    [SerializeField]
    private bool health;
    public bool Health
    {
        get
        {
            return health;
        }
       
    }

    [SerializeField]
    private bool bank;
    public bool Bank
    {
        get
        {
            return bank;
        }

    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		


	}
}
