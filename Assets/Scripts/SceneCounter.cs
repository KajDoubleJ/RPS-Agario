using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCounter : MonoBehaviour
{

    private float timer = 0.0f;
    private int seconds = 0;

    void Update()
    {
        timer += Time.deltaTime;
        seconds = (int)(timer % 60);

        if (seconds >= 3)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
