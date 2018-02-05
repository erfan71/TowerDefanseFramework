using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour {

    
    [SerializeField]
    private ResourceType resourceType;
    public ResourceType ResourceType
    {
        get
        {
            return resourceType;
        }
        set
        {
            resourceType = value;
        }
    }

    [SerializeField]
    private int value;
    public int Value
    {
        get
        {
            return value;
        }
    }
    public void Increase(int _value)
    {
        value += _value;
    }
    public bool Decrease(int _value)
    {
        value -= _value;
        if (value < 0)
        {
            value = 0;
            return false;
        }
        else
        {
            return true;
        }
    }


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
   
}
public enum ResourceType
{
    Coin,
    Gem,
    Paper
}
