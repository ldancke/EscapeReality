using UnityEngine;

namespace EscapeReality
{
    public class BucketQuestCollider : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other) 
        {
            if (other.CompareTag("BucketQuestItem")) 
                GameManager.Instance.BucketQuestSolved();
        }
    }
}