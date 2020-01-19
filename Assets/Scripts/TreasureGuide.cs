using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeReality
{
    public class TreasureGuide : MonoBehaviour
    {
        void Awake()
        {
            GameManager.Instance.OnBucketQuestSolved += OnBucketQuestSolved;
        }
        
        private void OnBucketQuestSolved() 
        {
            Debug.Log("Changing guide color...");
            var renderer = GetComponent<Renderer>();
            renderer.material.SetColor("_Color", Color.green);
        }
    }
}
