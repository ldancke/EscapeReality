using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeReality 
{
    public class KeyTriggerCollider : MonoBehaviour
    {
        public GameObject door;

        public void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Key")) 
            {
                door.transform.eulerAngles = new Vector3(0f, -65f, 0f);
            }
        }

        /*IEnumerator OpenDoor(Collider key) {
            key.transform.position = new Vector3(-1.464f, 1.018f, 0.022f);
            key.transform.eulerAngles = new Vector3(-2.882f, 97.437f, 118.28f);
            
            yield return new WaitForSecondsRealtime(2);

            door.transform.eulerAngles = new Vector3(0f, -65f, 0f);
        }*/
    }
}