using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Menu
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button quitButton;

        private void Awake()
        {
            startButton.onClick.AddListener(OnStartButtonClicked);
            quitButton.onClick.AddListener(OnQuitButtonClicked);
        }
    
        private void OnStartButtonClicked()
        {
            SceneManager.LoadScene("Select Level Scene");
        }
    
        private void OnQuitButtonClicked()
        {
            Application.Quit();
        }
    }
}
