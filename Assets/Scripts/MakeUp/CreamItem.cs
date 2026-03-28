using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreamItem : InteractItem
{
    [SerializeField] private SpriteFade spriteFade;

    public override void OnPointerClick(PointerEventData eventData)
    {
        GameManager.instance.BookLocked = true;
        handController.transform.DOMove(transform.position + handController.GetOffset(), 0.5f).SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                handController.TakeItem(this);
                handController.transform.DOMove(Vector3.zero - new Vector3(-0.5f, 1.5f, 0), 0.5f).SetEase(Ease.Linear)
                    .OnComplete(() => { handController.SetCanDrag(true); });
            });
    }

    public override void Apply()
    {
        spriteFade.ChangeAlpha();

        ReturnToDefault();
    }
}