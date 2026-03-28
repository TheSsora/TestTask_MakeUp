using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class Brush : InteractItem
{
    [SerializeField] private SpriteFade eyeShadow;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SpriteFade previousEyeShadow;

    public void Init(Color color, SpriteFade shadow)
    {
        spriteRenderer.color = new Color(color.r, color.g, color.b, 1);
        eyeShadow = shadow;
    }

    public override void ReturnToDefault()
    {
        base.ReturnToDefault();
        spriteRenderer.color = Color.white;
    }

    public void ClickAnimation(Color color, SpriteFade shadow, Vector3 colorPosition)
    {
        GameManager.instance.BookLocked = true;
        
        handController.transform.DOMove(transform.position + handController.GetOffset(), 0.5f).SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                handController.TakeItem(this);
                handController.transform.DOMove(colorPosition - new Vector3(-0.5f, 1.5f, 0), 0.5f)
                    .SetEase(Ease.Linear).OnComplete(() =>
                    {
                        Init(color, shadow);
                        handController.transform.DOMove(Vector3.zero - new Vector3(-0.5f, 1.5f, 0), 0.5f)
                            .SetEase(Ease.Linear).OnComplete(() => { handController.SetCanDrag(true); });
                    });
            });
    }

    public override void Apply()
    {
        Vector3 faceCenter = handController.GetFaceAreaPosition() + Vector3.down + handController.GetOffset();
        
        handController.transform.DOMove(faceCenter, 0.5f).OnComplete(() =>
        {
            previousEyeShadow?.ChangeAlpha();
            eyeShadow.ChangeAlpha(1);
            
            handController.transform.DOMove(faceCenter + new Vector3(1,0,0), 0.5f).OnComplete(() =>
            {
                handController.transform.DOMove(faceCenter - new Vector3(1,0,0), 0.5f).OnComplete(() =>
                {
                    handController.transform.DOMove(faceCenter, 0.5f).OnComplete(() =>
                    {
                        ReturnToDefault();
                        previousEyeShadow = eyeShadow;
                    });
                });
            });
        });
    }
}