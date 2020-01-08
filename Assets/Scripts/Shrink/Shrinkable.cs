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
        [Tooltip("Indicates whether the object is shrunk from the beginning - used in tracking the state later")]
        public State state;

        private ShrinkController cachedShrinkController;

        private void Awake()
        {
            this.cachedShrinkController = VRPlayer.instance.GetComponent<ShrinkController>();
        }

        private void Start()
        {
            IgnoreHovering();
            VRPlayer.instance.GetComponent<ShrinkController>().OnMorphed += IgnoreHovering;
        }

        private void IgnoreHovering()
        {
            if (cachedShrinkController.State == this.state)
                Destroy(GetComponent<IgnoreHovering>());
            else
                gameObject.AddComponent<IgnoreHovering>();
        }
    }
}