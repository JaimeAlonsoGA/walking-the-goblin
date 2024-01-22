using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    private FMOD.Studio.EventInstance tensionStrings;
    public GoblinEnemyInteraction goblinEnemyInteraction;

    void Start()
    {
        tensionStrings = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Tension SFX");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(tensionStrings, GetComponent<Transform>(), GetComponent<Rigidbody>());

        tensionStrings.start();
    }

    // Update is called once per frame
    void Update()
    {
        if(goblinEnemyInteraction.isGameOver == true)
        {
            tensionStrings.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Game Over Impact", transform.position);
        }
    }
}
