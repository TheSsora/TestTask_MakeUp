using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class InteractItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] protected HandController handController;
    private Vector3 defaultPosition;

    public HandController GetHandController() => handController;
    private void Awake()
    {
        defaultPosition = transform.position;
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        
    }

    public virtual void ReturnToDefault()
    {
        transform.DOMove(defaultPosition, 0.5f);
        handController.ReturnHand();
    }

    public virtual void Apply()
    {
        
    }
}