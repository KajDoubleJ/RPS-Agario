using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Eat : MonoBehaviour
{
    public string Tag;
    public Text Letters;
    public float IncreaseAfterFood;
    public float IncreaseAfterEnemy;
    public float CameraZoom;
    public float CameraZoomSpeed;

    int Score;
    private Collider otherO;


    //Cannot eat larger ball right after eating smaller one while touching both at the same time
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Food")
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, Camera.main.orthographicSize + CameraZoom, CameraZoomSpeed);
            transform.localScale += new Vector3(IncreaseAfterFood, IncreaseAfterFood, IncreaseAfterFood);
            Destroy(other.gameObject);


            Score += 10;
            Letters.text = "SCORE: " + Score;
        }
        if (other.gameObject.tag == "Enemy")
        {
            if ((GetComponent<RPSType>().Type == Type.Rock && other.GetComponent<RPSType>().Type == Type.Scissor ||
                GetComponent<RPSType>().Type == Type.Paper && other.GetComponent<RPSType>().Type == Type.Rock ||
                GetComponent<RPSType>().Type == Type.Scissor && other.GetComponent<RPSType>().Type == Type.Paper) &&
                transform.localScale.x > other.transform.localScale.x)
            {
                Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, Camera.main.orthographicSize + CameraZoom, CameraZoomSpeed);
                transform.localScale += new Vector3(IncreaseAfterEnemy, IncreaseAfterEnemy, IncreaseAfterEnemy);
                Destroy(other.gameObject);


                Score += 100;
                Letters.text = "SCORE: " + Score;
            }
            if ((GetComponent<RPSType>().Type == Type.Rock && other.GetComponent<RPSType>().Type == Type.Paper ||
                GetComponent<RPSType>().Type == Type.Paper && other.GetComponent<RPSType>().Type == Type.Scissor ||
                GetComponent<RPSType>().Type == Type.Scissor && other.GetComponent<RPSType>().Type == Type.Rock) &&
                transform.localScale.x < other.transform.localScale.x)
            {
                Debug.Log(transform.localScale.x);
                Debug.Log(other.transform.localScale.x);
                Invoke("KillPlayer", 0.15f);
            }
        }
    }

    private void KillPlayer()
    {
        SceneManager.LoadScene(0);
    }
}
