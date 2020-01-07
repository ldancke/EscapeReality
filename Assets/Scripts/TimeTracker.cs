using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeReality
{
    public class TimeTracker
    {
        private bool tracking;
        private float timestamp;
        private float elapsed;

        public TimeTracker()
        {
            this.tracking = false;
            this.timestamp = 0;
            this.elapsed = 0;

            GameManager.Instance.OnGameStart += Start;
            GameManager.Instance.OnGameStop += Stop;
        }

        private void Start()
        {
            this.tracking = true;
            this.timestamp = Time.time;
            this.elapsed = 0;
        }

        private void Stop()
        {
            this.tracking = false;
        }

        public float Elapsed
        {
            get
            {
                if (tracking)
                    this.elapsed = Time.time - this.timestamp;
                return this.elapsed;
            }
        }
    }
}