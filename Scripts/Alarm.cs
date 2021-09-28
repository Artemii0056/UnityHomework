using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;

    private bool _inside = false;
    private float _volumeControl = 0.001f;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.GetComponent("Move"))
        {
            _inside = true;
            _alarm.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent("Move"))
        {
            _inside = false;
        }
    }

    private IEnumerator ChangeVolume()
    {
        if (_inside == false)
        {
            _alarm.volume -= _volumeControl;
        }
        else if (_inside == true)
        {
            _alarm.volume += _volumeControl;
        }
        yield return _alarm.volume;
    }

    private void FixedUpdate()
    {
       var chandVolumeJob = StartCoroutine(ChangeVolume());
    }
}
