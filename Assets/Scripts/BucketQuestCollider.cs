using UnityEngine;

namespace EscapeReality
{
    /**
     * A class for the behaviour of the BucketQuestCollider
     *
     * This is used to check if the BucketQuestItem was thrown into the Bucket and invoke the BucketQuestSolved
     * event afterwards. 
     */
    public class BucketQuestCollider : MonoBehaviour
    {
        /**
         * Checks if the  object that enters the trigger is the BucketQuestItem. 
         * If it is the BucketQuestItem the BucketQuestSolved-event is raised
         *
         * @param other The object that enters the trigger
         */
        public void OnTriggerEnter(Collider other) 
        {
            if (other.CompareTag("BucketQuestItem")) 
                GameManager.Instance.BucketQuestSolved();
        }
    }
}