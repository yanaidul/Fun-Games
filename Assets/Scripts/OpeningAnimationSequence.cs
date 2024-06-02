using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using DG.Tweening;

public class OpeningAnimationSequence : MonoBehaviour
{
    [SerializeField] private RectTransform _headerText;
    [SerializeField] private RectTransform _subHeaderText;
    [SerializeField] private RectTransform _playButton;
    [SerializeField] private RectTransform _aboutButton;
    [SerializeField] private RectTransform _exitButton;

    [TabGroup("Header Animation Variables")]
    [SerializeField] private float _headerDuration1, _headerDuration2, _headerDuration3, _headerScaleX1, _headerScaleX2;
    [TabGroup("SubHeader Animation Variables")]
    [SerializeField] private float _subHeaderDuration1, _subHeaderDuration2, _subHeaderDuration3, _subHeaderScaleX1, _subHeaderScaleX2;

    private float _initHeaderPosY;
    private float _initSubHeaderPosX;
    private float _initPlayButtonPosY;
    private float _initAboutButtonPosY;
    private float _initExitButtonPosY;

    private void Start()
    {
        OnStartAnimation();
    }

    [Button]
    public void OnStartAnimation()
    {
        Sequence startAnimationSequence = DOTween.Sequence();

        _initHeaderPosY = _headerText.anchoredPosition.y;
        _initSubHeaderPosX = _headerText.anchoredPosition.x;
        _initPlayButtonPosY = _playButton.anchoredPosition.y;
        _initAboutButtonPosY = _aboutButton.anchoredPosition.y;
        _initExitButtonPosY = _exitButton.anchoredPosition.y;

        _headerText.anchoredPosition += new Vector2(0, 500);
        _subHeaderText.anchoredPosition -= new Vector2(1000, 0);
        _playButton.anchoredPosition = new Vector2(0, -200);
        _aboutButton.anchoredPosition = new Vector2(0, -200);
        _exitButton.anchoredPosition = new Vector2(0, -200);

        startAnimationSequence.Append(_headerText.DOAnchorPosY(_initHeaderPosY, _headerDuration1));
        startAnimationSequence.Insert(0, _headerText.DOScaleX(_headerScaleX1, _headerDuration2));
        startAnimationSequence.Append(_headerText.DOScaleX(_headerScaleX2, _headerDuration3).SetEase(Ease.InOutBack));

        startAnimationSequence.Append(_subHeaderText.DOAnchorPosX(_initSubHeaderPosX, _subHeaderDuration1));
        startAnimationSequence.Insert(0, _subHeaderText.DOScaleX(_subHeaderScaleX1, _subHeaderDuration2));
        startAnimationSequence.Append(_subHeaderText.DOScaleX(_subHeaderScaleX2, _subHeaderDuration3).SetEase(Ease.InOutBack));

        startAnimationSequence.Append(_playButton.DOAnchorPosY(_initPlayButtonPosY, 0.3F));
        startAnimationSequence.Append(_aboutButton.DOAnchorPosY(_initAboutButtonPosY, 0.3F));
        startAnimationSequence.Append(_exitButton.DOAnchorPosY(_initExitButtonPosY, 0.3F));
    }
}
