using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SingleBullet : Bullet {

    [SerializeField]
    private Attribute accuracy;
    public Attribute Accuracy
    {
        get
        {
            return accuracy;
        }
        set
        {
            accuracy = value;
        }
    }

    

    [SerializeField]
    private Attribute multiShotChance;
    public Attribute MultiShotChance
    {
        get
        {
            return multiShotChance;
        }
        set
        {
            multiShotChance = value;
        }
    }

    [SerializeField]
    private Attribute multiShotCount;
    public Attribute MultiShotCount
    {
        get
        {
            return multiShotCount;
        }
        set
        {
            multiShotCount = value;
        }
    }

    protected override void Initialize()
    {
        base.Initialize();
        var allClassAttributes = typeof(SingleBullet).GetProperties().Where
           (p => p.PropertyType == typeof(Attribute)).ToList();
        for (int i = 0; i < allClassAttributes.Count; i++)
        {
            Attribute att = (Attribute)allClassAttributes[i].GetValue(this);
            attributes.Add(att.name, att);
        }
    }

    public override void Fire(int towerLevel, List<Enemy> enemies)
    {
        base.Fire(towerLevel, enemies);

        if (CheckAttributePercentagePropability(Accuracy, towerLevel))
        {
            float damage = GetFinalizedValue(HitDamage, towerLevel);
            int hitCount = 1;
            float multiply = 1;
            if ( isCritical)
            {
                multiply = GetFinalizedValue(CriticalHit, towerLevel)/100.0f;
            }

            if (CheckAttributePercentagePropability(MultiShotChance, towerLevel))
            {
                 hitCount =(int) GetFinalizedValue(MultiShotCount, towerLevel);
            }
            damage = hitCount * damage * multiply;
            if ( enemies.Count>0)
            enemies[0].OnBulletHit(damage);
            Destroy(this.gameObject);

        }
        
    }
    
   

}

