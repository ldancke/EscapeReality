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
        private bool isActive;

        private void Awake()
        {
            this.shrinkController = VRPlayer.instance.GetComponent<ShrinkController>();
            this.isActive = false;
            GameManager.Instance.KeyPadController.OnCorrectCode += Activate;
        }

        private void Activate() => this.isActive = true;

        private void OnTriggerEnter(Collider other)
        {
            if (this.isActive && other.gameObject.CompareTag("VRHead"))
                this.shrinkController.Morph();
        }
    }
}