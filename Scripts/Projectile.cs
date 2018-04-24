using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    //Rigidbody projectileRigidbody;
    public AudioSource playerAudio;
    public AudioClip cast;
    public AudioClip shot;
    public LayerMask collisionMask;
    float speed = 50;
    float cooldown;
    public int damage = 20;
    bool ready = false;
    bool slow = false;
    public new string name;
    float deadTime;
    public float nextShotTime;
    public void setNextShotTime(float shotTime)
    {
        nextShotTime = shotTime;
    }
    public float getNextShotTime()
    {
        return nextShotTime;
    }
    public void setDamage(int newDamage)
    {
        damage = newDamage;
    }
    public float getDamage()
    {
        return damage;
    }
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    public float getSpeed()
    {
        return speed;
    }
    public void setIfReadyToShoot(bool readyOrNot)
    {
        ready = readyOrNot;
    }

    public bool getIfReadyToShoot()
    {
        return ready;
    }
    public void setCooldown(float newCooldown)
    {
        cooldown = newCooldown;
    }
    public float getCooldown()
    {
        return cooldown;
    }
    public void setName(string newName)
    {
        name = newName;
    }
    public string getName()
    {
        return name;
    }
    public void playCast()
    {
        
        playerAudio.clip = cast;
        playerAudio.Play();
    }
    public void playShot()
    {
        
        playerAudio.clip = shot;
        playerAudio.Play();
    }
    void Awake()
    {
        

    }
    void Start()
    {
        

        //projectileRigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {

        deadTime += Time.deltaTime;
        float moveDistance = speed  * Time.deltaTime;
        CheckCollisions(moveDistance);
        //projectileRigidbody.MovePosition(projectileRigidBody.position + Vector3.forward * moveDistance * Time.fixedDeltaTime);
        
        transform.Translate(Vector3.forward * moveDistance);
        if (deadTime>3)
        {
            GameObject.Destroy(gameObject);
        }

        
    }
    void FixedUpdate()
    {
        //projectileRigidbody.AddRelativeForce(Vector3.forward * 50);
    }


    void CheckCollisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, moveDistance, collisionMask, QueryTriggerInteraction.Collide))
        {
            if (name == "fireball") {
                Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
                foreach (Collider hitObject in colliders)
                {
                    Rigidbody rb = hitObject.GetComponent<Rigidbody>();

                    if (rb != null)
                        rb.AddExplosionForce(500f, transform.position, 2f, 1f);

                }
            }else if (name == "lightningbolt")
            {
                slow = true;
            }
            OnHitObject(hit);
            
            
        }
    }

    void OnHitObject(RaycastHit hit)
    {
        IDamageable damageableObject = hit.collider.GetComponent<IDamageable>();
        
        if (damageableObject != null)
        {
            damageableObject.TakeHit(damage, hit);            
        }
        if (slow)
        {
            damageableObject.slow();
            slow = false;
        }
        

        GameObject.Destroy(gameObject);
        
    }
}
