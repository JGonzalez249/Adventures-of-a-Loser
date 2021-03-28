using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;
using System;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public Transform respawnPoint;
    public GameObject playerPrefab;

    public CinemachineVirtualCameraBase cam;



    [Header("Player Health")]
    public int playerLives;
    public Text LivesUI;

    [Header("Coins")]
    public int coins = 0;
    public Text coinsUI;

    private Animator anim;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

        playerLives = 3;

        if (SceneManager.GetSceneByBuildIndex(0).isLoaded)
        {
            LivesUI.text = "Lives: " + playerLives;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Gameover();

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("You have sucessfully quit!");
        }
    }

    void Gameover()
    {
        if (playerLives <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void CountCoins()
    {
        if (coins >= 150)
        {
            anim.SetBool("hasEnoughCoins", true);
        }
    }

    public void Respawn()
    {
       GameObject player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);

        cam.Follow = player.transform;
    }

    public void DecreaseHealth(int health)
    {
        playerLives -= health;
        LivesUI.text = "Lives: " + playerLives;
    }

    public void IncreaseCoins(int amount)
    {
        coins += amount;
        coinsUI.text = "Coins: " + coins;
    }
}
