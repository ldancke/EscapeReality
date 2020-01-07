using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace EscapeReality 
{
    public class Leaderboard: MonoBehaviour 
    {
        private string filePath;

        private HighscoreSave save;
        private TextMesh text;

        private void Awake()
        {
            this.filePath = Application.persistentDataPath + "/highscores.save";
            this.text = GetComponent<TextMesh>();

            GameManager.Instance.OnGameStop += OnGameEnd;
        }

        private void Start() {
            LoadHighscores();
        }

        private void OnGameEnd() {
            save.AddHighScore("Keppler", GameManager.Instance.TimeTracker.Elapsed);
            SaveHighscores();

            // Hack to display highscores instantly
            LoadHighscores();
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