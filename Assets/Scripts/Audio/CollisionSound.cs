using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{

    void OnCollisionEnter(Collision col)
    {
        if (col.relativeVelocity.magnitude > 1)
            GetComponent<AudioSource>().Play();

       Debug.Log(col.collider.name);
    }

}
