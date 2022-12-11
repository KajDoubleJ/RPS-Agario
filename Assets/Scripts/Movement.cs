using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10;

    public float mapWidth;
    public float mapHeight;

    // Update is called once per frame
    void Update()
    {
        Vector3 Target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Target.z = transform.position.z;

        if (Target.x >= mapWidth / 2)
        {
            Target.x = mapWidth / 2;
        }
        if (Target.x <= -1 * mapWidth / 2)
        {
            Target.x = -1 * mapWidth / 2;
        }
        if (Target.y >= mapHeight / 2)
        {
            Target.y = mapWidth / 2;
        }
        if (Target.y <= -1 * mapWidth / 2)
        {
            Target.y = -1 * mapWidth / 2;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, Target, speed * Time.deltaTime);
        
    }
}
