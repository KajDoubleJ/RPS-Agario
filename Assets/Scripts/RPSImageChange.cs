using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPSImageChange : MonoBehaviour
{
    public GameObject Image;

    void Start()
    {
        if (GetComponent<RPSType>().Type == Type.Rock)
        {
            Image.GetComponent<SpriteRenderer>().sprite = Image.GetComponent<RPSImage>().Images[0];
        }
        if (GetComponent<RPSType>().Type == Type.Paper)
        {
            Image.GetComponent<SpriteRenderer>().sprite = Image.GetComponent<RPSImage>().Images[1];
        }
        if (GetComponent<RPSType>().Type == Type.Scissor)
        {
            Image.GetComponent<SpriteRenderer>().sprite = Image.GetComponent<RPSImage>().Images[2];
        }
    }
}
