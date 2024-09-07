using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeAnimation : MonoBehaviour
{
    private RectTransform rectTransform;
    private float ogYPosition;
    [SerializeField]  private float frequency = 1f;
    [SerializeField]  private float amplitude = 100f;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        ogYPosition = rectTransform.anchoredPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        float yPosition = Mathf.Sin(Time.time * frequency) * amplitude + amplitude;

        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, ogYPosition+yPosition);
 
    }
}
