using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using FMOD;
using UnityEngine.UIElements;

public class SoundManager : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;

    void Start()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Goblin/Goblin Footsteps Walk");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(instance, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }

    //set SoundManager to be a singleton class
    // public static SoundManager instance { get; private set; }

    //play oneshot sounds
    public void PlayOneShot(EventReference sound, Vector3 worldPosition)
    {
        RuntimeManager.PlayOneShot(sound, worldPosition);
    }

    //play sounds from FMOD Studio timeline (loops)
    // public EventInstance CreateEventInstance(EventReference eventReference)
    // {
    //     EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
    //     return eventInstance;
    // }

    
    // public void GoblinFootstepsWalk()
    // {
    //     goblinFootstepsWalk = instance.CreateEventInstance(FMODevents.instance.goblinFootstepsWalk);
    //     goblinFootstepsWalk.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject.transform));
    //     goblinFootstepsWalk.start();
    // }
    
    void Update()
    {
        // start footsteps event if the player is moving
        if (GetComponent<MoveCharacter>().state == 1)
        {
            // get the playback state
            PLAYBACK_STATE playbackState;
            instance.getPlaybackState(out playbackState);
            if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
            {
                instance.start();
            }
        }
        // otherwise, stop the footsteps event
        else
        {
            // goblinFootstepsWalk.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }


}
