using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AttackWave:MonoBehaviour {

    [SerializeField]
    // Use this for initialization
    private Enemy[] enemiesPrefabs;
    public Enemy[] EnemiesPrefabs
    {
        get
        {
            return enemiesPrefabs;
        }
    }
    [SerializeField]
    private float delayTime;
    public float DelayTime
    {
        get
        {
           return delayTime;
        }
    }
    [SerializeField]
    private int wavePathId;
    public int WavePathId
    {
        get
        {
            return wavePathId;
        }
    }

    public void Run()
    {
       
        StartCoroutine(InstantiatingEnemy());
    }

    IEnumerator InstantiatingEnemy()
    {
        foreach (Enemy en in enemiesPrefabs)
        {
            Enemy enemy = Instantiate(en);
            Path path = Level.Instance.Map.GetPath(wavePathId);
            enemy.Setup(path);
            yield return new WaitForSeconds(delayTime);

        }
    }
}
