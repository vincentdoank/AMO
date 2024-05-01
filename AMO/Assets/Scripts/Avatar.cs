using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class AvatarInfo
{
    public string avatarId;
    public Sprite avatarSprite;
    public string avatarName;
    public int level;
    public int mood;
    public enum StageType
    {
        Baby,
        Toddler,
        Teen,
        Adult
    }
    public StageType stageType;
    public float energy;

    public string headAccessoryId;
    public string bodyAccessoryId;
    public string handAccessoryId;
    public string shoesAccesoryId;

    public GameObject characterPrefab;
    public bool isUnlocked;
}

public class Avatar : MonoBehaviour
{
    public Image avatarPanel;
    public Image avatarImage;
    public TMP_Text avatarNameText;

    private Button switchCharacterButton;

    private AvatarInfo info;

    private void Start()
    {
        switchCharacterButton = GetComponent<Button>();
        switchCharacterButton.onClick.AddListener(OpenCharacterSelection);
    }

    public void SetAvatar(AvatarInfo info)
    {
        this.info = info;
        avatarImage.sprite = info.avatarSprite;
        avatarNameText.text = info.avatarName;
    }

    private void OpenCharacterSelection()
    {
        HomeController.Instance.ShowCharacterSelection(true);
    }
}
