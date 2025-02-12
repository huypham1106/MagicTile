using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StarBar : MonoBehaviour
{
    [SerializeField] private List<GameObject> stars;
    [SerializeField] private Image imgBarProgress;


    public void SetBarAndStar(float percent)
    {
        float curFillAmount = imgBarProgress.fillAmount;

        DOTween.To(() => curFillAmount, x => imgBarProgress.fillAmount = x, percent, 0.5f).OnComplete(()=>
        {
            stars[0].SetActive(percent >= 0.33f);
            stars[1].SetActive(percent >= 0.66f);
            stars[2].SetActive(percent >= 1f);
        }
        );

    }    

    public void ResetStarAndBar()
    {
        float curFillAmount = imgBarProgress.fillAmount;

        DOTween.To(() => curFillAmount, x => imgBarProgress.fillAmount = x, 0f, 0.5f).OnComplete(() =>
        {
            stars[0].SetActive(false);
            stars[1].SetActive(false);
            stars[2].SetActive(false);
        }
        );
    }    
}
