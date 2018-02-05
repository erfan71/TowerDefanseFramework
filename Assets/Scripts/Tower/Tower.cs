using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tower : MonoBehaviour
{
    [SerializeField]
    private int id;
    public int Id
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }
    // Use this for initialization
    private int currentLevel = 0;
    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
    }

    [SerializeField]
    private Attribute fireRate;
    public Attribute FireRate
    {
        get
        {
            return fireRate;
        }
        set
        {
            fireRate = value;
        }
    }

    [SerializeField]
    private Attribute fireRange;
    public Attribute FireRange
    {
        get
        {
            return fireRange;
        }
        set
        {
            fireRange = value;
        }
    }

   

    [SerializeField]
    private Bullet bulletPrefab;
    public Bullet BulletPrefab
    {
        get
        {
            return bulletPrefab;
        }
    }
    [SerializeField]
    private CircleCollider2D rangeCollider;
    [SerializeField]
    private TowerScope towerScope;



    private List<Enemy> visibleEnemies;
    public List<Enemy> VisibleEnemies
    {
        get
        {
            return visibleEnemies;
        }
    }

    #region Firing
    Coroutine firing;
    int enemyPopulation;
    bool firingRunning;
    public string enemyTag;

    void Fire()
    {
        //f.;dmkdsjh jkfhhsd fhj 
        if (visibleEnemies.Count>0)
        {
            Bullet bullet=  Instantiate(bulletPrefab);
            bullet.Fire(currentLevel, visibleEnemies);

        }
    }
    IEnumerator FiringRoutine()
    {
        firingRunning = true;
        while (true)
        {
            yield return new WaitForSeconds(FireRate.value);
            Fire();
            yield return null;
        }
    }
    void OnEnemyDetected(Enemy enemy)
    {
        enemyPopulation++;
        if (!firingRunning)
            firing = StartCoroutine(FiringRoutine());
        Debug.LogFormat("OnEnemyDetected {0} ", enemyPopulation);
        visibleEnemies.Add(enemy);

    }
    void OnEnemtyExit(Enemy enemy)
    {

        enemyPopulation--;
        if (enemyPopulation == 0)
            StopFireing();
        Debug.LogFormat("OnEnemtyExit {0} ", enemyPopulation);
        visibleEnemies.Remove(enemy);
    }
    void StopFireing()
    {
        StopCoroutine(firing);
        firingRunning = false;

    }
    private void OnSomeBodyDetected(string otherTag, Enemy enemy)
    {

        if (otherTag == enemyTag)
        {
            OnEnemyDetected(enemy);
        }
    }
    private void OnSomeBodyLeft(string otherTag, Enemy enemy)
    {
        if (otherTag == enemyTag)
        {
            OnEnemtyExit(enemy);
        }
    }
    #endregion

    
    // Update is called once per frame
    void Update()
    {

    }


    
    void Start()
    {
        visibleEnemies = new List<Enemy>();
        rangeCollider.radius = FireRange.value;
        towerScope.someBodyDetected += OnSomeBodyDetected;
        towerScope.someBodyLeft += OnSomeBodyLeft;

    }
    private void OnDestroy()
    {
        towerScope.someBodyDetected -= OnSomeBodyDetected;
        towerScope.someBodyLeft -= OnSomeBodyLeft;

    }
    public void Upgrade()
    {
        currentLevel++;
    }

}
