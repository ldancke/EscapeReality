
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
            Debug.Log("Game started");
            gameStartDelegate();
        }

        public void OnGameEnd() {
            Debug.Log("Game ended");
            gameEndDelegate();
        }

        void Start() {
            
        }

        private void OnTriggerExit(Collider other)
        {
            Debug.Log("Trigger enter");
            if (!_gameStarted) {
                OnGameStart();
            } else {
                OnGameEnd();
            }

            _gameStarted = !_gameStarted;
        }
    }
}