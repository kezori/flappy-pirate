using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour {
    public int playerScrore = 0;
    public Text scoreText;
    public AudioSource dingSound;
    public GameObject gameOverScreen;
    public AudioSource pirateDeathSound;
    public PlayerManagerScript playerManager;

    void Start() {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManagerScript>();
    }

    [ContextMenu("Incresase Score")]
    public void addScore(int scoreToAdd = 1) {
        playerScrore += scoreToAdd;
        // add "0" to the left of the score if it is less than 10
        if (playerScrore < 10) {
            scoreText.text = "0" + playerScrore.ToString();
        }
        else {
            scoreText.text = playerScrore.ToString();
        }
        dingSound.Play();
    }

    public void restartGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver() {
        pirateDeathSound.Play();
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
        saveHighScore();
        using (StreamReader reader = new StreamReader("highscore.txt")) {
            playerManager.highestScore = int.Parse(reader.ReadLine());
        }
    }

    public void saveHighScore() {
        using (StreamWriter writer = new StreamWriter("highscore.txt")) {
            writer.WriteLine(playerManager.highestScore);
        }
    }
}
