using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject GameOverMenu;
    public Text livesText;
    public Text scoreText;
    public float bulletDamage = 2f;
    public float moveSpeed = 5f;
    //public float nextShot =100f;
    public float fireRate = 10f;

    public int score = 0;
    public int scoreMult = 1;

    void Start()
    {
        livesText.text = GameObject.Find("player").GetComponent<PlayerManager>().lifes.ToString();
        scoreText.text = score.ToString();
    }
    public void EndGame()
    {
        GameOverMenu.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }

    void Update()
    {
        UpdateLives();

    }

    public void UpdateLives()
    {
        livesText.text = GameObject.Find("player").GetComponent<PlayerManager>().lifes.ToString();
        if (GameObject.Find("player").GetComponent<PlayerManager>().lifes <= 0)
        {
            livesText.text = ":(";
        }
    }

    public void UpdateScore()
    {
        scoreMult++;
        score += 100 * scoreMult;
        scoreText.text = score.ToString();
    }

}

