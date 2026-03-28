using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class LipstickItem : InteractItem
{
    [SerializeField] private SpriteFade lipstickSprite;

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
        Vector3 faceCenter = handController.GetFaceAreaPosition() + Vector3.down + handController.GetOffset();

        handController.transform.DOMove(faceCenter, 0.5f).OnComplete(() =>
        {
            GameManager.instance.LipstickPrebSprite?.ChangeAlpha();
            lipstickSprite.ChangeAlpha(1);

            handController.transform.DOMove(faceCenter + new Vector3(1, 0, 0), 0.5f).OnComplete(() =>
            {
                handController.transform.DOMove(faceCenter - new Vector3(1, 0, 0), 0.5f).OnComplete(() =>
                {
                    handController.transform.DOMove(faceCenter, 0.5f).OnComplete(() =>
                    {
                        ReturnToDefault();
                        GameManager.instance.LipstickPrebSprite = lipstickSprite;
                    });
                });
            });
        });
    }
}