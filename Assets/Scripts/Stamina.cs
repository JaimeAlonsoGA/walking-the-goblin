using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public GoblinMushroomInteraction goblinMushroomInteraction;
    public float stamina = 100;
    float resetTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && stamina >= 1)
        {
            stamina -= Time.deltaTime * 10;
        }
        else if (stamina < 1)
        {
            resetTimer += Time.deltaTime;
            if (resetTimer > 1)
            {
                resetTimer = 0;
                stamina = 1;
            }
        }
        else
        {
            stamina = Mathf.Clamp(stamina + Time.deltaTime * 10, 0, 100);
        }

        GetComponent<Slider>().value = stamina / 100f;
    }
}
