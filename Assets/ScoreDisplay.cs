using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private Text text;
    private int currentScore;

    void Start()
    {
        text = GetComponent<Text>();
        text.text = ScoreTracker.SCORE.ToString();
    }

    void Update()
    {
        int newScore = ScoreTracker.SCORE;
        if (newScore != currentScore)
        {
            currentScore = newScore;
            text.text = currentScore.ToString();
        }
    }
}
