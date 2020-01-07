using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using VRPlayer = Valve.VR.InteractionSystem.Player;

namespace EscapeReality.Player
{
    public class Morph : MonoBehaviour
    {
        private enum MorphState
        {
            Normal    = 1,
            Shrunk    = 2,
            Shrinking = 4,
            Rising    = 8,
            Morphing  = Shrinking | Rising
        }

#pragma warning disable CS0649
        [SerializeField, Range(0.1f, 1f)]
        private float factor;
        [SerializeField]
        private float speed;
        private float sqrThreshold;
        private MorphState state;
#pragma warning restore CS0649

        private void Awake()
        {
            this.state = MorphState.Normal;
            this.sqrThreshold = 0.00001f;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DebugStartMorphing();
            }
        }

        private void FixedUpdate()
        {
            if ((this.state & MorphState.Morphing) == this.state)
                Morphing();
        }

        private void Morphing()
        {
            Vector3 target = Vector3.one;
            if (this.state == MorphState.Shrinking)
                target *= this.factor;

            if ((transform.localScale - target).sqrMagnitude > this.sqrThreshold)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, target, this.speed * Time.deltaTime);
                //Hand hand = VRPlayer.instance.rightHand;
            } else {
                transform.localScale = target;
                this.state = this.state == MorphState.Shrinking ? MorphState.Shrunk : MorphState.Normal;
            }
        }

        public void DebugStartMorphing()
        {
            if (this.state == MorphState.Normal)
                this.state = MorphState.Shrinking;
            else if (this.state == MorphState.Shrunk)
                this.state = MorphState.Rising;
        }
    }
}