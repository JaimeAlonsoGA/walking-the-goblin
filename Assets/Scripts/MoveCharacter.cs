using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    int state = 0;
    public Stamina stamina;

    // Start is called before the first frame update
    void Start()
    {
    }

    void SpeedState(int velocidad, int stateParam)
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * Time.deltaTime * velocidad;
            state = stateParam;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += transform.forward * Time.deltaTime * -velocidad;
            state = stateParam;
        }
    }

    void RotationState()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * 300);
            state = 1;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * 300);
            state = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        state = 0;
        SpeedState(10, 1);
        RotationState();

        if (state == 1)
        {
            if (Input.GetKey(KeyCode.LeftShift) && stamina.stamina > 1)
            {
                SpeedState(10, 2);
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
        }
    }
}
