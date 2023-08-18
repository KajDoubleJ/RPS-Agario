using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private string scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>().text;
        scoreText = "SCORE:" + 99;
        GetComponent<Text>().text = scoreText;
    }
}
