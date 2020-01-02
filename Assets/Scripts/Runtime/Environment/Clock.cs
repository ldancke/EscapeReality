using UnityEngine;
using EscapeReality.Game;

namespace EscapeReality.Environment{
    public class Clock : MonoBehaviour {
        private TextMesh text;
        void Start() {
            text = GetComponent<TextMesh>();

            GameState.timeUpdateDelegate += OnUpdateTime;
        }

        private void OnUpdateTime(string newTime) {
            text.text = newTime;
        }
    }
}