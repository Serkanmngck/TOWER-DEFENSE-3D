//using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class EnnemyHealthBarScript : MonoBehaviour
{
    [SerializeField] Image healthBar;
    [SerializeField] float decreSpeed;
    float healthBarInstance = 1f;
    private Camera cam;
    void Start()
    {
        cam=Camera.main;
    }

    void Update()
    {
        healthBar.fillAmount=Mathf.MoveTowards(healthBar.fillAmount,healthBarInstance, decreSpeed*Time.deltaTime);
        transform.rotation=cam.transform.rotation;
    }

    public void HealrhBarProgress(float currentHealth,float maxHealth)
    {
        healthBarInstance = currentHealth / maxHealth; 
    }
}
