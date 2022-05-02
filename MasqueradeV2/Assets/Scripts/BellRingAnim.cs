using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellRingAnim : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void bellRing()
    {
        TimeSystem.timeSyst.runningTime = false;
        PlayerStateMachine.playerStateMachine.playerState = PlayerStateMachine.PlayerState.Cinematic;
        _animator.SetTrigger("bellTrigger");
        Invoke("ActivateMovement",3);
    }

    public void ActivateMovement()
    {
        TimeSystem.timeSyst.runningTime = true;
        PlayerStateMachine.playerStateMachine.playerState = PlayerStateMachine.PlayerState.NormalMov;
    }
}
