using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

namespace EscapeReality 
{
    /**
     * A class that holds up to 10 highscore saves 
     *
     * It is serializable to be saved into a save file
     */
    [System.Serializable]
    public class HighscoreSave
    {
        /**
         * The highscores as list of tuples, the tuples contain the name as string and the needed time 
         * as float in milliseconds
         */
        public List<(string, float)> highscores = new List<(string, float)>();

        /**
         * Adds a new highscore to the list, but only if it's within the 10 best scores
         *
         * @param name The name of the player
         * @param time The needed time in milliseconds
         */
        public void AddHighScore(string name, float time)
        {
            highscores.Add((name, time));

            highscores.Sort((a, b) => a.Item2.CompareTo(b.Item2));

            if (highscores.Count > 10)
                highscores = highscores.GetRange(0, 10);
        }

        /**
         * Returns the Highscore-list in a human-readable way, ready to be printed on a TextMesh
         *
         * @returns The list as string, consisting of the score index, the name and the needed time in format "hh:mm"
         */
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("\t  Leaderboard\n\n");
            
            for (int i = 0; i < highscores.Count; i++)
            {
                var score = highscores[i];
                sb.AppendFormat("{0}.\t{1}\t\t{2}\n", i+1, score.Item1, Clock.Format(score.Item2));
            }

            return sb.ToString();
        }
    }
}