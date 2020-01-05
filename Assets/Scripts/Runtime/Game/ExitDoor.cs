
using UnityEngine;

namespace EscapeReality.Game 
{
    public class ExitDoor : MonoBehaviour 
    {
        public delegate void OnGameStartDelegate();
        public static OnGameStartDelegate gameStartDelegate;
        public delegate void OnGameEndDelegate();
        public static OnGameEndDelegate gameEndDelegate;

        private bool _gameStarted = false;

        public void OnGameStart() {
            gameStartDelegate();
        }

        public void OnGameEnd() {
            gameEndDelegate();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!_gameStarted) {
                OnGameStart();
            } else {
                OnGameEnd();
            }

            _gameStarted = !_gameStarted;
        }
    }
}