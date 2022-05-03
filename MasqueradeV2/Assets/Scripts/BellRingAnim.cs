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
        Brain._brain.CambiarEstado(Brain.EstadosDeJuego.cinematica);
        _animator.SetTrigger("bellTrigger");
        Invoke("ActivateMovement",3);
    }

    public void ActivateMovement()
    {
        TimeSystem.timeSyst.runningTime = true;
        Brain._brain.CambiarEstado(Brain.EstadosDeJuego.normal);
    }
}
