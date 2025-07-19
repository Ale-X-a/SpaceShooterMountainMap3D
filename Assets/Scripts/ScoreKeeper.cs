using TMPro;
using UnityEngine;

public class ScoreKeeper: MonoBehaviour
{
    int score;
    TMP_Text scoreText;

    void Start()
    {
        scoreText = FindFirstObjectByType<TMP_Text>();
        scoreText.text = "Score: 0";
        
    }
    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;
        //score = score + amount to increase
        scoreText.text = "Score: " + score.ToString();
        Debug.Log("Score:" + score);
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        
    }
}
