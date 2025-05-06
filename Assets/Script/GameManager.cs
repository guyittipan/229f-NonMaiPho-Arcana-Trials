using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int totalMonsters = 5;
    private int killedCount = 0;

    public float timeRemaining = 30f;
    public float bonusMultiplier = 2f;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI resultText;

    public CanvasGroup fadeCanvas;           // Reference to black fade image
    public float fadeDuration = 1f;          // How long to fade
    public string nextSceneName = "Level2";  // Name of next scene

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

        StartCoroutine(FadeAndLoadNextScene());
    }

    IEnumerator FadeAndLoadNextScene()
    {
    // 🕒 Wait before fade starts (e.g., show score for 3 seconds)
    yield return new WaitForSeconds(3f);

    float timer = 0f;
    fadeCanvas.blocksRaycasts = true;

    while (timer < fadeDuration)
    {
        timer += Time.deltaTime;
        fadeCanvas.alpha = Mathf.Lerp(0, 1, timer / fadeDuration);
        yield return null;
    }

    yield return new WaitForSeconds(0.5f);
    SceneManager.LoadScene(nextSceneName);
    }

}
