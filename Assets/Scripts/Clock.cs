using UnityEngine;

namespace EscapeReality
{
    public class Clock : MonoBehaviour
    {
#pragma warning disable CS0649
        [SerializeField]
        private TextMesh text;
#pragma warning restore CS0649

        private void Update()
        {
            this.text.text = GameManager.Instance.TimeTracker.Elapsed.ToString();
        }
    }
}