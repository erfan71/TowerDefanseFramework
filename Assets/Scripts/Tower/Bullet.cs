using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Reflection;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    private Attribute hitDamage;
    public Attribute HitDamage
    {
        get
        {
            return hitDamage;
        }
        set
        {
            hitDamage = value;
        }
    }

    [SerializeField]
    private Attribute damageDuration;
    public Attribute DamageDuration
    {
        get
        {
            return damageDuration;
        }
        set
        {
            damageDuration = value;
        }
    }
    [SerializeField]
    private Attribute criticalHit;
    public Attribute CriticalHit
    {
        get
        {
            return criticalHit;
        }
        set
        {
            criticalHit = value;
        }
    }

    [SerializeField]
    private Attribute criticalChance;
    public Attribute CriticalChance
    {
        get
        {
            return criticalChance;
        }
        set
        {
            criticalChance = value;
        }
    }
    protected Dictionary<string, Attribute> attributes;
    protected bool isCritical;
    public float GetFinalizedValue(Attribute attr, int cuurentLevel)
    {
         return attributes[attr.name].levelCoefficient[cuurentLevel] * attributes[attr.name].value;
    }

    protected virtual void Initialize()
    {
        attributes = new Dictionary<string, Attribute>();
    }
    protected int GetRandomNumber(int min , int max)
    {
       return  UnityEngine. Random.Range(min, max);

    }
    protected bool CheckAttributePercentagePropability(Attribute att, int towerLevel)
    {
        if (GetRandomNumber(0, 100) < GetFinalizedValue(att, towerLevel))
        {
            return true;
        }
        return false;
    }
    void CheckCriticalChance(int towerLevel)
    {
        if (GetRandomNumber(0, 100) < GetFinalizedValue(criticalChance, towerLevel))
        {
            isCritical= true;
        }
        isCritical= false;
    }
    public virtual void Fire(int towerLevel,  List<Enemy> enemies)
    {
        Initialize();
        CheckCriticalChance(towerLevel);       

    }
}
