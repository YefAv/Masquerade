using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IntePattern : MonoBehaviour, IInteractable
{
    public static event Action<IntePattern> Selected = delegate { };

    public Material selectedM;
    public MeshRenderer render;
    public int cubeOrder;
    public bool selected;
    private Animator leverAnimator;
    [SerializeField] private AudioClip[] leverClips = new AudioClip[2];
    private AudioSource audSourceLever;
    [NonSerialized] public bool canInteract;

    void Start()
    {
        selected = false;
        canInteract = true;
        render = GetComponent<MeshRenderer>();
        leverAnimator = GetComponentInChildren<Animator>();
        audSourceLever = GetComponentInChildren<AudioSource>();
    }

    public void Select()
    {
        if (!selected && canInteract)
        {
            selected = true;
            render.material = selectedM;
            Selected(this);
            audSourceLever.clip = leverClips[0];
            audSourceLever.Play();
            leverAnimator.SetTrigger("down");
            Debug.Log("You clicked the " + name + " cube");
        }
    }

    public void SoundUpLevers()
    {
        audSourceLever.clip = leverClips[1];
        audSourceLever.Play();
    }

    public void turnBools()
    {
        canInteract = !canInteract;
    }

}
