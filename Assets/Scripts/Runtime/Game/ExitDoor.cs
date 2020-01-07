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
            _gameStarted = true;
            OnGameStart();
            Debug.Log("Trigger exit");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_gameStarted)
            {
                _gameStarted = false;
                OnGameEnd();
                Debug.Log("Trigger enter");
            }
        }
    }
}