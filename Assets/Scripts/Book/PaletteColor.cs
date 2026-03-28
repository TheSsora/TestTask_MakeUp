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
        brush.ClickAnimation(color, eyeShadow, transform.position);
    }
}
