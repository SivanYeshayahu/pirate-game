using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{
float moveSpeed=7f;
	Rigidbody rb;
	GameObject target;
	Vector2 moveDirection;

	
	
	void Start()
    {
		rb = GetComponent<Rigidbody>();
		target = GameObject.FindWithTag("Skeleton");
		moveDirection = (target.transform.position-transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
		Destroy(gameObject, 3f);


	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Skeleton")
        {
			Destroy(gameObject);
        }
    }
    }//END CLASS

/*	public GameObject projectile;
	public Vector2 velocity;
	bool canShoot = true;
	public Vector2 offset = new Vector2(0.4f, 0.1f);
	public float cooldown = 1f;


	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetKeyDown(KeyCode.Space) && canShoot)
		{

			GameObject go = (GameObject)Instantiate(projectile, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);

			go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * transform.localScale.x, velocity.y);


			StartCoroutine(CanShoot());

			GetComponent<Animator>().SetTrigger("shoot");

		}


	}


	IEnumerator CanShoot()
	{
		canShoot = false;
		yield return new WaitForSeconds(cooldown);
		canShoot = true;


	}*/

