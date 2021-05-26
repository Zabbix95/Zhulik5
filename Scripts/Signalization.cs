using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider), typeof(AudioSource))]

public class Signalization : MonoBehaviour
{
    private AudioSource _soundtrack;
    private float _respond = 0.5f;

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
            StopCoroutine(ChangeVolume(false));
            StartCoroutine(ChangeVolume(true));
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<PlayerMover>(out PlayerMover player))
        {
            StopCoroutine(ChangeVolume(true));
            StartCoroutine(ChangeVolume(false));
        }
    }


    private IEnumerator ChangeVolume(bool alert)
    {
        if (alert)
        {
            while (_soundtrack.volume != 1)
            {
                _soundtrack.volume += Mathf.Lerp(0, 1, Time.deltaTime * _respond);
                yield return null;
            }
        }
        else
        {
            while (_soundtrack.volume != 0)
            {
                _soundtrack.volume -= Mathf.Lerp(0, 1, Time.deltaTime * _respond);
                yield return null;
            }
            _soundtrack.Pause();
        }
    }
}
