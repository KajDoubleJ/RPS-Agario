using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float Speed;
    public float Range;

    public float mapWidth;
    public float mapHeight;

    public float DistanceBetween;

    private Vector2 wayPoint;

    private float distance;



    // Start is called before the first frame update
    void Start()
    {
        SetNewDestination();
    }

    void Update()
    {
        GameObject target = GameObject.FindWithTag("PlayerTag");
        distance = Vector2.Distance(transform.position, target.transform.position);

        if ((GetComponent<RPSType>().Type == Type.Rock && target.GetComponent<RPSType>().Type == Type.Scissor ||
            GetComponent<RPSType>().Type == Type.Paper && target.GetComponent<RPSType>().Type == Type.Rock ||
            GetComponent<RPSType>().Type == Type.Scissor && target.GetComponent<RPSType>().Type == Type.Paper) && 
            (distance < DistanceBetween))
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoint, Speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, wayPoint) < Range)
            {
                SetNewDestination();
            }
        }
    }

    void SetNewDestination()
    {
        wayPoint = new Vector2(Random.Range(-mapHeight / 2, mapWidth / 2), Random.Range(-mapHeight / 2, mapHeight / 2));
    }
    // Update is called once per frame
    /*
    void Update()
    {
        distance = Vector3.Distance(transform.position, Player.transform.position);
        Vector3 direction = Player.transform.position - transform.position;

        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime);
    }
    */

}
