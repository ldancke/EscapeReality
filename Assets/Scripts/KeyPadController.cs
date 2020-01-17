using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR.InteractionSystem;
using VRPlayer = Valve.VR.InteractionSystem.Player;

namespace EscapeReality { 

    public class KeyPadController : MonoBehaviour
    {

        public string password = "4213";
        public int length = 4;
        public string input;


        void Update()
        {
                                  
            if (input == password)
            {
                Debug.Log("Correct Combination Pressed");
                GameManager.Instance.CorrectCombination();
            }

        }

        public void StonePressed(string number)
             {
            Debug.Log(number);
            }



        public void FirstStonePressed()
        {
            input += "1";
            Debug.Log("Stone Pressed:" + input);
        }

        public void SecondStonePressed()
        {
            input += "2";
            Debug.Log("Stone Pressed:" + input);
        }

        public void ThirdStonePressed()
        {
            input += "3";
            Debug.Log("Stone Pressed:" + input);
        }

        public void ForthStonePressed()
        {
            input += "4";
            Debug.Log("Stone Pressed:" + input);
        }

        public void ResetCode()
        {
            Debug.Log("Reset Pressed - Input before:" + input);
            input = "";
            Debug.Log("Reset Pressed - input cleared - new input :" + input);
        }
       
    }
}
