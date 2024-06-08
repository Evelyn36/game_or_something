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

    private Vector2 moveInput;

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
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");

            moveInput.Normalize();

            prb.velocity = moveInput * speed;
            StartCoroutine(Dash(moveInput));
        }
        
    }


    void FixedUpdate()
    {
        if (!(isDashing))
        {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");

            moveInput.Normalize();

            prb.velocity = moveInput * speed;
         
            
        }

        

    }
    private IEnumerator Dash(Vector2 MInput)
    {
        canDash = false;
        isDashing = true;
        tr.emitting = true;
        for (int i = 0; i < 10; i++)
        {


            prb.velocity = MInput * dashingPower;

            yield return new WaitForSeconds(dashingTime / 10);
        }
        
        isDashing = false;
        tr.emitting = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
