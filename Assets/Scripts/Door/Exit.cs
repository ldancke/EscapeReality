using UnityEngine;

namespace EscapeReality.Door
{
    public class Exit : MonoBehaviour 
    {
        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.CompareTag("VRHead"))
                return;

            GameManager.Instance.GameStart();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("VRHead"))
                return;

            GameManager.Instance.GameStop();
        }
    }
}