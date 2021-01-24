using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    static private ScoreManager _inst;
    static public ScoreManager Inst
    {
        get { return _inst; }
    }


    [SerializeField] public Text scoreText;

    private int score;


    private void Awake()
    {
        _inst = this;
    }


    public void AddPoints (int pointsToAdd)
    {
        score += pointsToAdd;
        UpdateScoreDisplay();
    }


    public void UpdateScoreDisplay ()
    {
        scoreText.text = score.ToString();
    }
}
