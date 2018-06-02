using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    public Sprite sprite;
    public PaperType type;

    public enum PaperType
    {
        GAME_INFO,
        CODE_PART,
        CLUE
    };
    
}
