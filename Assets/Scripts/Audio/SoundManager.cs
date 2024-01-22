using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using FMOD;
using UnityEngine.UIElements;
using UnityEngine.Rendering;

public class SoundManager : MonoBehaviour
{
    // public static SoundManager Instance {get; private set; }
    private FMOD.Studio.EventInstance walkInstance;
    private FMOD.Studio.EventInstance runInstance;
    private FMOD.Studio.EventInstance goblinGroanInstance;
    private FMOD.Studio.EventInstance ambienceInstance;

    // [field: SerializeField] public EventReference GameOverSFX {get; private set; }

    void Start()
    {
        walkInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Goblin/Goblin Footsteps Walk");
        runInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Goblin/Goblin Footsteps Run");
        goblinGroanInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Goblin/Goblin Groan");
        ambienceInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Ambience");

        FMODUnity.RuntimeManager.AttachInstanceToGameObject(walkInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(runInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(goblinGroanInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(ambienceInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
        ambienceInstance.start();
        goblinGroanInstance.start();
    }

    void Update()
    {
        if (GetComponent<GoblinEnemyInteraction>().isGameOver == true)
        {
            goblinGroanInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            ambienceInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            PLAYBACK_STATE playbackState;
            goblinGroanInstance.getPlaybackState(out playbackState);
            if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
            {
                walkInstance.start();
            }
        }
        /*         else
                {
                    walkInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                }
         */
    }


}
