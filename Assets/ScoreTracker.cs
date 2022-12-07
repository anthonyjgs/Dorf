using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public int SCORE;
    public int WAVE;
    public int SCORETONEXTWAVE;

    public GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        if (gameState == null) Debug.LogException(new System.Exception("ScoreTracker is missing it's gameState reference!"));
        SCORE = 0;
        WAVE = 1;
        SCORETONEXTWAVE = 10;
    }

    // Safer way to access score from other scripts
    public int GetScore()
    {
        return SCORE;
    }

    // Increments score and performs necessary checks
    public int AddScore(int score){
        SCORE += score;
        if (SCORE >= SCORETONEXTWAVE)
        {
            NextWave();
        }
        return SCORE;
    }

    void NextWave()
    {
        WAVE += 1;
        SCORETONEXTWAVE += 5 * WAVE;
        gameState.gameStateMachine.ChangeState(gameState.gameNewWaveState);
    }
}
