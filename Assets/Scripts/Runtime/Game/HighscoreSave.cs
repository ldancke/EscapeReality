using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

namespace EscapeReality.Game 
{
    [System.Serializable]
    public class HighscoreSave
    {
        public List<(string, float)> highscores = new List<(string, float)>();

        public void AddHighScore(string name, float time) {
            highscores.Add((name, time));

            highscores.Sort((a, b) => a.Item2.CompareTo(b.Item2));

            if (highscores.Count > 10) {
                highscores = highscores.GetRange(0, 10);
            }
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < highscores.Count; i++) {
                var score = highscores[i];
                sb.AppendFormat("{0}.\t{1}\t\t{2}\n", i+1, score.Item1, TimeState.GetTimeString(score.Item2));
            }

            return sb.ToString();
        }
    }
}