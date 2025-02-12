using Hawki.EventObserver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShortNode : CommonNode, IPointerDownHandler
{
    [SerializeField] private Image imgShortNode;
    [SerializeField] private ParticleSystem vfxLava;

    public override void InitData(int id, bool isRealNode, float speedFall)
    {
        base.InitData(id, isRealNode, speedFall);
        Utilities.SetAlpha(isRealNode ? 255f : 0f, imgShortNode);
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
            maskNode.SetActive(true);
            vfxLava.Play();
        }
    }
}
