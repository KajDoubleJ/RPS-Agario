using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerEat : MonoBehaviour
{
    public string Tag;
    public Text Letters;
    public float IncreaseAfterFood;
    public float IncreaseAfterEnemy;
    public float CameraZoom;
    public float CameraZoomSpeed;
    [SerializeField] private int pointsAfterEatFood = 10;
    [SerializeField] private int pointsAfterEatEnemy = 100;

    int score = 0;
    private Collider otherO;

    private Type playerType;
    private bool playerIsImmortal;

    // Start is called before the first frame update
    void Start()
    {
        playerType = GetComponent<RPSType>().Type;
    }

    // Cannot eat larger ball right after eating smaller one while touching both at the same time
    void OnTriggerEnter(Collider other)
    {
        float cameraOrthographicSize = Camera.main.orthographicSize;

        // mozna sprawdzac przez jedzenie, a nie przez gracza
        if (other.gameObject.tag == "Food")
        {
            Grow(cameraOrthographicSize, IncreaseAfterFood);
            Destroy(other.gameObject);

            score += pointsAfterEatFood;
            Letters.text = "SCORE: " + score;
        }

        if (other.gameObject.tag == "Enemy")
        {
            Type enemyType = other.GetComponent<RPSType>().Type;
            bool enemyIsImmortal = other.GetComponent<RPSType>().immortality;
            playerIsImmortal = GetComponent<RPSType>().immortality;

            if ((playerType == Type.Rock && enemyType == Type.Scissor ||
                playerType == Type.Paper && enemyType == Type.Rock && !enemyIsImmortal ||
                playerType == Type.Scissor && enemyType == Type.Paper) &&
                transform.localScale.x > other.transform.localScale.x)
            {
                Grow(cameraOrthographicSize, IncreaseAfterEnemy);
                Destroy(other.gameObject);

                score += pointsAfterEatEnemy;
                Letters.text = "SCORE: " + score;
            }
            if ((playerType == Type.Rock && enemyType == Type.Paper && !playerIsImmortal ||
                playerType == Type.Paper && enemyType == Type.Scissor ||
                playerType == Type.Scissor && enemyType == Type.Rock) &&
                transform.localScale.x < other.transform.localScale.x)
            {
                Invoke("KillPlayer", 0.15f);
            }
        }

        if (score >= 1500)
        {
            SceneManager.LoadScene("Win");
        }
    }

    // Co-rutyna
    private void KillPlayer()
    {
        SceneManager.LoadScene("GameOver");
    }

    private void Grow(float cameraOrthographicSize, float IncreaseAfter)
    {
        Camera.main.orthographicSize = Mathf.Lerp(cameraOrthographicSize, cameraOrthographicSize + CameraZoom, CameraZoomSpeed);
        transform.localScale += new Vector3(IncreaseAfter, IncreaseAfter, IncreaseAfter);
    }
}
