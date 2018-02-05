using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHud : MonoBehaviour {

    // Use this for initialization

    private int id;
    public Image icon;
   
    public System.Action<int> towerHudClicked;
    public void OnPointerClicked(int towerId)
    {
        towerHudClicked?.Invoke(id);
    }
    public void Setup(int id)
    {
        this.id = id;

        icon.sprite= AssetManager.Instance.GetTowerSprite(id);
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
