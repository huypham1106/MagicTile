using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour
{
    private string currentLevel = "currentLevel";
    private string bestScore = "bestScore";

    public static UserData Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

    }

    public int CurrentLevel
    {
        get
        {
            if (PlayerPrefs.HasKey(currentLevel))
            {
                return PlayerPrefs.GetInt(currentLevel);
            }
            else
            {
                PlayerPrefs.SetInt(currentLevel, 1);
                return 1;
            }
        }
        set { PlayerPrefs.SetInt(currentLevel, value); }
    }   
    public int BestScore
    {
        get
        {
            if (PlayerPrefs.HasKey(bestScore))
            {
                return PlayerPrefs.GetInt(bestScore);
            }
            else
            {
                PlayerPrefs.SetInt(bestScore, 0);
                return 0;
            }
        }
        set { PlayerPrefs.SetInt(bestScore, value); }
    }    


}
