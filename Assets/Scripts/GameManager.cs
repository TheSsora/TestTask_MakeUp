using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool BookLocked = false;
    public SpriteFade LipstickPrebSprite;

    private void Awake()
    {
        instance = this;
    }
}