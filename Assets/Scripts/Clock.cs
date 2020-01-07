using UnityEngine;
using EscapeReality.Game;

namespace EscapeReality
{
    public class Clock : MonoBehaviour
    {
        [SerializeField]
        private TextMesh text;

        private void Update()
        {
            this.text.text = GameManager.Instance.TimeTracker.Elapsed.ToString();
        }
    }
}