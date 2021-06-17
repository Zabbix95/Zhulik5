using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(PlayerMover))]
public class PlayerAnimator : MonoBehaviour
{
    private PlayerMover _movement;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<PlayerMover>();
    }
    private void OnEnable() 
    {
        _movement.SpeedChanged += OnSpeedChanged;
    }

    private void OnDisable() 
    {
        _movement.SpeedChanged -= OnSpeedChanged;
    }

    private void OnSpeedChanged(float speed)
    {
        _animator.SetFloat("Speed", speed);
    }
}
