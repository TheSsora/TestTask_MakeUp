using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class EyeShadowBrush : InteractItem
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

    public override void Apply()
    {
        previousEyeShadow?.ChangeAlpha();

        previousEyeShadow = eyeShadow;

        eyeShadow.ChangeAlpha(1);
        ReturnToDefault();
    }
}