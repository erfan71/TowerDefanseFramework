using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InvadeRound  {


    [SerializeField]
    private AttackWave[] attackWavesPrefabs;
    public AttackWave[] AttackWavesPrefabs
    {
        get
        {
            return attackWavesPrefabs;
        }
        set
        {
            attackWavesPrefabs = value;
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

    public void Execute()
    {
        float delay = 0;
        foreach (AttackWave att in attackWavesPrefabs)
        {
            Level.Instance.ExecuteAction(() =>
            {
                
                MyTime.IInvoke(() =>
                {
                    AttackWave wave = UnityEngine.MonoBehaviour.Instantiate(att);
                    wave.Run();

                }, delay);
            });
            delay += delayTime;

        }

    }
    
   

}
