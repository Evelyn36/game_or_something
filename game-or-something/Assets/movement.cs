using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    private Transform player;
    private BoxCollider2D hitbox;
    public float movementSpeed;
    private float speed;

    private bool colliding;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
        hitbox = GetComponent<BoxCollider2D>();
        speed = movementSpeed / 100;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        colliding = true;
        Debug.Log("hello");
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        colliding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!(colliding))
        {

            if (Input.GetKey(KeyCode.A))
            {
                player.transform.position = new Vector2(player.transform.position.x - speed, player.transform.position.y);

            }
            if (Input.GetKey(KeyCode.D))
            {
                player.transform.position = new Vector2(player.transform.position.x + speed, player.transform.position.y);
            }

            if (Input.GetKey(KeyCode.W))
            {
                player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + speed);

            }
            if (Input.GetKey(KeyCode.S))
            {
                player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - speed);
            }

        }

    }
}
