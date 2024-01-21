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
        speed += Time.deltaTime * 0.1f;

        Vector3 direction = goblin.transform.position - transform.position;
        transform.position = (Vector3.Distance(transform.position, goblin.transform.position) > 5) ? Vector3.MoveTowards(transform.position, goblin.transform.position, speed * Time.deltaTime) : transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
