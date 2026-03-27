using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreamItem : InteractItem
{
    [SerializeField] private SpriteFade spriteFade;

    public override void OnPointerClick(PointerEventData eventData)
    {
        handController.transform.DOMove(transform.position + handController.GetOffset(), 0.5f).SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                handController.TakeItem(this);
                handController.transform.DOMove(Vector3.zero, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    handController.SetCanDrag(true);
                });
            });
    }

    public override void Apply()
    {
        spriteFade.ChangeAlpha();

        ReturnToDefault();
    }
}