using System;
using UnityEngine;

namespace EscapeReality.Door
{
    public class Exit : MonoBehaviour 
    {
        public event Action OnPlayerLeaveSpawn;

        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.CompareTag("VRHead"))
                return;

            OnPlayerLeaveSpawn?.Invoke();
        }
    }
}