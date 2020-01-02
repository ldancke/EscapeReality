using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeReality.Game
{
    public class Timer : MonoBehaviour 
    {
        public float time = 0;
        private bool _gameStarted = false;

        public void Start() {
            ExitDoor.gameStartDelegate += StartTimer;
            ExitDoor.gameEndDelegate += EndTimer;
        }

        private void StartTimer() {
            _gameStarted = true;
            StartCoroutine(gameTimer());
        }

        private void EndTimer() {
            _gameStarted = false;
        }

        private IEnumerator gameTimer() {
            while (_gameStarted) 
            {
                Debug.Log(time);
                yield return null;
                time += Time.deltaTime;
            }
        }
    }
}