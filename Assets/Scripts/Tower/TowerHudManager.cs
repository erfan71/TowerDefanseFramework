using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHudManager : MonoBehaviour {

    public GameObject towerSelectorGroup;
    public GameObject towerHudPrefab;
    public Transform towerParent;
    private List<TowerHud> towerHuds;
    private Place requestedPlace;
    // Use this for initialization
    #region SingletonPAttern
    private static TowerHudManager instance;
    public static TowerHudManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<TowerHudManager>();
                return instance;
            }
            else
                return instance;
        }
    }
    #endregion
    private void Start()
    {
        towerHuds = new List<TowerHud>();
    }

    public void OpenTowerSelectionMenu( Place requestedPlace)
    {
        if (towerSelectorGroup.activeSelf) return;
        this.requestedPlace = requestedPlace;
        Tower[] towers=  AssetManager.Instance.Towers;
        foreach(Tower tower in towers)
        {
            GameObject towerTemp= Instantiate(towerHudPrefab, Vector3.zero,Quaternion.identity, towerParent);
            TowerHud towerTempHud= towerTemp.GetComponent<TowerHud>();
            towerTempHud.Setup(tower.Id);
            towerTempHud.towerHudClicked += onTowerHudClicked;
            towerHuds.Add(towerTempHud);
            
        }

        towerSelectorGroup.SetActive(true);
    }

    private void onTowerHudClicked(int towerId)
    {
        requestedPlace.SetTower(towerId);
        OnCloseClicked();
    }

    public void OnCloseClicked()
    {
        foreach(TowerHud tower in towerHuds)
        {
            tower.towerHudClicked -= onTowerHudClicked;

            GameObject.Destroy(tower.gameObject);
        }
        towerHuds.Clear();
        towerSelectorGroup.SetActive(false);

    }
    
    private void OnDestroy()
    {
       
    }
}
