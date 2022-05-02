using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CinematicPlaying : MonoBehaviour
{

    void Update()
    {
        if (gameObject.TryGetComponent(typeof(VideoPlayer), out Component videoPlayer))
        {
            PlayerStateMachine.playerStateMachine.playerState = PlayerStateMachine.PlayerState.Cinematic;
        }
        else {
            PlayerStateMachine.playerStateMachine.playerState = PlayerStateMachine.PlayerState.NormalMov;
            gameObject.GetComponent<CinematicPlaying>().enabled = false; }

    }
}
