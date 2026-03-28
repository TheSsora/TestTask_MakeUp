using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResetMakeUp : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private List<SpriteRenderer> makeupSprites;

    public void Reset()
    {
        foreach (var makeup in makeupSprites)
        {
            if (makeup.color.a > 0)
            {
                makeup.color = new Color(1, 1, 1, 0);
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Reset();
    }
}
