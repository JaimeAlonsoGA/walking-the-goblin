using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Reset);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
