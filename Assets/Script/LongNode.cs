using Hawki.EventObserver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class LongNode : CommonNode, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float speedScroll;
    [SerializeField] private GameObject line;
    [SerializeField] private Image imgLongNode;
    [SerializeField] private GameObject pointA, pointB, vfxSpiky;

    public override void InitData(int id, bool isRealNode, float speedFall)
    {
        base.InitData(id, isRealNode, speedFall);
    }

    public void InitData(int id, bool isRealNode, float speedFall, float speedScroll)
    {
        InitData(id, isRealNode, speedFall);
        this.speedScroll = speedScroll;

        if (isRealNode)
        {
            Utilities.SetAlpha(255f, imgLongNode);
            line.SetActive(true);
        }
        else
        {
            Utilities.SetAlpha(0f, imgLongNode);
            line.SetActive(false);
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (!isRealNode)
        {
            errorMaskNode.SetActive(true);
            EventObs.Instance.ExcuteEvent(EventName.LOSE_GAME, new LoseGameEvent { });
            return;
        }

        NodeState nodeState = GetStatus();
        if (GamePlayController.Instance.TryClickNode(id, nodeState))
        {
            isDragging = true;
            vfxSpiky.SetActive(true);
            StartScrollEffect();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        _scrollSequence?.Kill();
    }

    private void StartScrollEffect()
    {
        _scrollSequence = DOTween.Sequence();
        _scrollSequence.Append(maskNode.transform.DOScale(1f, speedScroll));
        _scrollSequence.Join(vfxSpiky.transform.DOLocalMoveY(pointB.transform.localPosition.y, speedScroll));
    }

    protected override void ResetNode()
    {
        base.ResetNode();
        vfxSpiky.SetActive(false);
        vfxSpiky.transform.DOLocalMoveY(pointA.transform.localPosition.y, speedScroll);
        maskNode.SetActive(true);
        maskNode.transform.localScale= new Vector3(1f,0f,1f);
    }
}
