using Hawki.EventObserver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupEndGame : MonoBehaviour
{
    [SerializeField] private Text txtTitle;
    [SerializeField] private Text txtScore;
    [SerializeField] private Button btnRestart;
    // Start is called before the first frame update
    void Start()
    {
        btnRestart.onClick.AddListener(OnClickRestartBtn);
    }

    public void ShowPopup(PopupEndGameData data)
    {
        txtTitle.text = data.Title;
        txtScore.text = "Score: " + data.Score.ToString();
        if(!data.IsWin) btnRestart.gameObject.SetActive(true);
        gameObject.SetActive(true);
    }    
    public void HidePopup()
    {
        gameObject.SetActive(false);
    }    

    private void OnClickRestartBtn()
    {
        gameObject.SetActive(false);
        EventObs.Instance.ExcuteEvent(EventName.REPLAY, new ReplayEvent{});
        EventObs.Instance.ExcuteEvent(EventName.CHANGE_BG, new ReplayEvent{});
    }
}
public class PopupEndGameData
{
    public string Title;
    public int Score;
    public bool IsWin;

    public PopupEndGameData(string title, int score, bool isWin)
    {
        this.Title = title;
        this.Score = score;
        this.IsWin = isWin;
    }
}

