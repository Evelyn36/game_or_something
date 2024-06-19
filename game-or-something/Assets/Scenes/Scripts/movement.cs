using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{


    private Rigidbody2D prb;
    public float MaxmovementSpeed;
    private float Maxspeed;
    public float acceleration;
    public float deacceleration;
    public float current_speedx;
    public float current_speedy;
    public float current_speed;
    public float current_forward_direction = 1;

    private float vectorx;
    private float vectory;

    private bool canDash = true;
    public bool isDashing;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;


    public float AttackingMovementPercentage;

    private Vector2 moveInput;

    public bool isAttacking = false;

    [SerializeField] private TrailRenderer tr;



    // Start is called before the first frame update
    void Start()
    {

        prb = GetComponent<Rigidbody2D>();
        Maxspeed = MaxmovementSpeed / 100;
    }

    void Update()
    {
        if (isDashing)
        {
            return;
        }

        if (isAttacking)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) && canDash && !isAttacking)
        {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");

            moveInput.Normalize();

            prb.velocity = moveInput * Maxspeed;
            StartCoroutine(Dash(moveInput));
        }

        Vector3 targetDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = (Mathf.Atan2(targetDir.y, targetDir.x)* Mathf.Rad2Deg) - 90f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }


    public void Move(Vector2 movementVector)
    {
        moveInput = movementVector;
        CalulateSpeed(movementVector);
        
    }

    private void CalulateSpeed(Vector2 movementVector)
    {
        if (Mathf.Abs(moveInput.y) > 0)
        {
            current_speedy += acceleration * Time.deltaTime;
        }
        else
        {
            current_speedy -= deacceleration * Time.deltaTime;
            
        }


        current_speedy = Mathf.Clamp(current_speedy, 0, Maxspeed);
        if (Mathf.Abs(moveInput.x) > 0)
        {
            current_speedx += acceleration * Time.deltaTime;
        }
        else
        {
            current_speedx -= deacceleration * Time.deltaTime;
            
        }


        current_speedx = Mathf.Clamp(current_speedx, 0, Maxspeed);

        current_speed = Math.Max(current_speedx, current_speedy);
    }

    void FixedUpdate()
    {

        

        if (!(isDashing) && !isAttacking)
        {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");

            moveInput.Normalize();
            Move(moveInput);

           

            
            if (moveInput.x == 0 && moveInput.y == 0)
            {
                if (prb.velocity.x > 0)
                {
                    vectorx = current_speed;
                } else if (prb.velocity.x < 0)
                {
                    vectorx = -current_speed;
                }
                else
                {
                    vectorx = 0;
                }

                if (prb.velocity.y > 0)
                {
                    vectory = current_speed;
                }
                else if (prb.velocity.y < 0)
                {
                    vectory = -current_speed;
                }
                else
                {
                    vectory = 0;
                }
                prb.velocity = new Vector2(vectorx, vectory);
            }
            else
            {
                prb.velocity = new Vector2(moveInput.x * current_speed, moveInput.y * current_speed);
            }
            
         
            
        }


        if (isAttacking)
        {


            prb.velocity = prb.velocity * AttackingMovementPercentage;




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
