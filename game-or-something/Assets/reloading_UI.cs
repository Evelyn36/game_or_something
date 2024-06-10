using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class reloading_UI : MonoBehaviour
{
    private TMP_Text tmp;
    private shooting shooting;


    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        shooting = FindObjectOfType<shooting>();
    }
    void Update()
    {
        
        if (shooting.reloading == true)
        {
            tmp.text = "Reloading";



        }
        else
        {
            tmp.text = shooting.bullets.ToString();
        }
    }
}
