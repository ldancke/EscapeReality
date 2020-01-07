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
            this.text.text = Format(GameManager.Instance.TimeTracker.Elapsed);
        }

        private string Format(float time)
        {
            return Mathf.Floor(time / 60).ToString("00") + ":" + (time % 60).ToString("00");
        }
    }
}