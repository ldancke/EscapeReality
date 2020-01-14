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
                GameManager.Instance.KeyQuestSolved();
            }
        }
    }
}