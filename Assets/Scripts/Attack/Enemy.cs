using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    // Use this for initialization
   
    [SerializeField]
    private float speed;
    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }
    public float MaxHealth;

    private float currentHealth;
    public float CurrentHealth
    {

        get
        {
            return currentHealth;
        }
        
    }
    [SerializeField]
    private Image healthBar;
    public bool OnBulletHit(float damage)
    {
        print("OnBulletHit");
        currentHealth -= damage;
        if ( currentHealth<=0)
        {
            Destroy(this.gameObject);
            return true;
        }
        healthBar.fillAmount = currentHealth / MaxHealth;
        return false;
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    public void Setup(Path path)
    {
        currentHealth = MaxHealth;
       
        StartCoroutine(MoveAlongPath(path));
    }

    IEnumerator MoveAlongPath( Path path)
    {
        float rate = speed;
        float i = 0.0f;
        Vector3[] points = path.GetPoints();
        while (i<1.0f)
        {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(points[0], points[1],i);
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
