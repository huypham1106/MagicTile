using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SafeArea : MonoBehaviour
{
    [SerializeField] private bool Top = true;
    [SerializeField] private bool Bottom = true;
    [SerializeField] private bool Left = true;
    [SerializeField] private bool Right = true;
        
    RectTransform Panel;
    Rect LastSafeArea = new Rect(0, 0, 0, 0);

    private void Start()
    {
        Panel = GetComponent<RectTransform>();
        ApplySafeArea(GetSafeArea());
    }

    void Update()
    {
        Refresh();
    }

    void Refresh()
    {
        Rect safeArea = GetSafeArea();

        if (safeArea != LastSafeArea)
            ApplySafeArea(safeArea);
    }

    Rect GetSafeArea()
    {
        Rect rect = new Rect(0, 0, Screen.width, Screen.height);
        if (Left)
        {
            rect.xMin = Screen.safeArea.xMin;
        }
        if (Right)
        {
            rect.xMax = Screen.safeArea.xMax;
        }
        if (Bottom)
        {
            rect.yMin = Screen.safeArea.yMin;
        }
        if (Top)
        {
            rect.yMax = Screen.safeArea.yMax;
        }
        return rect;
    }

    void ApplySafeArea(Rect r)
    {
        LastSafeArea = r;

        // Convert safe area rectangle from absolute pixels to normalized anchor coordinates
        Vector2 anchorMin = r.position;
        Vector2 anchorMax = r.position + r.size;
        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;
        Panel.anchorMin = anchorMin;
        Panel.anchorMax = anchorMax;
    }
}
