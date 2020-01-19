using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeReality.Door
{
    public class KeyTriggerCollider : MonoBehaviour
    {
        public event Action OnKeyQuestSolved;

        public void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Key"))
            {
                OnKeyQuestSolved?.Invoke();
                GameManager.Instance.GameStop();
            }   
        }
    }
}