using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AreaBullet : Bullet
{

    [SerializeField]
    private Attribute damageArea;
    public Attribute DamageArea
    {
        get
        {
            return damageArea;
        }
        set
        {
            damageArea = value;
        }
    }

    //[SerializeField]
    //private Attribute penetrationRate;
    //public Attribute Penetration
    //{
    //    get
    //    {
    //        return penetrationRate;
    //    }
    //    set
    //    {
    //        penetrationRate = value;
    //    }
    //}
    protected override void Initialize()
    {
        base.Initialize();
        var allClassAttributes = typeof(AreaBullet).GetProperties().Where
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
        print("salam In child");

        float damage = GetFinalizedValue(HitDamage, towerLevel);
        float multiply = 1;
        if (isCritical)
        {
            multiply = GetFinalizedValue(CriticalHit, towerLevel) / 100.0f;
        }
        float range = GetFinalizedValue(DamageArea, towerLevel);
        Vector3 damageCenter = enemies[0].GetPosition();
        damage = damage * multiply;

        for ( int i=0; i < enemies.Count; i++)
        {
            float dis = Vector3.Distance(enemies[i].GetPosition(), damageCenter);
            if (dis < range)
            {
                if (enemies[i].OnBulletHit(damage * Mathf.Pow(2, -dis)))
                {
                    i = 0;
                }

            }
        }
        Destroy(this.gameObject);

    }
}
