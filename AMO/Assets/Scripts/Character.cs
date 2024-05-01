using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private List<AvatarInfo> avatarInfoList;
    [SerializeField] private Transform characterParent;

    private List<SelectedCharacter> characterList = new List<SelectedCharacter>();
    private string selectedAvatarId;

    public SelectedCharacter currentCharacter;

    public static Character Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        LoadAllCharacter();
        selectedAvatarId = "Mochi01";
        LoadCharacter(selectedAvatarId);
    }

    private void LoadAllCharacter()
    {
        foreach (AvatarInfo info in avatarInfoList)
        {
            GameObject charObj = Instantiate(info.characterPrefab, characterParent, false);
            SelectedCharacter character = charObj.GetComponent<SelectedCharacter>();
            character.Init(info);
            charObj.SetActive(false);
            characterList.Add(character);
        }
    }

    private void LoadCharacter(string avatarId)
    {
        foreach (SelectedCharacter character in characterList)
        {
            if (character.Info.avatarId == avatarId)
            {
                currentCharacter = character;
                character.gameObject.SetActive(true);
                break;
            }
        }
    }

    public void SwitchCharacter(string avatarId)
    {
        foreach (SelectedCharacter character in characterList)
        {
            if (character.Info.avatarId == avatarId)
            {
                currentCharacter = character;
                character.gameObject.SetActive(true);
            }
            else
            {
                character.gameObject.SetActive(false);
            }
        }
    }

    public AvatarInfo GetCurrentAvatarInfo()
    {
        Debug.LogError("selectedAvatarId : " + selectedAvatarId);
        foreach (AvatarInfo info in avatarInfoList)
        {
            Debug.LogError("existing avatarId : " + info.avatarId);
        }
        var result = avatarInfoList.Where(x => x.avatarId == selectedAvatarId).FirstOrDefault();
        Debug.LogError("result : " + result.avatarId);
        return result;
    }

    public AvatarInfo GetAvatarInfo(string avatarId)
    {
        var result = avatarInfoList.Where(x => x.avatarId == selectedAvatarId).FirstOrDefault();
        return result;
    }

    public List<AvatarInfo> GetAvatarInfoList()
    {
        return avatarInfoList;
    }
}
