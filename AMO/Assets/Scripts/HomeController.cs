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
    public ItemStorage itemStorage;
    public AlarmController alarmController;
    public ToDoController toDoController;
    public NotificationController notificationController;
    public InboxController inboxController;
    public Level level;
    public Coins coins;
    public Character character;

    private float elapsedTime = 0;
    private DateTime dateTimeStart;
    public int startTimeInSecond;
    public int elapsedTimeInSecond;
    public float energyToSecond = 60f;
    public float inGameEnergyConsumed;

    public static HomeController Instance { get; private set; }

    private void Start()
    {
        Instance = this;
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
    }

    public void SetEnergy(int value)
    {
        energyController.SetEnergy(value);
    }

    public void ShowCharacterSelection(bool value)
    {
        characterSelection.gameObject.SetActive(value);
    }
}
