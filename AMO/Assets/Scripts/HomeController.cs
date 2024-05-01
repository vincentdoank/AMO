using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class HomeController : MonoBehaviour
{
    public CharacterSelection characterSelection;
    public MoodController moodController;
    public EnergyController energyController;
    public ItemLibrary itemLibrary;
    public AlarmController alarmController;
    public ToDoController toDoController;
    public NotificationController notificationController;
    public InboxController inboxController;
    public Level level;
    public Coins coins;
    public Character character;

    public SelectedCharacter selectedCharacter;

    public GameObject homeHUD;
    public GameObject homeEnvironment;
    public GameObject fittingRoomEnvironment;

    private float elapsedTime = 0;
    private DateTime dateTimeStart;
    public int startTimeInSecond;
    public int elapsedTimeInSecond;
    public float energyToSecond = 60f;
    public float inGameEnergyConsumed;

    public static HomeController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        DateTime dateTime = DateTime.Now;
        startTimeInSecond = dateTime.Second + dateTime.Minute * 60 + dateTime.Hour * 3600 + dateTime.DayOfYear * 86400;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        elapsedTimeInSecond = Mathf.FloorToInt(elapsedTime);

        inGameEnergyConsumed = elapsedTime / energyToSecond;


        AvatarInfo info = character.GetCurrentAvatarInfo();
        energyController.SetEnergy(info.energy - inGameEnergyConsumed);

        if (Input.GetKeyDown(KeyCode.E))
        {
            selectedCharacter.Evolution();
        }
    }

    public void SetEnergy(int value)
    {
        energyController.SetEnergy(value);
    }

    public void ShowCharacterSelection(bool value)
    {
        characterSelection.gameObject.SetActive(value);
    }

    public void SelectCharacter(AvatarInfo info)
    {
        selectedCharacter = character.SwitchCharacter(info.avatarId);
        selectedCharacter.Init(info);
    }

    public void ShowHUD(bool value)
    {
        homeHUD.SetActive(value);
    }

    public void ShowHome(bool value)
    {
        homeEnvironment.SetActive(value);
    }

    public void ShowFittingRoom(bool value)
    {
        fittingRoomEnvironment.SetActive(value);
    }
}
