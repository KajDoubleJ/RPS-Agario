using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;

    public float mapWidth;
    public float mapHeight;

    void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            float x = Random.Range(-1 * mapWidth / 2, mapWidth / 2);
            float y = Random.Range(-1 * mapHeight / 2, mapHeight / 2);

            Vector3 Target = new Vector3(x, y, 0);
            Target.z = 0;

            Instantiate(Enemy, Target, Quaternion.identity);
        }
    }
}