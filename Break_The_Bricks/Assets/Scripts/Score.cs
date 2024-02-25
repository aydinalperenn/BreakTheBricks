using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score = 0;

    public void IncreaseScore()
    {
        score++;
    }

    public int GetScore()
    {
        return score;
    }

    public void RestartScore()
    {
        score = 0;
    }
}
