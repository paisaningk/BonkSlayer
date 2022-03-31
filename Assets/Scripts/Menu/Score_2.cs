using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score_2 : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button RestartButton;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int Scoreplayer;

    private void Awake()
    {
        Scoreplayer = 0;
        Cursor.visible = true;
        backButton.onClick.AddListener(OnBackButtonClicked);
        RestartButton.onClick.AddListener(OnRestartButtonClicked);
        Scoreplayer = LevelManager.Instance.score;
        finalScore(Scoreplayer);
    }
    
    public void finalScore(int score)
    {
        scoreText.text = $"Final Score : {score}";
    }
    
    private void OnBackButtonClicked()
    {
        SceneManager.LoadScene("Select Level Scene");
    }
    
    private void OnRestartButtonClicked()
    {
        SceneManager.LoadScene("Level_2");
    }
}
