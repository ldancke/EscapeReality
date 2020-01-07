using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeReality
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;
        public static GameManager Instance { get; private set; }
    }
}