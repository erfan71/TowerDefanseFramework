using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Place : MonoBehaviour, IPointerClickHandler {

    // Use this for initialization
    public Transform towerPlace;
    [SerializeField]
    int id;
    public int Id
    {
        get
        {
            return id;
        }
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        TowerHudManager.Instance.OpenTowerSelectionMenu(this);
    }

    public void SetTower(int towerID)
    {
        Tower selectedTowerPrefab = AssetManager.Instance.GetTowerPrefab(towerID);
        Tower towerObj = Instantiate(selectedTowerPrefab);
        towerObj.transform.parent = this.transform;
        towerObj.transform.position = towerPlace.position;

    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
