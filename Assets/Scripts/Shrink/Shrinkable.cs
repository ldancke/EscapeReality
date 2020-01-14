using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using VRPlayer = Valve.VR.InteractionSystem.Player;

namespace EscapeReality.Shrink
{
    [RequireComponent(typeof(Valve.VR.InteractionSystem.Throwable))]
    public class Shrinkable : MonoBehaviour
    {
        [Tooltip("Indicated the object's default state")]
        public State state;

        private ShrinkController cachedShrinkController;

        private void Awake()
        {
            this.cachedShrinkController = VRPlayer.instance.GetComponent<ShrinkController>();
        }

        private void Start()
        {
            UpdateHovering();
            cachedShrinkController.OnMorphed += UpdateHovering;
        }

        private void UpdateHovering()
        {
            if (this.cachedShrinkController.State != this.state)
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