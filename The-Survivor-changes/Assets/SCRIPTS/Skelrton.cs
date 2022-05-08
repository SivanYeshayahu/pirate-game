using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skelrton : MonoBehaviour
{
    public float speed=-2;
  
   


    // Update is called once per frame
    public void Update()
    {
        //make skelrton move left
          transform.Translate(-0.5f * Time.deltaTime * speed,0, 0);
            transform.localScale = new Vector2(4.4159f, 4.4159f);
    }
    private bool isGrounded()
    {
        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
    }
    
        void dead()
        {
           // Instantiate(deadExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {

            if (other.tag == "Grenade")
            {
                dead();
            }

        /*
        Player player = GetComponent<Player>();
        if ((other.tag == "Pistol") && )
        {
            dead();
        }
        */
    }

}//end class