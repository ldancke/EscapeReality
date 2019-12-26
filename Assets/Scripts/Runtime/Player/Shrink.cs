using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeReality.Player
{
    public class Shrink : MonoBehaviour
    {
        private enum Status
        {
            Normal    = 1,
            Shrunk    = 2,
            Shrinking = 4,
            Rising    = 8,
            Morphing  = Shrinking | Rising
        }

#pragma warning disable CS0649
        [SerializeField, Range(0.01f, 1f)]
        private float factor;
        [SerializeField]
        private float speed;
        [SerializeField]
        private float sqrThreshold;
        private Status status;
#pragma warning restore CS0649

        private void Awake()
        {
            this.status = Status.Normal;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (this.status == Status.Normal)
                    this.status = Status.Shrinking;
                else if (this.status == Status.Shrunk)
                    this.status = Status.Rising;
            }
        }

        private void FixedUpdate()
        {
            if ((this.status & Status.Morphing) == this.status)
                Morph();
        }

        private void Morph()
        {
            Vector3 target = Vector3.one;
            if (this.status == Status.Shrinking)
                target *= this.factor;

            transform.localScale =  Vector3.Lerp(transform.localScale, target, this.speed);

            if ((transform.localScale - target).sqrMagnitude < this.sqrThreshold)
            {
                transform.localScale = target;
                this.status = this.status == Status.Shrinking ? Status.Shrunk : Status.Normal;
            }
        }
    }
}