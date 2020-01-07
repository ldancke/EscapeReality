using UnityEngine;

namespace EscapeReality 
{
    public class ExitDoor : MonoBehaviour 
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