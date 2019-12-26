using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeReality.Player
{
    public class Shrink : MonoBehaviour
    {
#pragma warning disable CS0649
        [SerializeField, Range(0.01f, 1f)]
        private float factor;
        private bool shrunk;
#pragma warning restore CS0649

        private void Awake()
        {
            this.shrunk = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                float factor = this.shrunk ? 1 : this.factor;
                transform.localScale = factor * Vector3.one;
                this.shrunk = !this.shrunk;
            }
        }
    }
}