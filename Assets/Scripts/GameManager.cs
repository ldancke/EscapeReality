using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeReality
{
    public enum GameState
    {
        Running,
        Stopped
    }

    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;
        public static GameManager Instance
        {
            get { return GameManager.instance; }
            private set { GameManager.instance = value; }
        }

        private GameState gameState;
        public GameState GameState
        {
            get { return this.gameState; }
            private set { this.gameState = value; }
        }

        private TimeTracker timeTracker;
        public TimeTracker TimeTracker
        {
            get { return this.timeTracker; }
            private set { this.timeTracker = value; }
        }

        public event Action OnGameStart;
        public event Action OnGameStop;
        public event Action OnKeyQuestSolved;
        public event Action OnCorrectCombination;

        private void Awake()
        {
            if (GameManager.instance != null && GameManager.instance != this)
                Destroy(this);
            else
                GameManager.instance = this;

            this.gameState = GameState.Stopped;
            this.timeTracker = new TimeTracker();
        }

        public void GameStart()
        {
            if (this.gameState == GameState.Running)
                return;

            this.gameState = GameState.Running;
            OnGameStart?.Invoke();
        }

        public void GameStop()
        {
            if (this.gameState == GameState.Stopped)
                return;

            this.gameState = GameState.Stopped;
            OnGameStop?.Invoke();
        }

        public void KeyQuestSolved() 
        {
            // this should be called when the key is within reach of the door
            OnKeyQuestSolved?.Invoke();
        }

        public void CorrectCombination()
        {
            // called when correct code is entered
            OnCorrectCombination?.Invoke();
        }
    }
}