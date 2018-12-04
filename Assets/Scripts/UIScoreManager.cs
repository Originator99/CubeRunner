using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreManager : MonoBehaviour {

    public Text scoreText;

    private float score = 0;
    private float scoreToNextLevel = 10;
    private float difficultyLevel = 1;
    private float maxDifficultyLevel = 10;

    private void Update()
    {
        if (score > scoreToNextLevel)
            LevelUp();
        score += Time.deltaTime * difficultyLevel;
        scoreText.text = ((int)score).ToString();
    }

    private void LevelUp() {
        if (difficultyLevel == maxDifficultyLevel)
            return;
        scoreToNextLevel *= 2;
        difficultyLevel++;
        GetComponent<PlayerMotor>().SetSpeed(difficultyLevel);
    }
}
