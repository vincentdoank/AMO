using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AlarmInfo
{
    public string alarmId;
    public string alarmName;
    public string dateTimeString;
}

public class AlarmController : MonoBehaviour
{
    private List<AlarmInfo> alarmInfoList = new List<AlarmInfo>();

    public void AddAlarm(string alarmId, string alarmName, string dateTimeString)
    {
        alarmInfoList.Add(new AlarmInfo 
        {
            alarmId = alarmId,
            alarmName = alarmName,
            dateTimeString = dateTimeString
        });
    }
}
