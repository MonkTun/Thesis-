using UnityEngine;
using UnityEngine.UI;
public static class ScrollRectExtensions
{
    public static void ScrollToTop(this ScrollRect scrollRect) //inorder to this work, scroll has to be setup well so do well with enables
    {
        scrollRect.normalizedPosition = new Vector2(0, 1);
    }
    public static void ScrollToBottom(this ScrollRect scrollRect)
    {
        scrollRect.normalizedPosition = new Vector2(0, 0);
    }
}