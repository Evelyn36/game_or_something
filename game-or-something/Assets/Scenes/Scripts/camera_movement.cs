using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{
    [SerializeField] private GameObject player;

    void Update()
    {
        transform.position = new Vector3(player.GetComponentInParent<Transform>().position.x, player.GetComponentInParent<Transform>().position.y, -10);
    }
}
