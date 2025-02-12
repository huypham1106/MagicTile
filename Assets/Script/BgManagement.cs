using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgManagement : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprBgs;
    [SerializeField] private Image imageBg;

    private int lastIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(sprBgs.Count == 0) return;
        imageBg.sprite = sprBgs[0];
    }
    
    public void ChangeRandomBg()
    {
        if (sprBgs.Count == 0) return;

        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, sprBgs.Count); 
        } while (randomIndex == lastIndex && sprBgs.Count > 1); 

        lastIndex = randomIndex; 
        imageBg.sprite = sprBgs[randomIndex];
    }

}
