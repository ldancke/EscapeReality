using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeReality.Shrink
{
    public class ShrinkController : MonoBehaviour
    {
#pragma warning disable CS0649
        [SerializeField, Range(0.1f, 1f)]
        private float factor;

        [SerializeField]
        private float speed;

        private State state;
        public State State
        {
            get { return this.state; }
            private set { this.state = value; }
        }

        private bool isMorphing;
#pragma warning restore CS0649

        public event Action OnNormal;
        public event Action OnShrunk;

        private void Awake()
        {
            this.state = State.Normal;
            this.isMorphing = false;
        }

        private void UpdateState() => this.state = this.state == State.Normal ? State.Shrunk : State.Normal;
    }
}