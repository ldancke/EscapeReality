using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EscapeReality.Shrink;
using Valve.VR.InteractionSystem;
using VRPlayer = Valve.VR.InteractionSystem.Player;

namespace EscapeReality
{
    [RequireComponent(typeof(TeleportArea))]
    public class SizeDependentTeleportArea : MonoBehaviour
    {
#pragma warning disable CS0649
        [SerializeField]
        private State activeState;
        private TeleportArea teleportArea;
        private ShrinkController shrinkController;
#pragma warning restore CS0649

        private void Awake()
        {
            this.teleportArea = GetComponent<TeleportArea>();
            this.shrinkController = VRPlayer.instance.GetComponent<ShrinkController>();
        }

        private void Start()
        {
            if (this.activeState != shrinkController.State)
                Deactivate();

            SetupListeners();
        }

        private void SetupListeners()
        {
            switch (this.activeState)
            {
                case State.Normal:
                    this.shrinkController.OnNormal += Activate;
                    this.shrinkController.OnShrunk += Deactivate;
                    break;
                case State.Shrunk:
                    this.shrinkController.OnShrunk += Activate;
                    this.shrinkController.OnNormal += Deactivate;
                    break;
            }
        }

        private void Activate()
        {
            this.teleportArea.SetLocked(false);
            this.teleportArea.gameObject.SetActive(true);
        }

        private void Deactivate()
        {
            this.teleportArea.SetLocked(true);
            this.teleportArea.gameObject.SetActive(false);
        }
    }
}