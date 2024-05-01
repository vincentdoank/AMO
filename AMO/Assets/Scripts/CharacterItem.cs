using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterItem : MonoBehaviour
{
    private AvatarInfo info;

    public Image characterImage;
    public TMP_Text characterNameText;

    private Toggle toggle;

    public void Init(AvatarInfo info, ToggleGroup toggleGroup)
    {
        this.info = info;
        characterImage.sprite = info.avatarSprite;
        characterNameText.text = info.avatarName;


        toggle = GetComponent<Toggle>();
        toggle.group = toggleGroup;
    }
}
