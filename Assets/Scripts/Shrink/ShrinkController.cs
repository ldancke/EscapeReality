using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using VRPlayer = Valve.VR.InteractionSystem.Player;

namespace EscapeReality.Shrink
{
    /**
     * A control class that allows the player to morph
     */
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

        /** Event that gets called *after* the player has risen */
        public event Action OnNormal;
        /** Event that gets called *after* the player has shrunk */
        public event Action OnShrunk;
        /** Event that gets called regardless what the new state is */
        public event Action OnMorphed;

        private void Awake()
        {
            this.State = State.Normal;
        }

        private void FixedUpdate()
        {
            if (this.State == State.Morphing)
            {
                if ((transform.localScale - this.morph.target).sqrMagnitude > this.sqrThreshold)
                    transform.localScale = Vector3.Lerp(transform.localScale, this.morph.target, this.speed * Time.deltaTime);
                else
                    FinalizeMorph();
            }
        }

        /**
         * Morph the player
         * 
         * Will shrink if the player is normal,
         * will rise if the player is shrunk
         */
        public void Morph()
        {
            if (this.State == State.Normal)
                Shrink();
            else if (this.State == State.Shrunk)
                Rise();
        }

        /**
         * Shrink the player if possible
         */
        public void Shrink()
        {
            if (this.State != State.Normal)
                return;

            AudioManager.instance.Play("Warp_Small");

            this.morph = new Morph(MorphType.Shrink, Vector3.one * this.shrinkFactor);
            InitializeMorph();
        }

        /**
         * Rise the player if possible
         */
        public void Rise()
        {
            if (this.State != State.Shrunk)
                return;

            AudioManager.instance.Play("Warp_Big");

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

            this.state = this.morph.ResultingState;

            if (this.state == State.Normal)
                OnNormal?.Invoke();
            else
                OnShrunk?.Invoke();

            OnMorphed?.Invoke();
        }
    }
}