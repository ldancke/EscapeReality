using UnityEngine;

namespace EscapeReality.Game {
    public class GameState {
        public delegate void OnTimeUpdateDelegate(string newTime);
        public static OnTimeUpdateDelegate timeUpdateDelegate; 

        private float _time;

        public void UpdateTime(float delta) {
            var newTime = _time + delta;
            var newTimeString = GameState.GetTimeString(newTime);

            if (!newTimeString.Equals(GetTimeString())) {
                timeUpdateDelegate(newTimeString);
            }

            _time = newTime;
        }

        public GameState(float time) {
            _time = time;
        }

        public float GetMinutes() {
            return Mathf.Floor(_time / 60);
        }

        public float GetSeconds() {
            return _time % 60;
        }

        public string GetTimeString() {
            return GameState.GetTimeString(_time);
        }

        public static string GetTimeString(float time) {
            return Mathf.Floor(time / 60).ToString("00") + ":" + (time % 60).ToString("00");
        }
    }
}