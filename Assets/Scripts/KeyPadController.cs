using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeReality { 

    public class KeyPadController : MonoBehaviour
    {
        [SerializeField]
        private int[] password;
        private List<int> input;

        public event Action OnCorrectCode;

        private void Awake() => this.input = new List<int>();

        private void CheckCorrectCode()
        {
            if (this.input.Count != this.password.Length)
                return;

            for (int i = 0; i < this.password.Length; ++i)
                if (this.input[i] != this.password[i])
                    return;

            OnCorrectCode?.Invoke();
        }

        private void UpdateInput(int number)
        {
            if (this.input.Count >= this.password.Length)
                this.input.RemoveAt(0);
            this.input.Add(number);
        }

        public void StonePressed(int stoneNumber)
        {
            UpdateInput(stoneNumber);
            CheckCorrectCode();
        }

    }
}
