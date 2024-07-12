using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableAnswerButton : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private bool _isThisTheRightAnswer;

    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private Vector2 _initPos;

    #region PROPERTIES
    public bool IsThisRightAnswer => _isThisTheRightAnswer;
    #endregion


    private void Awake()
    {
        if (!TryGetComponent(out CanvasGroup canvasGroup)) return;
        _canvasGroup = canvasGroup;

        if (!TryGetComponent(out RectTransform rectTransform)) return;
        _rectTransform = rectTransform;

        _initPos = _rectTransform.anchoredPosition;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer Down");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        _canvasGroup.alpha = 0.6f;
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
    }

    public void ReturnToOriginalPos()
    {
        _rectTransform.anchoredPosition = _initPos;
    }
}
