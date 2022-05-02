using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RotationManager : MonoBehaviour
{
    [SerializeField] Transform cart;
    Cinemachine.CinemachineDollyCart codeCart;
    Transform player;
    bool lookP = false; // alejo
    float speed;
    [SerializeField] TextMesh interactText;
    [SerializeField] SpriteRenderer questSprite;

    Vector3 playerToLook;

    private void Awake()
    {
        codeCart = cart.GetComponent<Cinemachine.CinemachineDollyCart>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        speed = codeCart.m_Speed;
        interactText.color = Color.clear;
        questSprite = GetComponentInChildren<SpriteRenderer>();
        questSprite.color = new Color(1, 1, 1, 0);
    }
    private void LateUpdate()
    {
        if (!lookP)
        {
            transform.rotation = cart.rotation;
            interactText.color = Color.clear;
            questSprite.color = new Color(1, 1, 1, 0);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LookPlayer();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        lookP = false;
        interactText.color = Color.clear;
        questSprite.color = new Color(1, 1, 1, 0);
        codeCart.m_Speed = speed;
    }

    void LookPlayer()
    {
        playerToLook = new Vector3(player.position.x, transform.position.y, player.position.z);
        lookP = true;
        interactText.color = Color.white;
        questSprite.color = new Color(1, 1, 1, 1);
        codeCart.m_Speed = 0;
        transform.LookAt(playerToLook);
    }
}
