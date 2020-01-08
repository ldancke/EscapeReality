using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeReality 
{
    public class KeyTriggerCollider : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Key")) 
            {
                var door = GameObject.Find("Door");

                if (door != null)
                {
                    door.transform.eulerAngles = new Vector3(0f, -65f, 0f);
                }
            }
        }
    }
}