using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private AccessoryInfo info;
    public Image image;

    private Toggle toggle;

    public void Init(AccessoryInfo info)
    {
        if (toggle == null)
        {
            toggle = GetComponent<Toggle>();
            toggle.onValueChanged.AddListener(SelectItem);
        }
        this.info = info;
        if (info == null)
        {
            toggle.enabled = false;
        }
        else
        {
            toggle.enabled = true;
            image.sprite = info.accessorySprite;
        }
    }

    private void SelectItem(bool isOn)
    {
        HomeController.Instance.selectedCharacter.AddAccessory(info.accessoryId);
    }
}
