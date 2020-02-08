using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRPlayer = Valve.VR.InteractionSystem.Player;
using EscapeReality.Door;

namespace EscapeReality
{
    /**
     * Possible game states
     */
    public enum GameState
    {
        Running,
        Stopped
    }

    /**
     * Singleton that keeps track of the game state,
     * provides the utility to (re)start the game
     * and serves as a registry for other GameObjects
     * that carry out management tasks like the TimeTracker.
     */
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

        [SerializeField]
        private Exit exit;
        public Exit Exit
        {
            get { return this.exit; }
            private set { this.exit = value; }
        }

        [SerializeField]
        private GameObject[] gameObjectsToReset;

        /** Event that gets called when the game starts */
        public event Action OnGameStart;
        /** Event that gets called when the game stops */
        public event Action OnGameStop;
        /** Event that gets called when the BucketQuest was solved - should be refactored */
        public event Action OnBucketQuestSolved;

        private void Awake()
        {
            if (GameManager.instance != null && GameManager.instance != this)
                Destroy(this);
            else
                GameManager.instance = this;

            this.gameState = GameState.Stopped;
            this.timeTracker = new TimeTracker();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
                ResetScene();
        }

        /**
         * Starts the game
         */
        public void GameStart()
        {
            if (this.gameState == GameState.Running)
                return;

            this.gameState = GameState.Running;
            OnGameStart?.Invoke();
        }

        /**
         * Stops the game
         */
        public void GameStop()
        {
            if (this.gameState == GameState.Stopped)
                return;

            this.gameState = GameState.Stopped;
            OnGameStop?.Invoke();
        }

        /**
         * Resets the scene to the base state
         */
        public void ResetScene()
        {
            foreach (GameObject go in this.gameObjectsToReset)
                Destroy(go);
            Destroy(VRPlayer.instance.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void BucketQuestSolved()
        {
            OnBucketQuestSolved?.Invoke();
        }
    }
}