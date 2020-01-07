using UnityEngine;

namespace EscapeReality.Game {
    public class TimeState {
        public delegate void OnTimeUpdateDelegate(float timeFloat);
        public static OnTimeUpdateDelegate timeUpdateDelegate; 

        private float _time;

        public void UpdateTime(float delta) {
            var newTime = _time + delta;
            var newTimeString = TimeState.GetTimeString(newTime);

            if (!newTimeString.Equals(GetTimeString())) {
                timeUpdateDelegate(newTime);
            }

            _time = newTime;
        }

        public TimeState(float time) {
            _time = time;
        }

        public float GetMinutes() {
            return Mathf.Floor(_time / 60);
        }

        public float GetSeconds() {
            return _time % 60;
        }

        public string GetTimeString() {
            return TimeState.GetTimeString(_time);
        }

        public static string GetTimeString(float time) {
            return Mathf.Floor(time / 60).ToString("00") + ":" + (time % 60).ToString("00");
        }
    }
}