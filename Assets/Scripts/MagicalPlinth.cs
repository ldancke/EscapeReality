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
#pragma warning disable CS0649
        private ShrinkController shrinkController;
        private bool isActive;
        [SerializeField]
        ParticleSystem particles;
#pragma warning restore CS0649

        private void Awake()
        {
            this.shrinkController = VRPlayer.instance.GetComponent<ShrinkController>();
            this.isActive = false;
            GameManager.Instance.KeyPadController.OnCorrectCode += Activate;
        }

        private void Activate()
        {
            this.particles.gameObject.SetActive(true);
            this.isActive = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (this.isActive && other.gameObject.CompareTag("VRHead"))
                this.shrinkController.Morph();
        }
    }
}