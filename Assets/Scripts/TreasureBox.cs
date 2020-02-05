using UnityEngine;

namespace EscapeReality
{
    /**
     * A class for behaviour of the TreasureBox-GameObject
     *
     * This script enables the TreasureBox-GameObject it is attached to be opened once the corresponding
     * quest is solved
     */
    public class TreasureBox : MonoBehaviour
    {
        /**
         * Internal only class that represents the state of the TreasureBox
         */
        private enum TreasureBoxState 
        {
            Closed, 
            Opening, 
            Open
        }

        private TreasureBoxState state;

        private float startTime;
        private float speed = 0.2f;

        /**
         * The angle of the box if it is closed
         */
        public float boxClosedAngle = 0;
        /**
         * The angle of the box if it is open
         */
        public float boxOpenAngle = -90;

        /**
         * Sets initial TreasureBoxState and subscribes to corresponding quest 
         */
        void Awake()
        {
            state = TreasureBoxState.Closed;

            GameManager.Instance.OnBucketQuestSolved += Open;
        }

        /**
         * Starts opening of the TreasureBox and plays some audio
         */
        public void Open()
        {
            if (state == TreasureBoxState.Closed) 
            {
                state = TreasureBoxState.Opening;
                startTime = Time.time;
                AudioManager.instance.Play("Found");
            }
        }

        /**
         * Performs the TreasureBox-open animation if the state is Opening
         */
        void FixedUpdate() 
        {
            if (state == TreasureBoxState.Opening)
            {
                float distance = (Time.time - startTime) * speed;

                if (Mathf.Abs(transform.rotation.eulerAngles.x - boxOpenAngle) % 360 > 0) 
                {
                    var newX = Mathf.LerpAngle(boxClosedAngle, boxOpenAngle, distance);
                    transform.eulerAngles = new Vector3(newX, 0f, 0f);
                }
                else 
                {
                    state = TreasureBoxState.Open;
                }
            }
        }
    }
}