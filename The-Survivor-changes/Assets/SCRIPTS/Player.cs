using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject deadExplosion,grenade;
    public float speedX;
    bool facingRight = true;
    float speed;
    Animator anim;
    Rigidbody2D rb;
    private float dirX;
    private Vector3 localScale;

  
 

    // Rigidbody2D myBody;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        speedX = 5f;
        localScale = transform.localScale;
       // myBody = this.GetComponent();

    }

    void Update()
    {
        MovePlayer(speed);
        dirX = Input.GetAxisRaw("Horizontal") * speedX;

        //left
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            speed = -speedX;
            anim.SetBool("isWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            speed = 0;
            anim.SetBool("isWalking", false);
        }
        //right
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            speed = speedX;
            anim.SetBool("isWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            speed = 0;
            anim.SetBool("isWalking", false);
        }
        //jump
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * 700f);
            anim.SetBool("isJumping", true);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            speed = 0;
            anim.SetBool("isJumping", false);
        }
        //hit
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("isAttacking", true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("isAttacking", false);
        }

        checkIfTimeToSaber();

    }
        private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    //face right/left
    private void LateUpdate()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;
        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x = localScale.x * -1;

        transform.localScale = localScale;
    }

    void MovePlayer(float playerSpeed)
    {
        rb.velocity = new Vector3(speed, rb.velocity.y, 0);
    }

    //player on the ground
    private bool isGrounded()
    {
        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
    }
    /*****************/

    void dead()
    {
        Instantiate(deadExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("coinn"))
        {
            Destroy(other.gameObject);
            Score.instance.changeScore(1);
        }
        if (other.tag == "flame")
        {

            dead();
     
        }
        if (other.tag == "FrontDetect")
        {
            Destroy(this.gameObject);
        }

    }



    void checkIfTimeToSaber()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(grenade, transform.position, Quaternion.identity);
    }



}
