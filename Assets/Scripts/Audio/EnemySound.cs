using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using FMODUnity;
using FMOD.Studio;
using FMOD;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    private FMOD.Studio.EventInstance tensionStrings;
    // private FMOD.Studio.EventInstance trollFootsteps;
    public GoblinEnemyInteraction goblinEnemyInteraction;
    void PlaySound(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);
    }
    void Start()
    {
        tensionStrings = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Tension SFX");
        // trollFootsteps = FMODUnity.RuntimeManager.CreateInstance("event:/Troll/footsteps");

        FMODUnity.RuntimeManager.AttachInstanceToGameObject(tensionStrings, GetComponent<Transform>(), GetComponent<Rigidbody>());
        // FMODUnity.RuntimeManager.AttachInstanceToGameObject(trollFootsteps, GetComponent<Transform>(), GetComponent<Rigidbody>());

        // trollFootsteps.start();
        tensionStrings.start();

        // PLAYBACK_STATE playbackState;
        // trollFootsteps.getPlaybackState(out playbackState);
        // if (playbackState.Equals(PLAYBACK_STATE.PLAYING))
        // {
        //     print("troll footsteps playing");
        // }

    }

    // Update is called once per frame
    void Update()
    {
        if (goblinEnemyInteraction.isGameOver == true)
        {
            tensionStrings.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            // trollFootsteps.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
}
