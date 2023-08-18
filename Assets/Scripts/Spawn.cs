using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Food;
    public float Speed;

    public float mapWidth;
    public float mapHeight;

    //Prevent spawning part of the food out of the map
    private float fix = 0.3f;
    private float x;
    private float y;

    void Start()
    {
        for(int i = 0; i < 1000; i++)
        {
            SetCoordinates();

            Vector3 Target = new Vector3(x, y, 0);
            Target.z = 0;

            Instantiate(Food, Target, Quaternion.identity);
        }

        //Call the function over and over again
        InvokeRepeating("Generate", 0, Speed);
    }

    void Generate()
    {
        //int x = Random.Range(0, Camera.main.pixelWidth);
        //int y = Random.Range(0, Camera.main.pixelHeight);

        SetCoordinates();

        //Vector3 Target = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
        Vector3 Target = new Vector3(x, y, 0);
        Target.z = 0;

        Instantiate(Food, Target, Quaternion.identity);
    }

    void SetCoordinates()
    {
        x = Random.Range(-1 * mapWidth / 2 + fix, mapWidth / 2 - fix);
        y = Random.Range(-1 * mapHeight / 2 + fix, mapHeight / 2 - fix);
    }
}
