using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eat : MonoBehaviour
{
    public string Tag;
    public Text Letters;
    public float Increase;
    public float CameraZoom;
    public float CameraZoomSpeed;

    int Score;

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == Tag)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, Camera.main.orthographicSize + CameraZoom, CameraZoomSpeed);
            transform.localScale += new Vector3(Increase, Increase, Increase);
            Destroy(other.gameObject);


            Score += 10;
            Letters.text = "SCORE: " + Score;
        }
    }
}
