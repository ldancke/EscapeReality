using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeReality {

    /**
     * A class for the behaviour of the KeyPadController.
     *
     * Is used to check if the correct code is entered and invokes the OnCorrectCode event if thats the case.
     */
    public class KeyPadController : MonoBehaviour
    {
#pragma warning disable CS0649
        [SerializeField]
        //* Password entered in Inspector.
        private int[] password;
        //* List of entered numbers.
        private List<int> input;
#pragma warning restore CS0649

        public event Action OnCorrectCode;

        private void Awake() => this.input = new List<int>();

        /**
         * Compares input, password and invokes OnCorrectCode if they match.
         * 
         */
        private void CheckCorrectCode()
        {
            if (this.input.Count != this.password.Length)
                return;

            for (int i = 0; i < this.password.Length; ++i)
                if (this.input[i] != this.password[i])
                    return;

            OnCorrectCode?.Invoke();
        }

        /**
         * Updates input list.
         * Deletes one number before adding the passed one if length of input and password already match.
         * 
         * @param number Number of the pressed shield.
         */
        private void UpdateInput(int number)
        {
            if (this.input.Count >= this.password.Length)
                this.input.RemoveAt(0);
            this.input.Add(number);
        }

        /**
         * Calls UpdateInput(int number) and CheckCorrectCode().
         * 
         * UpdateInput(int number) updates input list.
         * Deletes one number before adding the passed one if length of input and password already match.
         * 
         * CheckCorrectCode() compares input, password and invokes OnCorrectCode if they match.
         * 
         * @param stoneNumber Number of the pressed shield.
         */
        public void StonePressed(int stoneNumber)
        {
            UpdateInput(stoneNumber);
            CheckCorrectCode();
        }

    }
}
