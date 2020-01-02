using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeReality.Game
{
    public class Timer : MonoBehaviour 
    {
        public GameState state = new GameState(0f);
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
                Debug.Log(state.GetTimeString());
                yield return null;
                state.UpdateTime(Time.deltaTime);
            }
        }
    }
}