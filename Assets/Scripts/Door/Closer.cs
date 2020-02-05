using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeReality.Door
{
    /**
     * A class for the behaviour of the door GameObject
     *
     * The door is able to be closed and opened, each of those with an animation
     */
    public class Closer : MonoBehaviour
    {
        private enum State 
        {
            Open, 
            Closed, 
            Opening, 
            Closing
        }

        /**
         * The angle of the door if it is closed
         */
        public float doorOpenYAngle = -90f;

        /**
         * The angle of the door if it is open
         */
        public float doorClosedYAngle = 0f;

        [SerializeField]
        private State state;
        private float speed = 1f;
        private float startTime;

        void Awake()
        {
            //transform.eulerAngles = new Vector3(0f, doorClosedYAngle, 0f);

            GameManager.Instance.OnGameStart += StartOpening;
            GameManager.Instance.Exit.OnPlayerLeaveSpawn += StartClosing;
            GameManager.Instance.KeyTriggerCollider.OnKeyQuestSolved += StartOpening;
        }

        void FixedUpdate() 
        {
            switch (state)
            {
                case State.Opening:
                    OpenDoor();
                    break;
                case State.Closing:
                    CloseDoor();
                    break;
            }
        }

        /**
         * Starts the closing animation of the door
         */
        public void StartClosing() 
        {
            if (state == State.Open)
            {
                AudioManager.instance.Play("Door_Close");
                startTime = Time.time;
                state = State.Closing;
                GameManager.Instance.Exit.OnPlayerLeaveSpawn -= StartClosing;
            }
        }

        /**
         * Closes the door a little bit using lerps to simulate a closing animation
         */
        public void CloseDoor() 
        {
            float distance = (Time.time - startTime) * speed;

            if (Mathf.Abs(transform.rotation.eulerAngles.y - doorClosedYAngle) % 360 > 0) 
            {
                var newY = Mathf.LerpAngle(doorOpenYAngle, doorClosedYAngle, distance);
                transform.eulerAngles = new Vector3(0f, newY, 0f);
            }
            else 
            {
                state = State.Closed;
            }
        }

        /**
         * Starts the opening animation of the door
         */
        public void StartOpening() 
        {
            if (state == State.Closed)
            {
                AudioManager.instance.Play("Door_Open");
                startTime = Time.time;
                state = State.Opening;
            }
        }

        /**
         * Opens the door a little bit using lerps to simulate a closing animation
         */
        public void OpenDoor() 
        {
            float distance = (Time.time - startTime) * speed;

            if (Mathf.Abs(transform.rotation.eulerAngles.y - doorOpenYAngle) % 360 > 0) 
            {
                var newY = Mathf.LerpAngle(doorClosedYAngle, doorOpenYAngle, distance);
                transform.eulerAngles = new Vector3(0f, newY, 0f);
            }
            else 
            {
                state = State.Open;
            }
        }
    }
}
