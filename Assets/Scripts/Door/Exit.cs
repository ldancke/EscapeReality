using System;
using UnityEngine;

namespace EscapeReality.Door
{
    /**
     * A class for the behaviour of the ExitTriggerCollider
     *
     * This is used to check if the player has left the spawn room and the door can be closed
     */
    public class Exit : MonoBehaviour 
    {
        /**
         * The event that is raised when the player leaves the spawn area and enters the main room
         */
        public event Action OnPlayerLeaveSpawn;

        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.CompareTag("VRHead"))
                return;

            OnPlayerLeaveSpawn?.Invoke();
        }
    }
}