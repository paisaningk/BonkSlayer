using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.BaseDog;

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private PlayerDog playerdog;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int playerHp;
    [SerializeField] private int playerSpeed;
    [SerializeField] public HealthBar healthBar;
    [SerializeField] private AllScore Scene;
    [SerializeField]public AudioClip Playerdie;
    internal Transform playerOnPostiton;
    internal  PlayerDog spawnedPlayerDog;
    internal int score;
    private int PlayerScore;
    public static LevelManager Instance { get; private set; }

    void Awake()
    {
        Spawn();
        SetScore(PlayerScore);
        playerOnPostiton = spawnedPlayerDog.transform;
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Update()
    {
        score = PlayerScore;
    }

    public void SetScore(int score)
    {
        PlayerScore += score;
        scoreText.text = $"Score : {PlayerScore}";
    }

    private void Spawn()
    {
        spawnedPlayerDog = Instantiate(playerdog, transform.position, transform.rotation);
        spawnedPlayerDog.Init(playerHp,playerSpeed);
        spawnedPlayerDog.OnExploded += OnPlayerDead;
    }

    private void OnPlayerDead()
    {
        AudioSource.PlayClipAtPoint(Playerdie,Camera.main.transform.position);
        var Enemydog = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in Enemydog)
        {
            Destroy(enemy);
        }
        var Playerdog = GameObject.FindGameObjectsWithTag("Player");
        foreach (var Player in Playerdog)
        {
            Destroy(Player);
        }

        if (Scene.Scene01 == true)
        {
            Scene.LoadScene01();
        }
        if (Scene.Scene02 == true)
        {
            Scene.LoadScene02();
        }
        if (Scene.Scene03 == true)
        {
            Scene.LoadScene03();
        }
    }
}
