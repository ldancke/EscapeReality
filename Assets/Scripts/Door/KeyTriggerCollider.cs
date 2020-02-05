using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeReality.Door
{
    /**
     * A class for the behaviour of the KeyTriggerCollider
     *
     * This is used to check if the key is close to the door and invoke the KeyQuestSolved event if it is 
     */
    public class KeyTriggerCollider : MonoBehaviour
    {
        /**
         * The event that is raised when the key enters the key trigger collider. The door should open afterwards
         */
        public event Action OnKeyQuestSolved;

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Key"))
            {
                OnKeyQuestSolved?.Invoke();
                GameManager.Instance.GameStop();
            }   
        }
    }
}