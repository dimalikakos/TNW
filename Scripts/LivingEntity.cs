using UnityEngine;
using System.Collections;

public class LivingEntity : MonoBehaviour, IDamageable {
    Rigidbody enemyRigidBody;

    public float startingHealth;
	protected float health;
	protected bool dead;

	protected virtual void Start() {
		health = startingHealth;
        enemyRigidBody = GetComponent<Rigidbody>();

    }

	public void TakeHit(int damage, RaycastHit hit) {
		//health -= damage;
        //enemyRigidBody.AddExplosionForce(200f, hit.point, 200f, 3.0F);
        if (health <= 0 && !dead) {
			Die();
		}
	}
    public void TakeHit(int damage)
    {
        //health -= damage;
        //enemyRigidBody.AddExplosionForce(200f, hit.point, 200f, 3.0F);
        if (health <= 0 && !dead)
        {
            Die();
        }
    }
    public void slow()
    {
        //to be done
    }

    protected void Die() {
		dead = true;
		GameObject.Destroy (gameObject);
	}
}
