using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRPlayer = Valve.VR.InteractionSystem.Player;
using EscapeReality.Shrink;

namespace EscapeReality
{
    [RequireComponent(typeof(Collider))]
    public class MagicalPlinth : MonoBehaviour
    {
        private ShrinkController shrinkController;

        private void Awake()
        {
            this.shrinkController = VRPlayer.instance.GetComponent<ShrinkController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("VRHead"))
                this.shrinkController.Morph();
        }
    }
}