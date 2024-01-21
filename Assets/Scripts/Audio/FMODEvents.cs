using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODevents : MonoBehaviour
{
    //Create a visual field in Unity editor for each sound
    [field: Header("Game Over SFX")]
    [field: SerializeField] public EventReference gameOverSound {get; private set; }

    [field: Header("Goblin walk")]
    [field: SerializeField] public EventReference goblinFootstepsWalk {get; private set; }


    //set FMODEvent to be a singleton class
    public static FMODevents instance {get; private set; }
    
    private void Awake()
    {
        if ( instance != null)
        {
            Debug.LogError("Found more than one FMOD Events instance in the scene");
        }
        instance = this;
    }
}
