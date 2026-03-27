using UnityEngine;
using UnityEngine.EventSystems;

public class BookMark : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject activeMark;
    [SerializeField] private GameObject inactiveMark;
    [SerializeField] private GameObject palette;

    private IBookMarkHandler bookMarkHandler;
    
    public bool GetActiveMark() => activeMark.activeInHierarchy;
    public void Switch()
    {
        activeMark.SetActive(!activeMark.activeInHierarchy);
        inactiveMark.SetActive(!inactiveMark.activeInHierarchy);
        palette!.SetActive(!palette.activeInHierarchy);
    }
    public void Initialize(IBookMarkHandler handler)
    {
        bookMarkHandler = handler;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (activeMark.activeInHierarchy)
            return;
        
        Switch();
        bookMarkHandler.OnBookMarkClicked(this);
    }
}
