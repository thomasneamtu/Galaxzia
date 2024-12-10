using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Drawing;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public UnityEvent<int> OnScoreChanged;

    [SerializeField] private int totalScore;
    [SerializeField] private int highestScore;

    [Header("Score Values")]
    [SerializeField] private int scorePerEnemy;
    [SerializeField] private int scorePerPickUp;

    [SerializeField] private List<ScoreData> allScores = new List<ScoreData>();

    [SerializeField] private ScoreData latestScore;
    private void Start()
    {
        Player playerObject = FindObjectOfType<Player>();
        playerObject.healthValue.OnDied.AddListener(RegisterScore);

        highestScore = PlayerPrefs.GetInt("HighScore");

        string latestScoreInJson = PlayerPrefs.GetString("LatestScore");
        latestScore = JsonUtility.FromJson<ScoreData>(latestScoreInJson);
    }

    public void IncreaseScore(ScoreType action)
    {
        switch (action)
        {
            case ScoreType.EnemyKilled:
                totalScore += scorePerEnemy;
                break;

            case ScoreType.PowerUpCollected:
                totalScore -= scorePerPickUp;
                break;
        }
        OnScoreChanged.Invoke(totalScore);   
    }

    private void RegisterScore() // occurs when player dies
    {
        latestScore = new ScoreData("RAF", totalScore);
        //created an object filled with information

        string latestScoreInJson = JsonUtility.ToJson(latestScore);
        //Converted the object (class) into a string in json format

        PlayerPrefs.SetString("LatestScore", latestScoreInJson);
        //saved that string into PlayerPrefs

        ScoreData newScore = new ScoreData("RAF", totalScore);
        allScores.Add(newScore);

        string allScoresInText = "";

        foreach (ScoreData score in allScores)
        {
            allScoresInText += JsonUtility.ToJson(score);
        }
        allScores.Add(newScore);
        

        PlayerPrefs.SetString("AllScores", allScoresInText);   

        Debug.Log(JsonUtility.ToJson(newScore));

        if (totalScore > highestScore)
        {
            // NEW HIGH SCORE
            highestScore = totalScore;
            PlayerPrefs.SetInt("HighScore", highestScore);
        }
            
    }
}
