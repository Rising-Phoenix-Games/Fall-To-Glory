using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testEnemyMage : MonoBehaviour {

	Animator testEnemyMageAnim;
	public int maxHealth = 20;
	public int health;
	public float testEnemyMageSpeed = 3f;
	public GameObject target;
	public float maxRange;
  public float minRange;
	int testEnemyMageDirection;
	float position1;
	float position2;
	public GameObject fireballPrefab;
	public float fireRate = 0.5F;
  private float nextFire = 0.0F;

	// Use this for initialization
	void Start () {
		testEnemyMageAnim = GetComponent<Animator>();
		target = GameObject.FindWithTag("Player");
		health = maxHealth;
	}


	void dealDamage(int damage) {
		health -= damage;
		Debug.Log("weapon did damage");
	}

	void movement(GameObject target, float minRange, float maxRange) {
		float originalEnemyPosition = transform.position.x;
		if ((Vector2.Distance(transform.position, target.transform.position)<maxRange)&&(Vector2.Distance(transform.position, target.transform.position)>minRange)) {
			transform.position = Vector2.MoveTowards(transform.position,target.transform.position, testEnemyMageSpeed*Time.deltaTime);
				if (((transform.position.x)-originalEnemyPosition)>0) {
					testEnemyMageDirection = 1;
				}
				if (((transform.position.x)-originalEnemyPosition)<0) {
					testEnemyMageDirection = -1;
				}
			}
		testEnemyMageAnim.SetInteger("testEnemyMageFacing", testEnemyMageDirection);
	}

	void death(int health) {
		if (health <= 0) {
			Destroy(this.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		//Below is for movement
	    movement(target, minRange, maxRange);
		//above is for movement

			death(health);

		//below is for casting fireball at the player

			if ((Vector2.Distance(transform.position, target.transform.position)<minRange)&&(Time.time > nextFire)) {
				nextFire = Time.time + fireRate;

				Vector2 heading = target.transform.position - this.transform.position;

				Vector2 direction = heading / heading.magnitude;

				GameObject fireballCopy = Instantiate(fireballPrefab, (Vector2)transform.position, Quaternion.LookRotation(new Vector3 (0, 0, ((target.transform.position.y - transform.position.y)/(target.transform.position.x - transform.position.x)))));

				fireballCopy.GetComponent<enemyFireball>().direction = direction;
			}
		//above is for casting fireball at the player
		}
}
