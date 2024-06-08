using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    private Transform player;
    private BoxCollider2D hitbox;
    private Rigidbody2D prb;
    public float movementSpeed;
    private float speed;

    private bool canDash = true;
    private bool isDashing;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;

    private bool Right;
    private bool Left;
    private bool Up;
    private bool Down;

    [SerializeField] private TrailRenderer tr;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
        hitbox = GetComponent<BoxCollider2D>();
        prb = GetComponent<Rigidbody2D>();
        speed = movementSpeed / 100;
    }

    void Update()
    {
        if (isDashing)
        {
            return;
        }

        if (Input.GetMouseButtonDown(1) && canDash)
        {
            
            StartCoroutine(Dash());
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!(isDashing))
        {
            if (Input.GetKey(KeyCode.A))
            {
                player.transform.position = new Vector2(player.transform.position.x - speed, player.transform.position.y);
                Left = true;
            }
            else
            {
                Left = false;
            }

            if (Input.GetKey(KeyCode.D))
            {
                player.transform.position = new Vector2(player.transform.position.x + speed, player.transform.position.y);
                Right = true;
            }
            else
            {
                Right = false;
            }


            if (Input.GetKey(KeyCode.W))
            {
                player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + speed);
                Up = true;
            }
            else
            {
                Up = false;
            }


            if (Input.GetKey(KeyCode.S))
            {
                player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - speed);
                Down = true;
            }
            else
            {
                Down = false;
            }
        }

        

    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        tr.emitting = true;
        for (int i = 0; i < 10; i++)
        {
            if (Right)
            {
                player.transform.position = new Vector2(player.transform.position.x + dashingPower, player.transform.position.y);
            }
            else if (Left)
            {
                player.transform.position = new Vector2(player.transform.position.x - dashingPower, player.transform.position.y);
            }

            if (Up)
            {
                player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + dashingPower);
            }
            else if (Down)
            {
                player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - dashingPower);
            }
            
            yield return new WaitForSeconds(dashingTime / 10);
        }
        
        isDashing = false;
        tr.emitting = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
