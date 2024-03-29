using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Bullet;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Bullet : MonoBehaviour
{
    private UnityEngine.Transform target;
    [SerializeField] private float speed;
    public BulletType bulletType;
    float steer = 20;
    public float height = 0.5f;

    private bool isAscending = true;
    private float startTime;
    private Vector3 initialPosition;
    bool control = false;
    private Rigidbody rb;
    private bool targetPositionUpdated = false;
    public enum BulletType
    {
        type1Level1,
        type1Level2,
        type1Level3,
        type2Level1,
        type2Level2,
        type2Level3,
        type3Level1,
        type3Level2,
        type3Level3,
        type4Level1,
        type4Level2,
        type4Level3,
        ennemy


    }

    public int Damage()
    {

        switch (bulletType)
        {
            case BulletType.type1Level1:

                return 101;

            case BulletType.type1Level2:

                return 151;

            case BulletType.type1Level3:

                return 202;

            case BulletType.type2Level1:

                return 51;

            case BulletType.type2Level2:

                return 76;

            case BulletType.type2Level3:

                return 101;

            case BulletType.type3Level1:

                return 80;
            case BulletType.type3Level2:

                return 110;
            case BulletType.type3Level3:

                return 155;
            case BulletType.type4Level1:

                return 8;
            case BulletType.type4Level2:

                return 13;
            case BulletType.type4Level3:

                return 17;
            case BulletType.ennemy:

                return 10;
            default:
                return 0;


        }
    }
    private void Start()
    {
        startTime = Time.time;
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = false;  // Bu, nesnenin fiziksel etkileþimlere izin vermesini saðlar.
        }

    }
    public void setTarget(UnityEngine.Transform target)
    {
        this.target = target;
    }

    void Update()
    {


        if (target)
        {
            if (bulletType == BulletType.type3Level1 || bulletType == BulletType.type3Level2 || bulletType == BulletType.type3Level3)
            {
                float journeyLength = Vector3.Distance(initialPosition, target.position);
                float distCovered = (Time.time - startTime) * speed;

                float fracJourney = distCovered / journeyLength;

                if (isAscending)
                {
                    transform.position = Vector3.Lerp(initialPosition, new Vector3(target.position.x, target.position.y + height, target.position.z), fracJourney);

                    if (fracJourney >= 0.3f)
                    {
                        isAscending = false;
                        //startTime = Time.time;
                    }
                }
                else
                {
                    Vector3 dir = target.position - transform.position;
                    transform.forward = dir;
                    transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
                    //transform.position = Vector3.Lerp(new Vector3(target.position.x, target.position.y + height, target.position.z), target.position, fracJourney);
                }

            }

            /* else if (bulletType == BulletType.type4Level1 || bulletType == BulletType.type4Level2 || bulletType == BulletType.type4Level3)
             {


                     if((target.position.x-transform.position.x)>5|| (target.position.x - transform.position.x) < -5)
                     {
                         Vector3 temp= new Vector3(transform.position.x,transform.position.y+5,transform.position.z);
                         Vector3 dir = target.position - transform.position;
                         transform.forward = dir;
                         transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
                     }
                     else
                     {
                         Debug.Log("buraya girdi");
                         control = false;
                         Vector3 dir = target.position - transform.position;
                         transform.forward = dir;
                         transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
                     }


             }*/
            else if (bulletType == BulletType.ennemy)
            {
                
                if (!targetPositionUpdated)
                {
                    Vector3 targetPosition = target.position;
                    
                    if (target.tag == "weapontype3.1" || target.tag == "weapontype3.2" || target.tag == "weapontype3.3"||target.tag == "weapontype4.1" || target.tag == "weapontype4.2" || target.tag == "weapontype4.3"  )
                    {
                        
                    }
                    else
                    {
                       

                        targetPosition.y += 4f;
                    }
                    

                    Vector3 dir = targetPosition - transform.position;
                    transform.forward = dir;
                    targetPositionUpdated = true;
                }
                transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);

            }
            else
            {
                Vector3 dir = target.position - transform.position;
                transform.forward = dir;
                transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }

    }


}
