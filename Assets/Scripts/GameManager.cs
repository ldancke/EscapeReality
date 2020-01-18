﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EscapeReality.Door;

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

        [SerializeField]
        private KeyPadController keyPadController;
        public KeyPadController KeyPadController
        {
            get { return this.keyPadController; }
            private set { this.keyPadController = value; }
        }

        [SerializeField]
        private KeyTriggerCollider keyTriggerCollider;
        public KeyTriggerCollider KeyTriggerCollider
        {
            get { return this.keyTriggerCollider; }
            private set { this.keyTriggerCollider = value; }
        }

        public event Action OnGameStart;
        public event Action OnGameStop;
        public event Action OnMazeQuestSolved;

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

        public void MazeQuestSolved()
        {
            OnMazeQuestSolved?.Invoke();
        }
    }
}