using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualFeedback : MonoBehaviour
{
    [Header("Animation timing")]
    [SerializeField] private float startCycleTime = 0.2f;
    [SerializeField] private float endCycleTime = 0.2f;
    [Header("Tween values")]
    [SerializeField] private Vector3 tweenLocalPosition = Vector3.zero;
    [SerializeField] private Vector3 tweenLocalRotation = Vector3.zero;
    [SerializeField] private Vector3 tweenScale = Vector3.one;

    private Vector3 originalLocalPosition;
    private Vector3 originalEulerAngles;
    private Vector3 originalScale;


    private void Awake()
    {
        SetDefaultValues();
    }
    private void OnEnable()
    {
        ResetToDefaultValues();
    }
    private void SetDefaultValues()
    {
        originalEulerAngles = transform.localEulerAngles;
        originalScale = transform.localScale;
        originalLocalPosition = transform.localPosition;
    }
    private void ResetToDefaultValues()
    {
        transform.localPosition = originalLocalPosition;
        transform.localEulerAngles = originalEulerAngles;
        transform.localScale = originalScale;
    }

    public void StartAnimation()
    {
        transform.DOLocalMove(originalLocalPosition+tweenLocalPosition, startCycleTime);
        transform.DOScale(tweenScale, startCycleTime);
        transform.DOLocalRotate(originalEulerAngles+tweenLocalRotation, startCycleTime).OnComplete(EndAnimation);
    }
    private void EndAnimation()
    {
        transform.DOLocalMove(originalLocalPosition, endCycleTime);
        transform.DOScale(originalScale, endCycleTime);
        transform.DOLocalRotate(originalEulerAngles, endCycleTime);
    }
}
