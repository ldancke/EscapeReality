using UnityEngine;

namespace EscapeReality
{
    /**
     * A class for the behavior of the Clock-GameObject
     *
     * It updates a TextMesh with the current time in every frame
     */
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

        /**
         * Converts a float time to string with format "hh:mm"
         *
         * @param time The time to convert
         */
        public static string Format(float time)
        {
            return Mathf.Floor(time / 60).ToString("00") + ":" + (time % 60).ToString("00"); 
        }
    }
}