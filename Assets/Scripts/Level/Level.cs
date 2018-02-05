using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    #region SingletonPAttern
    private static Level instance;
    public static Level Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Level>();
                return instance;
            }
            else
                return instance;
        }
    }
    #endregion

    public enum Status
    {
        NotYetComplete,
        OneStar,
        TwoStars,
        ThreeStars,
    }

    [SerializeField]
    private int initial_Bank;
    public int Initial_Bank
    {
        get
        {
            return initial_Bank;
        }
        set
        {
            initial_Bank = value;
        }
    }

    [SerializeField]
    private int prize;
    public int Prize
    {
        get
        {
            return prize;
        }
        set
        {
            prize = value;
        }
    }
    [SerializeField]
    private Status _status;
    public Status status
    {
        get
        {
            return status;
        }
    }

    [SerializeField]
    private Map map;
    public Map Map
    {
        get
        {
            return map;
        }
        set
        {
            map = value;
        }
    }

    [SerializeField]
    private InvadeRound[] invadeRounds;
    public InvadeRound[] InvadeRounds
    {
        get
        {
            return invadeRounds;
        }
        set
        {
            invadeRounds = value;
        }
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(ExecuteInvadeRounds());
       
		
	}
    private int currentInvadeRound = 0;
	// Update is called once per frame
	IEnumerator ExecuteInvadeRounds()
    {
        while(true)
        {
            if (currentInvadeRound >= InvadeRounds.Length) yield break;
            yield return new WaitForSeconds(InvadeRounds[currentInvadeRound].DelayTime);
            InvadeRounds[currentInvadeRound].Execute();
            currentInvadeRound++;
        }       
    }
    public void ExecuteAction(System.Action test)
    {
        print("test");
        test();
    }
}
