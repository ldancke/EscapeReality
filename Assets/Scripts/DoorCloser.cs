using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeReality
{
    public class DoorCloser : MonoBehaviour
    {
        private enum DoorState 
        {
            Open, 
            Closed, 
            Opening, 
            Closing
        }

        public float doorOpenYAngle = -90f;
        public float doorClosedYAngle = 0f;

        private DoorState state;
        private float speed = 1f;
        private float threshhold = 0.1f;
        private float startTime;

        void Awake()
        {
            state = DoorState.Open;
            transform.eulerAngles = new Vector3(0f, doorOpenYAngle, 0f);

            GameManager.Instance.OnGameStart += StartClosing;
            GameManager.Instance.OnKeyQuestSolved += StartOpening;
        }

        void FixedUpdate() 
        {
            switch (state)
            {
                case DoorState.Opening:
                    OpenDoor();
                    break;
                case DoorState.Closing:
                    CloseDoor();
                    break;
            }
        }

        public void StartClosing() 
        {
            if (state == DoorState.Open)
            {
                startTime = Time.time;
                state = DoorState.Closing;
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
                state = DoorState.Closed;
            }
        }

        public void StartOpening() 
        {
            if (state == DoorState.Closed)
            {
                startTime = Time.time;
                state = DoorState.Opening;
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
                state = DoorState.Open;
            }
        }
    }
}
