using UnityEngine;

namespace EscapeReality
{
    public class TreasureBox : MonoBehaviour
    {
        private enum TreasureBoxState 
        {
            Closed, 
            Opening, 
            Open
        }

        private TreasureBoxState state;

        private float startTime;
        private float speed = 0.2f;

        public float boxClosedAngle = 0;
        public float boxOpenAngle = -90;

        void Awake()
        {
            state = TreasureBoxState.Closed;

            GameManager.Instance.OnBucketQuestSolved += Open;
        }

        public void Open()
        {
            if (state == TreasureBoxState.Closed) 
            {
                state = TreasureBoxState.Opening;
                startTime = Time.time;
                AudioManager.instance.Play("Found");
            }
        }

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