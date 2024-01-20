using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTorwards : MonoBehaviour
{
    public GameObject goblin;
    public float speed; 



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, goblin.transform.position, speed);
    }
}
