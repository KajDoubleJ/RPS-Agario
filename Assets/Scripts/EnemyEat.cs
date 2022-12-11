using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEat : MonoBehaviour
{
    public float Increase;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Food")
        {
            transform.localScale += new Vector3(Increase, Increase, Increase);
            Destroy(other.gameObject);
        }
    }
}
