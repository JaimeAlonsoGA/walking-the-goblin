using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public void SpanwRandomPosition()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-45, 46), 0, Random.Range(-45, 46));
        transform.position = randomPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        SpanwRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
