using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using VRPlayer = Valve.VR.InteractionSystem.Player;

namespace EscapeReality.Shrink
{
    [RequireComponent(typeof(Throwable))]
    public class Shrinkable : MonoBehaviour
    {
        private ShrinkController cachedShrinkController;

        [SerializeField]
        private State defaultState;
        public State DefaultState
        {
            get { return this.defaultState; }
            private set { this.defaultState = value; }
        }

        private State currentState;
        public State CurrentState
        {
            get { return this.currentState; }
            set { this.currentState = value; }
        }

        private void Awake()
        {
            this.currentState = this.defaultState;
            this.cachedShrinkController = VRPlayer.instance.GetComponent<ShrinkController>();
        }

        private void Start()
        {
            UpdateHovering();
            cachedShrinkController.OnMorphed += UpdateHovering;
        }

        private void UpdateHovering()
        {
            if (this.cachedShrinkController.State != this.currentState)
                DisableHovering();
            else
                RestoreHovering();
        }

        private void DisableHovering()
        {
            IgnoreHovering ignoreHovering = GetComponent<IgnoreHovering>();
            if (ignoreHovering != null)
                return;

            gameObject.AddComponent<IgnoreHovering>();
        }

        private void RestoreHovering()
        {
            IgnoreHovering ignoreHovering = GetComponent<IgnoreHovering>();
            if (ignoreHovering == null)
                return;

            Destroy(ignoreHovering);
        }
    }
}