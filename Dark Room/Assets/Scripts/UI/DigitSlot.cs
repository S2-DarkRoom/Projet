using UnityEngine;
using UnityEngine.UI;

public class DigitSlot : MonoBehaviour
{
    public Image icon;
    public Sprite[] digits = new Sprite[10];

    public void AddDigit(int i)
    {
        icon.sprite = digits[i];
        icon.enabled = true;
    }

    public void DeleteDigit()
    {
        icon.enabled = false;
    }
}
