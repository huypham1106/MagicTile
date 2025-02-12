using System;
using System.Collections;
using System.Collections.Generic;
using Hawki.EventObserver;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public abstract class CommonNode : MonoBehaviour
{
    [SerializeField] protected float speedFall;
    [SerializeField] protected GameObject maskNode;
    [SerializeField] protected GameObject errorMaskNode;
    protected float perfectTime;
    protected int id;
    protected bool isRealNode;
    protected bool isDragging;
    protected Sequence _scrollSequence;

    private void OnEnable()
    {
        StartCoroutine(MoveDownCoroutine());
    }

    private void OnDisable()
    {
        ResetNode();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("HitZone"))
        {
            perfectTime = Time.time;
        }
        else if (other.gameObject.CompareTag("EndTaskBar"))
        {
            if (!GamePlayController.Instance.IsClicked(id) && isRealNode)
            {
                EventObs.Instance.ExcuteEvent(EventName.LOSE_GAME, new LoseGameEvent { });
            }
            gameObject.SetActive(false);
        }
    }

    protected virtual IEnumerator MoveDownCoroutine()
    {
        while (true)
        {
            transform.position -= new Vector3(0f, speedFall, 0f) * Time.deltaTime;
            yield return null;
        }
    }

    public virtual void InitData(int id, bool isRealNode, float speedFall)
    {
        ResetNode();
        perfectTime = Time.time;
        this.speedFall = speedFall;
        this.id = id;
        this.isRealNode = isRealNode;
        gameObject.SetActive(true);
    }

    protected virtual void ResetNode()
    {
        transform.localPosition = Vector3.zero;
        maskNode.SetActive(false);
        errorMaskNode.SetActive(false);
        isDragging = false;
        StopAllCoroutines();
    }

    protected NodeState GetStatus()
    {
        float hitAccuracy = Mathf.Abs(Time.time - perfectTime);
        if (hitAccuracy < 0.2f) return NodeState.TopSpeed;
        else if (hitAccuracy < 0.35f) return NodeState.VeryFast;
        return NodeState.Fast;
    }

    public void PauseNode()
    {
        StopAllCoroutines();
    }

    public abstract void OnPointerDown(PointerEventData eventData);
}
public enum NodeState
{
    NotClick,
    Fast,
    VeryFast,
    TopSpeed
}
