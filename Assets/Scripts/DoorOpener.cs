using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeReality
{
    public class DoorOpener : MonoBehaviour
    {
        void Start()
        {
            GameManager.Instance.OnGameStart += CloseDoor;
        }

        private void CloseDoor() {
            //transform.Rotate(0f, 65f, 0f);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }
}
