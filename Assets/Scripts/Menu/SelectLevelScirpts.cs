using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Menu
{
    public class SelectLevelScirpts : MonoBehaviour
    {
        [SerializeField] private Button Level1Button;
        [SerializeField] private Button Level2Button;
        [SerializeField] private Button Level3Button;
        [SerializeField] private Button backButton;
        // Start is called before the first frame update
    
        private void Awake()
        {
            Level1Button.onClick.AddListener(OnLevel1ButtonClicked);
            Level2Button.onClick.AddListener(OnLevel2ButtonClicked);
            Level3Button.onClick.AddListener(OnLevel3ButtonClicked);
            backButton.onClick.AddListener(OnbackButtonClicked);
        }
   
        private void OnbackButtonClicked()
        {
            SceneManager.LoadScene("Menuscene");
        }
    
        private void OnLevel1ButtonClicked()
        {
            SceneManager.LoadScene("Level_1");
        }
    
        private void OnLevel2ButtonClicked()
        {
            SceneManager.LoadScene("Level_2");
        }
        
        private void OnLevel3ButtonClicked()
        {
            SceneManager.LoadScene("Level_3");
        }
    }
}
