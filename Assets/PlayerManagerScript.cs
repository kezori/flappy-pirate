using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManagerScript : MonoBehaviour {
    public int highestScore;
    public Text highestScoreText;
    public LogicScript logic;
    // Start is called before the first frame update
    void Start() {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        using (StreamReader reader = new StreamReader("highscore.txt")) {
            highestScore = int.Parse(reader.ReadLine());
        }
    }

    // Update is called once per frame
    void Update() {
        updateHighestScore();
    }

    public void updateHighestScore() {
        if (logic.playerScrore > highestScore) {
            highestScore = logic.playerScrore;
            if (highestScore < 10) {
                highestScoreText.text = "0" + highestScore.ToString();
            }
            else {
                highestScoreText.text = highestScore.ToString();
            }
        }
    }
}
