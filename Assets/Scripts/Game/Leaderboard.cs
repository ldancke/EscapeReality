using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace EscapeReality.Game 
{
    public class Leaderboard: MonoBehaviour 
    {
        private string filePath;

        private HighscoreSave save;
        private float time;
        private TextMesh text;

        public void Start() {
            filePath = Application.persistentDataPath + "/highscores.save";
            text = GetComponent<TextMesh>();

            TimeState.timeUpdateDelegate += OnTimeUpdate;
            GameManager.Instance.OnGameStop += OnGameEnd;

            LoadHighscores();
        }

        private void OnTimeUpdate(float newTime) {
            time = newTime;
        }

        private void OnGameEnd() {
            save.AddHighScore("Keppler", time);
            TimeState.timeUpdateDelegate -= OnTimeUpdate;
            SaveHighscores();
        }

        private void LoadHighscores() {
            if (File.Exists(filePath))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(filePath, FileMode.Open);
                save = (HighscoreSave) bf.Deserialize(file);
                file.Close();
            } 
            else 
            {
                Debug.Log("No highscores saved. ");
                save = new HighscoreSave();
            }

            text.text = save.ToString();
        }

        private void SaveHighscores() {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(filePath);
            bf.Serialize(file, save);
            file.Close();
        }
    }
}