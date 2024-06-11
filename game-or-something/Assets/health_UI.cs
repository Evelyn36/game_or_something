using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_UI : MonoBehaviour
{

    [SerializeField] private GameObject player;

    [SerializeField] private RectTransform RTrans;

    private Health_system Health;


    // Start is called before the first frame update
    void Start()
    {
        Health = player.GetComponent<Health_system>();
    }

    // Update is called once per frame
    void Update()
    {

        RTrans.sizeDelta = new Vector2(10 * Health.CurHealth, 100);


    }
}
