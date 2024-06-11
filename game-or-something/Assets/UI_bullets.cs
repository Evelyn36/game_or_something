using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_bullets : MonoBehaviour
{
    private RectTransform image;
    private shooting shooting;

    // Start is called before the first frame update
    void Awake()
    {

        image = GetComponent<RectTransform>();
        shooting = FindObjectOfType<shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        image.sizeDelta = new Vector2(70.68f, shooting.bullets * 66);

    }
}