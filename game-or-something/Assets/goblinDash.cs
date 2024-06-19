using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinDash : MonoBehaviour
{


    private bool canDash = true;


    public float dashingPower;
    public float dashingTime;
    public float dashingCooldown;
    public float dashingRange;

    private Rigidbody2D rb;

    private GameObject player;

    private Enemy enemy;
    private float Distance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GetComponent<Enemy>();
    }

   
    void FixedUpdate()
    {
        

        if (player != null)
        {
            Distance = Vector2.Distance(transform.position, player.transform.position);
        }
        
        if (Distance < dashingRange)
        {
            enemy.inrange = true;
            if (canDash)
            {
                Vector2 direction = (player.transform.position - transform.position).normalized;


                StartCoroutine(Dash(direction));
            }
            
        }
        else
        {
            enemy.inrange = false;
        }

    }



    private IEnumerator Dash(Vector2 MInput)
    {

        
        canDash = false;
                
        for (int i = 0; i < 10; i++)
        {


            rb.velocity = MInput * dashingPower;

            yield return new WaitForSeconds(dashingTime / 10);
        }


        
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
