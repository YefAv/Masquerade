using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steps : MonoBehaviour
{
    [SerializeField] private AudioClip[] footStep_Clip;
    [SerializeField] private float volumenMin, volumeMax;
    [SerializeField] private float accumulatedDistance;
    [SerializeField] private float stepDistance;
    float velocity, distance;
    private AudioSource footstep_sound;

    Vector3 distance_;
    Vector3 position;
    Vector3 oldPosition;

    private void Awake()
    {
        footstep_sound = GetComponent<AudioSource>();
        position = transform.position;
    }

    void Update()
    {
        CheckToPlayFootStepSound();
    }

    void CheckToPlayFootStepSound()
    {
        oldPosition = position;
        position = transform.position;
        distance_ = (position - oldPosition);
        distance = distance_.x * distance_.x + distance_.z * distance_.z;
        velocity = distance / Time.deltaTime;

        if (velocity > 0)
        {
            accumulatedDistance += Time.deltaTime;

            if (accumulatedDistance > stepDistance)
            {
                footstep_sound.volume = Random.Range(volumenMin, volumeMax);
                footstep_sound.clip = footStep_Clip[Random.Range(0, footStep_Clip.Length)];
                footstep_sound.Play();
                accumulatedDistance = 0f;
            }
        }
    }
}
