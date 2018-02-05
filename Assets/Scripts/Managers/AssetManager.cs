using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetManager : MonoBehaviour {

    // Use this for initialization

        [SerializeField]
    private Tower[] towersPrebas;
    public Tower[] Towers
    {
        get
        {
            return towersPrebas;
        }
    }

    public Tower GetTowerPrefab(int towerId)
    {
        foreach(Tower tower in towersPrebas)
        {
            if (tower.Id==towerId)
            {
                return tower;
            }
        }
        return null;
    }
    public Sprite GetTowerSprite(int towerID)
    {
        foreach (Tower tower in towersPrebas)
        {
            if (tower.Id == towerID)
            {
                return tower.GetComponent<SpriteRenderer>().sprite;
            }
        }
        return null;
    }
   // public Level[] levels;

    #region SingletonPAttern
    private static AssetManager instance;
    public static AssetManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<AssetManager>();
                return instance;
            }
            else
                return instance;
        }
    }
    #endregion

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
