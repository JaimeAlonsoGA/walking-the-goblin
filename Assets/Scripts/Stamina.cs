using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public GoblinMushroomInteraction goblinMushroomInteraction;
    float maxStamina = 20;
    public float stamina = 20;
    float resetTimer = 0;

    Image fill;
    RectTransform background;
    RectTransform fillArea;

    // Start is called before the first frame update
    void Start()
    {
        fill = GetComponentsInChildren<Image>()[1];
        background = GetComponentsInChildren<RectTransform>()[1];
        fillArea = GetComponentsInChildren<RectTransform>()[2];
    }

    // Update is called once per frame
    void Update()
    {
        maxStamina = 20 + goblinMushroomInteraction.mushroomsEated * 5;
        background.offsetMax = new Vector2(goblinMushroomInteraction.mushroomsEated * 5 - 120f, background.offsetMax.y);
        fillArea.offsetMax = new Vector2(goblinMushroomInteraction.mushroomsEated * 5 - 126.08f, fillArea.offsetMax.y);

        if (Input.GetKey(KeyCode.LeftShift) && stamina >= 1)
        {
            stamina -= Time.deltaTime * 10;
        }
        else if (stamina < 1)
        {
            resetTimer += Time.deltaTime;
            if (resetTimer > 3)
            {
                resetTimer = 0;
                stamina = 1;
            }
        }
        else
        {
            stamina = Mathf.Clamp(stamina + Time.deltaTime * 10, 0, maxStamina);
        }

        fill.color = Color.Lerp(Color.red, Color.green, stamina / maxStamina);

        GetComponent<Slider>().value = stamina / maxStamina;
    }
}
