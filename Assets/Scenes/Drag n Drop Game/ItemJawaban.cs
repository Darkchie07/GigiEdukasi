using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ItemJawaban : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public class FirstInstance
    {

    }

    public FirstInstance firstInstance;
    private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;
    [SerializeField] private CanvasGroup canvasGroup;
    public Transform parentAwal;
    public Transform parentNow;
    public Transform enterSomething;
    private void Awake()
    {
        parentAwal = transform.parent;
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    #region DRAG EVENT
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.parent = canvas.transform;
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += GetMouseData(eventData);
    }

    Vector2 GetMouseData(PointerEventData eventData)
    {
        return eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (enterSomething != null)
        {
            InsertParent();
        }
        else
        {
            EmptyTheParent();
        }
    }
    #endregion


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<DropAnswerSlot>())
        {
            enterSomething = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform == enterSomething)
            enterSomething = null;
    }

    public void EmptyTheParent()
    {
        if (parentNow)
            if (parentNow.GetComponent<DropAnswerSlot>())
                parentNow.GetComponent<DropAnswerSlot>().itemInside = null;

        transform.parent = null;
        parentNow = null;

        transform.parent = parentAwal;
        parentNow = parentAwal;
        transform.localPosition = Vector2.zero;
    }

    public void InsertParent()
    {

        DropAnswerSlot dp = enterSomething.GetComponent<DropAnswerSlot>();
        //cek item didalamnya
        if (dp.itemInside) // jika ada isinya        
            dp.itemInside.EmptyTheParent();


        transform.parent = enterSomething;
        parentNow = enterSomething;
        transform.localPosition = Vector2.zero;
        dp.itemInside = this;
    }
}
