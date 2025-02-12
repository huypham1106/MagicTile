using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private Text txtScore;
    [SerializeField] private List<Sprite> sprStatus;
    [SerializeField] private Image imgNodeStatus;
    [SerializeField] private CanvasGroup bgEffect;
    // Start is called before the first frame update
    private float rateInitBg = 0.2f;
    private Sequence _sequenceStatus;
    private Sequence _sequenceBgEffect;
    private CanvasGroup _cgNodeStatus;

    private void Awake()
    {
        _cgNodeStatus = imgNodeStatus.GetComponent<CanvasGroup>();
        Reset();
    }

    public void Reset()
    {
        _cgNodeStatus.alpha = 0f;
        txtScore.text = ScoreSystem.Instance.TotalScore().ToString();
        bgEffect.alpha = rateInitBg;
    }

    public void UpdateScoreUI(PointData data)
    {
        txtScore.text = data.TotalPoint.ToString();
        txtScore.transform.DOScale(1.4f, 0.3f).OnComplete(() => { txtScore.transform.DOScale(1f, 0f); });
        if (_sequenceStatus != null)
        {
            //_sequenceStatus.Complete();
            _sequenceStatus.Kill();
        }

        ShowBgEffect();
        ShowStatus(data.NodeState);
        Debug.Log("VO DAY");
    }

    private void ShowBgEffect()
    {
        if (_sequenceBgEffect != null) _sequenceBgEffect.Kill(); 

        // Tạo sequence mới
        _sequenceBgEffect = DOTween.Sequence(); 
        _sequenceBgEffect.Append(bgEffect.DOFade(1, 0.2f));
        _sequenceBgEffect.Append(bgEffect.DOFade(0.1f, 0.2f));
    }

    private void ShowStatus(NodeState nodeState)
    {
        Debug.Log("nodeState    "+ nodeState);
        switch (nodeState)
        {
            case NodeState.Fast:
                imgNodeStatus.sprite = sprStatus[0];
                break;
            case NodeState.VeryFast:
                imgNodeStatus.sprite = sprStatus[1];
                break;
            case NodeState.TopSpeed:
                imgNodeStatus.sprite = sprStatus[2];
                break;
        }
        if (_sequenceStatus != null)
        {
            _sequenceStatus.Kill();
        }
        _sequenceStatus = DOTween.Sequence(); 
        _sequenceStatus.Append(imgNodeStatus.gameObject.transform.DOScale(1.2f, 0f));
        _sequenceStatus.Join(_cgNodeStatus.DOFade(0f, 0f));
        _sequenceStatus.Append(imgNodeStatus.gameObject.transform.DOScale(1f, 0.3f));
        _sequenceStatus.Join(_cgNodeStatus.DOFade(1f, 0.3f));
        _sequenceStatus.Append(imgNodeStatus.gameObject.transform.DOScale(1.2f, 0f));
        _sequenceStatus.Join(_cgNodeStatus.DOFade(0f, 0f));
    }
}
