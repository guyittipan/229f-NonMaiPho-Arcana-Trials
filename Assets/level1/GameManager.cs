using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int totalMonsters = 5;
    private int killedCount = 0;

    public float timeRemaining = 30f;
    public float bonusMultiplier = 2f;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI resultText; // Center screen score text
    private bool gameEnded = false;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (gameEnded) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timeText.text = "Time: " + Mathf.Ceil(timeRemaining).ToString();

            if (timeRemaining <= 0)
            {
                EndGame(bonus: false); // Time’s up – no bonus
            }
        }
    }

    public void MonsterKilled()
    {
        killedCount++;
        Debug.Log("Monster killed. Count = " + killedCount + " / " + totalMonsters);
        if (killedCount >= totalMonsters)
        {
            Debug.Log("All monsters killed → EndGame called");

            EndGame(bonus: true); // All monsters defeated – give time bonus
        }
    }

    void EndGame(bool bonus)
    {
        gameEnded = true;

        int finalScore = ScoreManager.instance.score;

        if (bonus)
        {
            int bonusScore = Mathf.CeilToInt(timeRemaining * bonusMultiplier);
            finalScore += bonusScore;
            ScoreManager.instance.AddScore(bonusScore);
        }

        resultText.text = "Final Score: " + finalScore;
        resultText.gameObject.SetActive(true); // Show result text
    }
}
