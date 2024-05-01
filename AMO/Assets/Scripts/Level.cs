using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public Image levelPanel;
    public TMP_Text levelText;

    public void SetLevel(string level)
    {
        levelText.text = "LEVEL " + level;
    }

    public void SetLevel(int level)
    {
        SetLevel(level.ToString());
    }
}
