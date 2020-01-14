using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using VRPlayer = Valve.VR.InteractionSystem.Player;

namespace EscapeReality.Shrink
{
    public class ShrinkController : MonoBehaviour
    {
#pragma warning disable CS0649
        [SerializeField, Range(0.1f, 1f)]
        private float factor;

        [SerializeField]
        private float speed;

        [SerializeField]
        private float sqrThreshold;

        private Vector3 morphTarget;
        private State newState;
        private HashSet<Shrinkable> shrinkablesInHands;

        private State state;
        public State State
        {
            get { return this.state; }
            private set { this.state = value; }
        }
#pragma warning restore CS0649

        public event Action OnMorphed;

        private void Awake()
        {
            this.state = State.Normal;
            this.shrinkablesInHands = new HashSet<Shrinkable>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Morph();
        }

        private void FixedUpdate()
        {
            if (this.state == State.Morphing)
                Morphing();
        }

        private void Morphing()
        {
            if ((transform.localScale - this.morphTarget).sqrMagnitude > this.sqrThreshold)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, morphTarget, this.speed * Time.deltaTime);
                foreach (Shrinkable shrinkable in this.shrinkablesInHands)
                    shrinkable.transform.localScale = Vector3.Lerp(shrinkable.transform.localScale, morphTarget, this.speed * Time.deltaTime);
            } else {
                FinalizeMorph();
            }
        }

        public void Morph()
        {
            switch (this.state)
            {
                case State.Normal:
                    Shrink();
                    break;
                case State.Shrunk:
                    Rise();
                    break;
            }
        }

        public void Shrink()
        {
            if (this.state != State.Normal)
                return;

            this.morphTarget = Vector3.one * this.factor;
            this.newState = State.Shrunk;
            InitializeMorph();
        }

        public void Rise()
        {
            if (this.state != State.Shrunk)
                return;

            this.morphTarget = Vector3.one;
            this.newState = State.Normal;
            InitializeMorph();
        }

        private void InitializeMorph()
        {
            this.state = State.Morphing;

            foreach (Hand hand in VRPlayer.instance.hands)
            {
                GameObject go = hand.currentAttachedObject;
                if (go == null)
                    continue;

                Shrinkable shrinkable = go?.GetComponent<Shrinkable>();
                if (shrinkable == null)
                    hand.DetachObject(shrinkable.gameObject);
                else
                    this.shrinkablesInHands.Add(shrinkable);
            }
        }

        private void FinalizeMorph()
        {
            transform.localScale = this.morphTarget;
            foreach (Shrinkable shrinkable in this.shrinkablesInHands)
                shrinkable.state = this.newState;
            this.shrinkablesInHands.Clear();
            this.state = this.newState;
            OnMorphed?.Invoke();
        }
    }
}