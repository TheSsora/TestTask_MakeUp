using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Vector3 defaultPosition;
    [SerializeField] private Vector3 offset;
    [SerializeField] private InteractItem grabItem;
    [SerializeField] private Collider2D faceArea;

    public bool CanDrag = false;
    private bool isDragging = false;
    private Camera _camera;
    private Vector3 dragOffset;

    private void Awake()
    {
        _camera = Camera.main;
        defaultPosition = transform.position;
    }

    public Vector3 GetOffset() => offset;
    public void SetCanDrag(bool canDrag) => CanDrag = canDrag;
    public Vector3 GetFaceAreaPosition() => faceArea.transform.position;

    public void TakeItem(InteractItem item)
    {
        grabItem = item;
    }

    public void ReturnHand()
    {
        transform.DOMove(defaultPosition, 0.5f).SetEase(Ease.Linear);

        isDragging = false;
        CanDrag = false;

        grabItem = null;
        GameManager.instance.BookLocked = false;
    }

    private void Update()
    {
        if (grabItem)
        {
            grabItem.transform.position = transform.position - offset;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!CanDrag)
            return;

        isDragging = true;

        Vector3 mouseWorldPos = _camera.ScreenToWorldPoint(eventData.position);
        mouseWorldPos.z = transform.position.z;
        dragOffset = transform.position - mouseWorldPos;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging)
            return;

        Vector3 mouseWorldPos = _camera.ScreenToWorldPoint(eventData.position);
        mouseWorldPos.z = transform.position.z;

        Vector3 newPosition = mouseWorldPos + dragOffset;

        transform.position = newPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isDragging)
        {
            isDragging = false;
            return;
        }

        if (faceArea.OverlapPoint(grabItem.transform.position + Vector3.up))
        {
            grabItem.Apply();
        }
        else
        {
            grabItem.ReturnToDefault();
            ReturnHand();
        }
    }
}