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
        private float shrinkFactor;

        [SerializeField]
        private float speed;

        [SerializeField]
        private float sqrThreshold;

        private Morph morph;

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
            this.State = State.Normal;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Morph();
        }

        private void FixedUpdate()
        {
            if (this.State == State.Morphing)
            {
                if ((transform.localScale - this.morph.target).sqrMagnitude > this.sqrThreshold)
                {
                    transform.localScale = Vector3.Lerp(transform.localScale, this.morph.target, this.speed * Time.deltaTime);
                }
                else
                {
                    FinalizeMorph();
                }
            }
        }

        public void Morph()
        {
            if (this.State == State.Normal)
                Shrink();
            else if (this.State == State.Shrunk)
                Rise();
        }

        public void Shrink()
        {
            if (this.State != State.Normal)
                return;

            this.morph = new Morph(MorphType.Shrink, Vector3.one * this.shrinkFactor);
            InitializeMorph();
        }

        public void Rise()
        {
            if (this.State != State.Shrunk)
                return;

            this.morph = new Morph(MorphType.Rise, Vector3.one);
            InitializeMorph();
        }

        private void InitializeMorph()
        {
            this.State = State.Morphing;

            foreach (Hand hand in VRPlayer.instance.hands)
            {
                GameObject go = hand.currentAttachedObject;
                if (go == null)
                    continue;

                Shrinkable shrinkable = go.GetComponent<Shrinkable>();
                if (shrinkable == null)
                    hand.DetachObject(go);
                else
                    this.morph.shrinkablesInHand.Add(shrinkable);
            }
        }

        private void FinalizeMorph()
        {
            transform.localScale = this.morph.target;
            foreach (Shrinkable shrinkable in this.morph.shrinkablesInHand)
                shrinkable.CurrentState = this.morph.ResultingState;
            this.State = this.morph.ResultingState;
            OnMorphed?.Invoke();
        }
    }
}