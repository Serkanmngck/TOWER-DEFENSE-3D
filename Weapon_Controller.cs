using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon_Controller : MonoBehaviour
{
    [SerializeField] private float fireRate;
    [SerializeField] private float attackRadius;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] public float weaponHp = 10;
    private Collider[] enemies;
    GameObject shopingObject;
    [SerializeField] private GameObject transformpos;

    private Enemy_Controller currentEnemy;
    void Start()
    {
        InvokeRepeating(nameof(ScanArea), 0, fireRate);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    private void ScanArea()
    {
        float distance = 1000;
        enemies = Physics.OverlapSphere(transform.position, attackRadius);

        if (currentEnemy)
        {
            float dist = Vector3.Distance(transform.position, currentEnemy.transform.position);
            if (dist > attackRadius)
            {
                currentEnemy = null;
            }
        }

        foreach (Collider enemy in enemies)
        {
            if (enemy.gameObject.TryGetComponent(out Enemy_Controller enemyScript))
            {
                float dist = Vector3.Distance(transform.position, enemy.transform.position);
                if (dist <= distance)
                {
                    currentEnemy = enemyScript;
                    distance = dist;
                }
            }
        }

        if (currentEnemy)
        {
             
            Bullet bullet = Instantiate(bulletPrefab, transformpos.transform.position, Quaternion.identity);
            bullet.setTarget(currentEnemy.transform);
        }
    }

    void Update()
    {
        if (currentEnemy)
        {
            Vector3 dir = currentEnemy.transform.position - transform.position;
            dir.y = 0;
            transform.rotation = Quaternion.LookRotation(dir);
        }
    }
    
}