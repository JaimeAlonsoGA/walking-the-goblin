using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    public int state = 0;
    public Stamina stamina;
    
    void SpeedState(int velocidad, int stateParam)
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && GetComponent<GoblinEnemyInteraction>().isGameOver == false)
        {       
            
            // transform.position += transform.forward * Time.deltaTime * velocidad;
            GetComponent<Rigidbody>().velocity = transform.forward * velocidad;
            state = stateParam;
        }

        if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && GetComponent<GoblinEnemyInteraction>().isGameOver == false)
        {
            // transform.position += transform.forward * Time.deltaTime * -velocidad;
            GetComponent<Rigidbody>().velocity = transform.forward * -velocidad;
            state = stateParam;
        } 
    }

    void RotationState()
    {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && GetComponent<GoblinEnemyInteraction>().isGameOver == false)
        {
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * 300);
            state = 1;
        }
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && GetComponent<GoblinEnemyInteraction>().isGameOver == false)
        {
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * 300);
            state = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        state = 0;
        SpeedState(4, 1);
        RotationState();

        if (state == 1)
        {
            if (Input.GetKey(KeyCode.LeftShift) && stamina.stamina > 1)
            {
                SpeedState(16, 2);
                GetComponent<Animator>().SetInteger("state", 2);
            }
            else
            {
                GetComponent<Animator>().SetInteger("state", 1);
            }
        }
        else
        {
            GetComponent<Animator>().SetInteger("state", 0);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

}
