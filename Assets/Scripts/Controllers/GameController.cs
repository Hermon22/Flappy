using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Controllers
{
    public class GameController : MonoBehaviourSingleton<GameController>
    {
        [SerializeField]private Text scoreText;
        [SerializeField]private int pointPerAction = 10;
        [SerializeField]private GameObject retryWindow;
        private int _currentScore = 0;
        

        public void UpdateScore()
        {
            _currentScore += pointPerAction;
            scoreText.text = "" + _currentScore;
        }

        public void EndGame()
        {
            retryWindow.SetActive(true);
            Time.timeScale = 0;
        }

        public void ReloadGame()
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            Time.timeScale = 1;
        }
    }
}
