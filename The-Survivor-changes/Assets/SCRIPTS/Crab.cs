using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{

    public float speed = -10;




    // Update is called once per frame
    public void Update()
    {
        //make skelrton move left
        transform.Translate( 0.2f*Time.deltaTime * speed, 0, 0);
        transform.localScale = new Vector2(1.7558f, 1.7558f);
        if(transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
    }
 

    public void Hurt()
    {
        Destroy(this.gameObject);
    }
   
    }
