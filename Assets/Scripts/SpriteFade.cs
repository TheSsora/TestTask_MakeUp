using System;
using DG.Tweening;
using UnityEngine;

[Serializable]
public class SpriteFade : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        if(!spriteRenderer)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    public void ChangeAlpha(float targetAlpha = 0)
    {
        spriteRenderer.DOFade(targetAlpha, 1.5f);
    }
}
