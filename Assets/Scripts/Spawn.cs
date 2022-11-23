using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Food;
    public float Speed;

    void Start()
    {
        for(int i = 0; i < 1000; i++)
        {
            float x = Random.Range(-52f, 52f);
            float y = Random.Range(-40f, 40f);

            Vector3 Target = new Vector3(x, y, 0);
            Target.z = 0;

            Instantiate(Food, Target, Quaternion.identity);
        }

        //Call the function over and over again
        InvokeRepeating("Generate", 0, Speed);
    }

    void Generate()
    {
        int x = Random.Range(0, Camera.main.pixelWidth);
        int y = Random.Range(0, Camera.main.pixelHeight);

        Vector3 Target = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
        Target.z = 0;

        Instantiate(Food, Target, Quaternion.identity);
    }
}
