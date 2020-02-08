using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * A class which plays the assigned AudioClip on collision.
 */
public class CollisionSound : MonoBehaviour
{
    /**
     * Is called when the collider / rigidbody has begun touching another collider / rigidbody.
     * 
     * Plays assigned AudioClip.
     * 
     * @param col Describes the collision, passed by the Collision Class.
     */
    void OnCollisionEnter(Collision col)
    {
        if (col.relativeVelocity.magnitude > 1)
            GetComponent<AudioSource>().Play();

       Debug.Log(col.collider.name);
    }

}
