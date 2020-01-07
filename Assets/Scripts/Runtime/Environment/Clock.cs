using UnityEngine;
using EscapeReality.Game;

namespace EscapeReality.Environment{
    public class Clock : MonoBehaviour {
        private TextMesh text;
        void Start() {
            text = GetComponent<TextMesh>();

            TimeState.timeUpdateDelegate += OnUpdateTime;
        }

        private void OnUpdateTime(float newTime) {
            text.text = TimeState.GetTimeString(newTime);
        }
    }
}