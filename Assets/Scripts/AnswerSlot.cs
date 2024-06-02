using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnswerSlot : MonoBehaviour, IDropHandler
{
    private RectTransform _rectTransform;

    private void Awake()
    {
        if (!TryGetComponent(out RectTransform rectTransform)) return;
        _rectTransform = rectTransform;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            Debug.Log("OnDrop");
            if (!eventData.pointerDrag.TryGetComponent(out RectTransform droppedObjRectTransform)) return;
            droppedObjRectTransform.anchoredPosition = _rectTransform.anchoredPosition;
            
        }
    }

}
