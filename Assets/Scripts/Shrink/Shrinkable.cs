using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using VRPlayer = Valve.VR.InteractionSystem.Player;

namespace EscapeReality.Shrink
{
    /**
     * Class / component that indicates if an object is allowed morph
     * 
     * When the player morphs hold an object without this class attached,
     * the object will be dropped to the ground before the morph.
     * Also keeps track of an objects state so it is not shrunk / risen more then once.
     */
    [RequireComponent(typeof(Throwable))]
    public class Shrinkable : MonoBehaviour
    {
        private ShrinkController cachedShrinkController;

        /** The state the object is in when spawned */
        [SerializeField]
        private State defaultState;
        public State DefaultState
        {
            get { return this.defaultState; }
            private set { this.defaultState = value; }
        }

        /** The state the object is currently in */
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