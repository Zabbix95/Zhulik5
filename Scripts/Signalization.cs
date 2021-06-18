using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider), typeof(AudioSource))]
public class Signalization : MonoBehaviour
{
    private AudioSource _soundtrack;
    private float _respond = 0.5f;
    private Coroutine _volumeOn;
    private Coroutine _volumeOff;

    private void Start()
    {
        _soundtrack = GetComponent<AudioSource>();
        _soundtrack.volume = 0f;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<PlayerMover>(out PlayerMover player))
        {
            _soundtrack.Play();

            if (_volumeOff != null)            
                StopCoroutine(_volumeOff);            

            _volumeOn = StartCoroutine(ChangeVolume(true));
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<PlayerMover>(out PlayerMover player))
        {
            if (_volumeOn != null)            
                StopCoroutine(_volumeOn);            

            _volumeOff = StartCoroutine(ChangeVolume(false));
        }
    }

    private IEnumerator ChangeVolume(bool alert)
    {
        int minMaxVolume;
        float deltaVolume = Mathf.Lerp(0, 1, Time.deltaTime * _respond);

        if (alert)
        {            
            minMaxVolume = 1;
        }
        else
        {
            deltaVolume = -deltaVolume;
            minMaxVolume = 0;
        }
        
        while (_soundtrack.volume != minMaxVolume)
        {
            _soundtrack.volume += deltaVolume;
            yield return null;
        }

        if (_soundtrack.volume == 0)
            _soundtrack.Stop();
    }
}
