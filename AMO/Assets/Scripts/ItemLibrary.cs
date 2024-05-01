using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemLibrary : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform itemParent;
    public GameObject container;

    private List<GameObject> itemList = new List<GameObject>();

    public Toggle outfitToggle;
    public Toggle helmetToggle;
    public Button backButton;
    private Button button;


    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => Show(true));
        backButton.onClick.AddListener(() => Show(false));
        outfitToggle.onValueChanged.AddListener(ShowOutfitList);
        helmetToggle.onValueChanged.AddListener(ShowHelmetList);
        outfitToggle.SetIsOnWithoutNotify(true);
        Init(SelectedCharacter.AccessoryType.Outfit);
    }

    public void Init(SelectedCharacter.AccessoryType accessoryType)
    {
        foreach (GameObject go in itemList)
        {
            go.SetActive(false);
        }

        int itemCount = 0;
        foreach (AccessoryInfo info in AccessoryController.Instance.accessoryList)
        {
            if (info.hasOwned && info.avatarName == HomeController.Instance.selectedCharacter.Info.avatarName && info.accessoryType == accessoryType)
            {
                GetItem(info);
                itemCount += 1;
            }
        }
        if (itemCount < 9)
        {
            for (int i = itemCount; i < 9; i++)
            {
                GetItem(null);
            }
        }
    }

    private GameObject SpawnItem(AccessoryInfo info)
    {
        GameObject obj = Instantiate(itemPrefab, itemParent, false);
        Item item = obj.GetComponent<Item>();
        item.Init(info);
        itemList.Add(obj);
        return obj;
    }

    private GameObject GetItem(AccessoryInfo info)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (!itemList[i].activeSelf)
            {
                itemList[i].GetComponent<Item>().Init(info);
                itemList[i].SetActive(true);
                return itemList[i];
            }
        }

        return SpawnItem(info);
    }

    public void Show(bool value)
    {
        container.SetActive(value);
        HomeController.Instance.ShowHUD(!value);
        HomeController.Instance.ShowFittingRoom(value);
        HomeController.Instance.ShowHome(!value);
    }

    private void ShowOutfitList(bool value)
    {
        Init(SelectedCharacter.AccessoryType.Outfit);
    }

    private void ShowHelmetList(bool value)
    {
        Init(SelectedCharacter.AccessoryType.Helmet);
    }
}
