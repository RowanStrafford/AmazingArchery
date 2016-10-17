using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private float score = 0;
    public Text scoreText;

    void Awake()
    {
        scoreText.text = "Score : " + score;
    }

    public void addScore(float scoreToAdd)
    {
        score += Mathf.Round(scoreToAdd);
        scoreText.text = "Score : " + score;
    }
}
