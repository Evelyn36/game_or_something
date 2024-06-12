using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ranged_goblin_attack : MonoBehaviour
{
    [SerializeField] private Enemy enemy;

    [SerializeField] private GameObject bullet;

    [SerializeField] private GameObject player;

    public float range = 1;
    public float attack_cooldown = 3;

    private bool can_shoot = true;

    private void FixedUpdate()
    {

        Vector2 playerposition = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 goblinposition = new Vector2(transform.position.x, transform.position.y);

        float Distance = Vector2.Distance(playerposition, goblinposition);
        Debug.Log(Distance < range);

        if (enemy.target && Distance < range && can_shoot)
        {
            Debug.Log("yes");
            enemy.inrange = true;
            Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation, null);
            StartCoroutine(cooldown());
        }
        else if(Distance >= range)
        {
            enemy.inrange = false;
        }

        
        
    }

    private IEnumerator cooldown()
    {
        can_shoot = false;
        yield return new WaitForSeconds(attack_cooldown);
        can_shoot = true;

    }

}
