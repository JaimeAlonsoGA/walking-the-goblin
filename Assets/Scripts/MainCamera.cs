using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCamera : MonoBehaviour
{
    public GameOver gameOver;

    void Update()
    {
        if(GetComponentInParent<GoblinEnemyInteraction>().isGameOver == true)
        {
            gameOver.GameOverScreen();
        }
    }
}
