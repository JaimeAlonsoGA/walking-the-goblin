using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GoblinMushroomInteraction : MonoBehaviour
{
    public int mushroomsEated = 0;
    public Mushroom[] mushrooms = new Mushroom[6];

    // Start is called before the first frame update
    void Start()
    {
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mushroom")
        {
            Mushroom mushroom = mushrooms.ToList().Find((x) => x == other.gameObject.GetComponent<Mushroom>());
            mushroom.SpanwRandomPosition();
            mushroomsEated++;
            print(mushroom.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
