using DanielLochner.Assets.SimpleScrollSnap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public GameObject characterItemPrefab;
    public Transform characterItemParent;
    public SimpleScrollSnap simpleScrollSnap;

    private ToggleGroup toggleGroup;

    private void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();
        Init();
        gameObject.SetActive(false);
        simpleScrollSnap.OnPanelCentered.AddListener(OnItemSelected);
    }

    private void Init()
    {
        List<AvatarInfo> infoList = Character.Instance.GetAvatarInfoList();
        for (int i = 0; i < infoList.Count; i++)
        {
            if (infoList[i].isUnlocked)
            {
                AvatarInfo info = infoList[i];
                GameObject item = Instantiate(characterItemPrefab, characterItemParent, false);
                CharacterItem characterItem = item.GetComponent<CharacterItem>();
                characterItem.Init(info, toggleGroup);
            }
        }

        simpleScrollSnap.Setup();
    }

    private void OnItemSelected(int to, int from)
    {
        simpleScrollSnap.Content.GetChild(to).GetComponent<Toggle>().isOn = true;
    
        
    }
}
