using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class PaletteColor : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private SpriteFade eyeShadow;
    [SerializeField] private Color color;
    [SerializeField] private EyeShadowBrush brush;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        brush.GetHandController().transform.DOMove(brush.transform.position + brush.GetHandController().GetOffset(), 0.5f).SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                brush.GetHandController().TakeItem(brush);
                brush.GetHandController().transform.DOMove(transform.position - new Vector3(-0.5f, 1.5f, 0), 0.5f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    brush.Init(color, eyeShadow);
                    brush.GetHandController().transform.DOMove(Vector3.zero - new Vector3(-0.5f, 1.5f, 0), 0.5f).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        brush.GetHandController().SetCanDrag(true);
                    });
                });
            });
    }
}
