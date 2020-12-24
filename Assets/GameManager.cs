using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    int score;

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "0";
    }

    public void incScore(int amount) {
        score += amount;
        scoreText.text = "" + score;
    }

    public void resetScore() {
        score = 0;
        scoreText.text = "0";
    }
}
