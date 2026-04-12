using System.Collections;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;
    [SerializeField] private CollisionHandler _collisionHandler;

    private void OnEnable()
    {
        _collisionHandler.EnteredTheHouse += AlarmEnable;
        _collisionHandler.LeftTheHouse += AlarmDisable;
    }

    private void OnDisable()
    {
        _collisionHandler.EnteredTheHouse -= AlarmEnable;
        _collisionHandler.LeftTheHouse -= AlarmDisable;
    }

    private void AlarmEnable()
    {
        _alarm.SetMaxVolume();
        _alarm.HouseAlarm.Play();
    }

    private void AlarmDisable()
    {
        StartCoroutine(TurnOffAlarm());
    }

    private IEnumerator TurnOffAlarm()
    {
        _alarm.SetMinVolume();

        while (_alarm.HouseAlarm.volume > _alarm.MinVolume)
        {
            yield return null;
        }

        _alarm.HouseAlarm.Stop();
    }
} 