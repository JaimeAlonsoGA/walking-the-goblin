using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GoblinMushroomInteraction : MonoBehaviour
{
    public int mushroomsEated = 0;
    public Mushroom[] mushrooms = new Mushroom[6];

    public SoundManager mushroomInstance;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mushroom")
        {
            Mushroom mushroom = mushrooms.ToList().Find((x) => x == other.gameObject.GetComponent<Mushroom>());
            mushroom.SpanwRandomPosition();
            mushroomsEated++;
            mushroomInstance.PlaySound("event:/Mushroom");
        }
    }
}
