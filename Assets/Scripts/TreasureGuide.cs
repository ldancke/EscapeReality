using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeReality
{
    /**
     * A class for the behaviour for the TreasureGuide-GameObject, a little tip to open the treasure box
     */
    public class TreasureGuide : MonoBehaviour
    {
        void Awake()
        {
            GameManager.Instance.OnBucketQuestSolved += OnBucketQuestSolved;
        }
        
        private void OnBucketQuestSolved() 
        {
            // change color to green
            var renderer = GetComponent<Renderer>();
            renderer.material.SetColor("_Color", new Color(0.2198736f, 0.5754717f, 0.221145f));
        }
    }
}
