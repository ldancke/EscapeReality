using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeReality 
{
    public class KeyTriggerCollider : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Key")) 
                GameManager.Instance.KeyQuestSolved();
        }
    }
}