using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleM : MonoBehaviour
{
    [SerializeField]  public float castleMHP = 100;
    public float currentHealth;
    public GameObject shopingObject;
    [SerializeField] EnnemyHealthBarScript healthBar;
    private void Start()
    {
        currentHealth = castleMHP;
        healthBar.HealrhBarProgress(currentHealth, castleMHP);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "EnnemyBullet")
        {
            int bulletDamage = other.GetComponent<Bullet>().Damage();

            UnityEngine.Debug.Log("bullet damage " + bulletDamage);
            currentHealth -= bulletDamage;
            healthBar.HealrhBarProgress(currentHealth, castleMHP);
            Destroy(other.gameObject);
            if (currentHealth <= 0)
            {
                Instantiate(shopingObject, transform.position, Quaternion.identity);
                Destroy(gameObject);

            }

        }
    }


}
