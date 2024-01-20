using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTorwards : MonoBehaviour
{
    public GameObject goblin;
    public float speed; 
    public float speedRotate;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = goblin.transform.position - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, goblin.transform.position, speed * Time.deltaTime);
        Quaternion roation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, roation, speed * Time.deltaTime);
    }
}
