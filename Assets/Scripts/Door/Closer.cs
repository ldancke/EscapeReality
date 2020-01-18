using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeReality.Door
{
    public class Closer : MonoBehaviour
    {
        private enum State 
        {
            Open, 
            Closed, 
            Opening, 
            Closing
        }

        public float doorOpenYAngle = -90f;
        public float doorClosedYAngle = 0f;

        private State state;
        private float speed = 1f;
        private float startTime;

        void Awake()
        {
            this.state = State.Open;
            transform.eulerAngles = new Vector3(0f, doorOpenYAngle, 0f);

            GameManager.Instance.OnGameStart += StartClosing;
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

        public void StartClosing() 
        {
            if (state == State.Open)
            {
                startTime = Time.time;
                state = State.Closing;
            }
        }

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

        public void StartOpening() 
        {
            if (state == State.Closed)
            {
                startTime = Time.time;
                state = State.Opening;
            }
        }

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
