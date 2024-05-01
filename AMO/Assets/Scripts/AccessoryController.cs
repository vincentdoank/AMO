using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class AccessoryInfo
{
    public string accessoryId;
    public string accessoryName;
    public GameObject accessoryPrefab;
    public SelectedCharacter.BodyPart bodyPart;
}

public class AccessoryController : MonoBehaviour
{
    public List<AccessoryInfo> accessoryList;

    public static AccessoryController Instance { get; private set; }

    private void Start()
    {
        Instance = this;
    }

    public AccessoryInfo GetAccessoryInfo(string id)
    {
        AccessoryInfo info = accessoryList.Where(x => x.accessoryId == id).FirstOrDefault();
        return info;
    }
}
