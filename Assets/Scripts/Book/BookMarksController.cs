using System;
using System.Collections.Generic;
using UnityEngine;

public class BookMarksController : MonoBehaviour, IBookMarkHandler
{
    [SerializeField] List<BookMark> bookMarks;

    private void Awake()
    {
        foreach (var bookMark in bookMarks)
        {
            bookMark.Initialize(this);
        }
    }

    public void OnBookMarkClicked(BookMark bookMark)
    {
        foreach (var mark in bookMarks)
        {
            if (mark != bookMark && mark.GetActiveMark())
            {
                mark.Switch();
                break;
            }
        }
    }
}
