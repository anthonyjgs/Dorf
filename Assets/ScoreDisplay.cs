using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private Text text;
    private int currentScore;
    [SerializeField] private ScoreTracker scoreTracker;

    void Start()
    {
        text = GetComponent<Text>();
        text.text = scoreTracker.SCORE.ToString();
    }

    void Update()
    {
        int newScore = scoreTracker.SCORE;
        if (newScore != currentScore)
        {
            currentScore = newScore;
            text.text = currentScore.ToString();
        }
    }
}
