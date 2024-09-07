using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
    private RectTransform rectTransform;
    [SerializeField]  private float delay = 2500f;
    private Vector2 startPosition;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.anchoredPosition;
        // place the object outside the screen on the bottom
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -1000);
        StartCoroutine(StartAnimation());
    }

    IEnumerator StartAnimation()
    {
        yield return new WaitForSeconds(delay);
        float yPosition = startPosition.y;
        // move the object back to the start position
        while (rectTransform.anchoredPosition.y < yPosition)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + 10);
            yield return new WaitForSeconds(0.01f);
        }
    }

}
