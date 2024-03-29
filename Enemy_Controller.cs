using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Controller : MonoBehaviour
{
    private bool die=false;
    public float currentHealth;
    public float maxHealth = 100;
    public int goldOnDeath = 10;
    [SerializeField] EnnemyHealthBarScript healthBar;
    private NavMeshAgent agent;
    public Skill skillType;
    private Collider[] towers;
    public float fireRate = 1f;
    public float attacktRadius = 1;
    public float defenseRate = 0.5f;
    private CastleM currentCastle;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Animator animator;
    private int bulletDamage = 0;
    public bool isInvulnerable = false;
    public float invulnerabilityTime = 1f; // Hasar alýnamama süresi 
    private Collider myCollider;
    [SerializeField] GameObject attackobject;

    public enum Skill
    {
        Default,
        Attack,
        Running,
        Defense
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.HealrhBarProgress(currentHealth, maxHealth);
        myCollider = GetComponent<Collider>();
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(Map_Manager.instance.tower.position);
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            UnityEngine.Debug.Log("Animator component not found!");
        }
        skill();
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            myCollider.enabled = false;
            animator.SetBool("Die", true);
            agent.speed = 0;
            if(die)
            {
                StartCoroutine(onesecond());
            }
            
        }
    }
    public void skill()
    {
        switch (skillType)
        {
            case Skill.Default:

                break;

            case Skill.Attack:
                InvokeRepeating(nameof(attack), 0, fireRate);
                break;
            case Skill.Running:

                InvokeRepeating(nameof(runningplay), 0, 5);
                break;

            case Skill.Defense:
                InvokeRepeating(nameof(defanseplay), 0, 5);

                break;
        }
    }
    private void runningplay()
    {
        StartCoroutine(running());
    }
    IEnumerator running()
    {
        animator.SetBool("Skill", true);
        agent.speed += 10f;
        yield return new WaitForSeconds(2.5f);
        agent.speed -= 10f;
        animator.SetBool("Skill", false);
    }
    void defanseplay()
    {
        StartCoroutine(defense());
    }

    
    IEnumerator defense()
    {
        isInvulnerable = true;
        animator.SetBool("Skill", true);
        yield return new WaitForSeconds(invulnerabilityTime);
        isInvulnerable = false;
        animator.SetBool("Skill", false);
    }
    IEnumerator onesecond()
    {
        agent.enabled = false;
        die = false;
        GameManager.Instance.TotalGold(goldOnDeath);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);

    }

    public void attack()
    {
        animator.SetBool("Skill", true);
        float distance = 1000;
        towers = Physics.OverlapSphere(attackobject.transform.position, attacktRadius);
        if (currentCastle)
        {
            float dist = Vector3.Distance(transform.position, currentCastle.transform.position);
            if (dist > attacktRadius)
            {
                currentCastle = null;
            }
        }
        else
        {
            UnityEngine.Debug.Log("currentCastle null.");
        }
        foreach (Collider enemy in towers)
        {
            if (enemy.gameObject.TryGetComponent(out CastleM towerScript))
            {
                float dist = Vector3.Distance(transform.position, enemy.transform.position);
                if (dist <= distance)
                {
                    currentCastle = towerScript;
                    distance = dist;
                }
            }
        }
        if (currentCastle)
        {
            Vector3 tempTransform = new Vector3(transform.position.x, transform.position.y + 4, transform.position.z);
            Bullet bullet = Instantiate(bulletPrefab, tempTransform, Quaternion.identity);

            bullet.setTarget(currentCastle.transform);
        }
        else
        {
            UnityEngine.Debug.Log("currentCastle null.");
        }
        animator.SetBool("Skill", false);
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Castle")
        {
            UnityEngine.Debug.Log("burdakalede");
            GameManager.Instance.damageCastle();
            Destroy(gameObject);
        }
        if (other.tag == "Bullet")
        {
            bulletDamage = other.GetComponent<Bullet>().Damage();
            if (!isInvulnerable) { currentHealth -= bulletDamage; healthBar.HealrhBarProgress(currentHealth, maxHealth); }
            Destroy(other.gameObject);
            if (currentHealth <= 0)
            {
                myCollider.enabled = false;
                animator.SetBool("Die", true);
                agent.speed = 0;
                StartCoroutine(onesecond());
            }


        }
        else if(other.tag =="BulletType3")
        {
            bulletDamage = other.GetComponent<Bullet>().Damage();
            Destroy(other.gameObject );
            Collider[] colliders = Physics.OverlapSphere(transform.position, 3f);
            foreach (Collider collider in colliders)
            {
                Enemy_Controller enemyController = collider.GetComponent<Enemy_Controller>();
                if (enemyController != null)
                {

                    if (!enemyController.isInvulnerable) { 
                            
                        enemyController.currentHealth -= bulletDamage; 
                        if(enemyController.currentHealth <= 0) { enemyController.die=true; }
                        enemyController.healthBar.HealrhBarProgress(enemyController.currentHealth, enemyController.maxHealth); }
                }
            }


        }
    }
}
