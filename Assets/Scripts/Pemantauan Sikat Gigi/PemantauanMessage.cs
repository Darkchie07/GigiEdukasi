using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class PemantauanMessage : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public TextMeshProUGUI txtMessage;
    public ContentSizeFitter contentSize;
    public RectTransform rectTransform;
    public Canvas canvas;
    Vector2 firstPos;
    bool canDrag = false;
    [SerializeField] bool enteringDestroy = false;
    public void OnDrag(PointerEventData eventData)
    {
        if (!canDrag)
            return;
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x + GetMouseData(eventData).x, rectTransform.anchoredPosition.y);
        print($"Current x = {rectTransform.anchoredPosition.x}");
    }

    Vector2 GetMouseData(PointerEventData eventData)
    {
        return eventData.delta / canvas.scaleFactor;
    }

    public void SetText(string txt, Canvas canvas)
    {
        txtMessage.text = txt;
        contentSize.enabled = false;
        contentSize.enabled = true;
        this.canvas = canvas;
    }

    private void Awake()
    {
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + 100);
        StartCoroutine(StartTheData());
    }

    IEnumerator StartTheData()
    {
        float jarakToSpawn = rectTransform.anchoredPosition.y - 100;
        while (rectTransform.anchoredPosition.y > jarakToSpawn)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y - 10);
            yield return null;
        }
        firstPos = rectTransform.anchoredPosition;
        canDrag = true;
        Destroy(gameObject, 5);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!canDrag)
            return;
        if (enteringDestroy)
            Destroy(gameObject);
        else
            rectTransform.anchoredPosition = firstPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enteringDestroy = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enteringDestroy = false;
    }
}
