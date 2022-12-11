using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RPSType : MonoBehaviour
{
    public TMP_Text Text;
    public Type Type;

    void Awake()
    {
        switch (Random.Range(0, 3))
        {
            case 0:
                Type = Type.Rock;
                //Text.text = "Rock";
                break;
            case 1:
                Type = Type.Paper;
                //Text.text = "Paper";
                break;
            case 2:
                Type = Type.Scissor;
                //Text.text = "Scissor";
                break;
        }
    }
}

public enum Type 
{
    Rock,
    Paper,
    Scissor
}