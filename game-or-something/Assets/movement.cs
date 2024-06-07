using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    private Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            player.AddForce(new Vector2(-200, 0));

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            player.AddForce(new Vector2(200, 0));
        }
    }
}
