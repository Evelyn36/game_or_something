using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword_attack : MonoBehaviour
{
    public float attack_angle;
    public float attack_cooldown;
    private bool can_attack = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && can_attack)
        {
            attack();
            Debug.Log("attacked");
            gameObject.transform.Rotate(GetComponentInParent<Transform>().position, attack_angle);

        }
    }

    private IEnumerator attack()
    {
        can_attack = false;
        for (int i = 0; i < 10; i++)
        {
            gameObject.transform.Rotate(GetComponentInParent<Transform>().position, attack_angle);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(attack_cooldown);
        can_attack=true;
    }

}
