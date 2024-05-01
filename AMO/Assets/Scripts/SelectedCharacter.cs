using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectedCharacter : MonoBehaviour
{
    public AvatarInfo Info { get; private set; }

    public enum BodyPart
    {
        Head,
        Body,
        Hand,
        Shoes
    }

    public Accessory headAccessory;
    public Accessory handAccessory;
    public Accessory bodyAccessory;
    public Accessory shoesAccessory;

    private List<GameObject> equippedAccessories = new List<GameObject>();

    private CharacterAnimation characterAnimation;

    private void Start()
    {
        characterAnimation = GetComponent<CharacterAnimation>();
        equippedAccessories.Add(AddAccessory(Info.headAccessoryId));
        equippedAccessories.Add(AddAccessory(Info.bodyAccessoryId));
        equippedAccessories.Add(AddAccessory(Info.handAccessoryId));
        equippedAccessories.Add(AddAccessory(Info.shoesAccesoryId));
    }

    public void Init(AvatarInfo info)
    {
        Info = info;
    }

    public int GetMood()
    {
        return Info.mood;
    }

    public float GetEnergy()
    {
        return Info.energy;
    }

    public void AddMood(int value)
    {
        Info.mood += value;
        characterAnimation.SetAnimationCondition("mood", Info.mood);
    }

    public void AddEnergy(int value)
    {
        Info.energy += value;
        characterAnimation.SetAnimationCondition("energy", Info.mood);
    }

    public void ConsumeMood(int value)
    {
        Info.mood -= value;
        characterAnimation.SetAnimationCondition("mood", Info.mood);
    }

    public void ConsumeEnergy(int value)
    {
        Info.energy -= value;
        characterAnimation.SetAnimationCondition("energy", Info.mood);
    }

    public void SetMood(int value)
    {
        Info.mood = value;
        characterAnimation.SetAnimationCondition("mood", Info.mood);
    }

    public void SetEnergy(int value)
    {
        Info.energy = value;
        characterAnimation.SetAnimationCondition("energy", Info.mood);
    }

    public void PlayIdleAnimation()
    {
        string conditionName = "Idle";
        characterAnimation.SetAnimationCondition(conditionName, true);
        foreach (GameObject equippedAccessory in equippedAccessories)
        {
            equippedAccessory.GetComponent<CharacterAnimation>().SetAnimationCondition(conditionName);
        }
    }

    public void PlayChoosenAnimation()
    {
        string conditionName = "Choose";
        characterAnimation.SetAnimationCondition(conditionName, true);
        foreach (GameObject equippedAccessory in equippedAccessories)
        {
            equippedAccessory.GetComponent<CharacterAnimation>().SetAnimationCondition(conditionName);
        }
    }

    public GameObject AddAccessory(string accessoryId)
    {
        if (!string.IsNullOrEmpty(accessoryId))
        {
            AccessoryInfo info = AccessoryController.Instance.GetAccessoryInfo(accessoryId);
            switch (info.bodyPart)
            {
                case BodyPart.Head:
                    return AddHeadAccessory(info.accessoryPrefab);
                case BodyPart.Body:
                    return AddBodyAccessory(info.accessoryPrefab);
                case BodyPart.Hand:
                    return AddHandAccessory(info.accessoryPrefab);
                case BodyPart.Shoes:
                    return AddShoesAccessory(info.accessoryPrefab);
            }
        }
        return null;
    }

    private GameObject AddHeadAccessory(GameObject obj)
    {
        if (headAccessory != null)
        {
            Destroy(headAccessory);
        }
        GameObject head = Instantiate(obj, transform, false);
        head.transform.localEulerAngles = Vector3.zero;
        return head;
    }

    private GameObject AddBodyAccessory(GameObject obj)
    {
        if (bodyAccessory != null)
        {
            Destroy(bodyAccessory);
        }
        GameObject body = Instantiate(obj, transform, false);
        body.transform.localEulerAngles = Vector3.zero;
        return body;
    }

    private GameObject AddHandAccessory(GameObject obj)
    {
        if (handAccessory != null)
        {
            Destroy(handAccessory);
        }
        GameObject hand = Instantiate(obj, transform, false);
        hand.transform.localEulerAngles = Vector3.zero;
        return hand;
    }

    private GameObject AddShoesAccessory(GameObject obj)
    {
        if (shoesAccessory != null)
        {
            Destroy(shoesAccessory);
        }
        GameObject shoes = Instantiate(obj, transform, false);
        shoes.transform.localEulerAngles = Vector3.zero;
        return shoes;
    }

    public void Evolution()
    {
        string currentAvatarId = Info.avatarId;
        string[] splittedAvatarId = currentAvatarId.Split("_");
        if (int.TryParse(splittedAvatarId[1], out int avatarStageCode))
        {
            avatarStageCode += 1;
            TransferStats(splittedAvatarId[0] + "_" + avatarStageCode);
        }
    }

    private void TransferStats(string avatarId)
    {
        AvatarInfo targetAvatarInfo = Character.Instance.GetAvatarInfo(avatarId);
        targetAvatarInfo.mood = Info.mood;
        targetAvatarInfo.energy = Info.energy;
        targetAvatarInfo.level = Info.level;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            PlayChoosenAnimation();
        }
    }
}
