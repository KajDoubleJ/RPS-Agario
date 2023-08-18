using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System; //dodane

public class RPSType : MonoBehaviour
{
    public TMP_Text Text;
    public Type Type;

    public bool immortality;

    void Awake()
    {
        Type = (Type)Enum.GetValues(typeof(Type)).GetValue(UnityEngine.Random.Range(0, 3));

        //zmiana na UntyEngine.Random
        switch (UnityEngine.Random.Range(0, 3))
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

// Lepiej playerType
public enum Type 
{
    Rock,
    Paper,
    Scissor
}