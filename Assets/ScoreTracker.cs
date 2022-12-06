using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public static int SCORE;
    public static int WAVE;
    public static int SCORETONEXTWAVE;
    // Start is called before the first frame update
    void Start()
    {
        SCORE = 0;
        WAVE = 1;
        SCORETONEXTWAVE = 10;
    }

    // Safer way to access score from other scripts
    public static int GetScore()
    {
        return SCORE;
    }

    // Increments score and performs necessary checks
    public static int AddScore(int score){
        SCORE += score;
        if (SCORE >= SCORETONEXTWAVE)
        {
            NextWave();
        }
        return SCORE;
    }

    static void NextWave()
    {
        WAVE += 1;
        SCORETONEXTWAVE += 5 * WAVE;
    }
}
