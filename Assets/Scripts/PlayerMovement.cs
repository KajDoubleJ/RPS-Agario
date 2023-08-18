using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Getting access to Map object
    private MapAttributes mapAttributes;
    [SerializeField] private GameObject map;

    private float mapWidth;
    private float mapHeight;

    // Distance to move current position per call of MoveTowards function
    // https://docs.unity3d.com/ScriptReference/Vector3.MoveTowards.html
    [SerializeField] private float speed = 5;

    // Awake is called when the script instance is being loaded.
    // Awake is always called before any Start functions.
    // https://docs.unity3d.com/ScriptReference/MonoBehaviour.Awake.html
    void Awake()
    {
        // Getting access to Map object attributes
        // Cashuje
        mapAttributes = map.GetComponent<MapAttributes>();
        mapWidth = mapAttributes.mapWidth;
        mapHeight = mapAttributes.mapHeight;
    }

    // Update is called once per frame
    void Update()
    {
        // Initialization the target to move object the point of mouse position
        // Szybciej jest po tagu, powinno byc w awaku, zcashowaæ camerê
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // No change of z position
        target.z = transform.position.z;

        // Checking if object does not go beyond the map
        // Right border
        if (target.x >= mapWidth / 2)
        {
            target.x = mapWidth / 2;
        }
        // Left border
        if (target.x <= -1 * mapWidth / 2)
        {
            target.x = -1 * mapWidth / 2;
        }
        // Upper border
        if (target.y >= mapHeight / 2)
        {
            target.y = mapWidth / 2;
        }
        // Bottom border
        if (target.y <= -1 * mapWidth / 2)
        {
            target.y = -1 * mapWidth / 2;
        }

        // Making sure that object speed is independent of frame rate
        float frameRateSpeed = speed * Time.deltaTime;

        // Moving object from current position to the Target with frameRateSpeed
        transform.position = Vector3.MoveTowards(transform.position, target, frameRateSpeed);
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void IncreaseSpeed(float acceleration)
    {
        speed += acceleration;
    }

    public void DecreaseSpeed(float acceleration)
    {
        speed -= acceleration;
    }
}
