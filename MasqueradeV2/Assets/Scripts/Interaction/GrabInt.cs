using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GrabInt : MonoBehaviour, IInteractable
{
    public bool grabed = false;
    private GameObject playerHands;
    private Collider coll;
    private Rigidbody rgPig;
    [SerializeField] hijoGranjeroShelby shelby;

    [SerializeField] Transform pigCart;

    void Awake()
    {
        playerHands = GameObject.Find("Hands");
        coll = gameObject.GetComponent<Collider>();
        rgPig = gameObject.GetComponent<Rigidbody>();
    }

    public void Select()
    {
        if (!grabed)
        {
            gameObject.transform.position = playerHands.transform.position;
            transform.parent = playerHands.transform;
            grabed = true;
            coll.isTrigger = true;
            shelby.LogicX();
        }
        //Else Sound Effect????
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Fall"))
        {
            DropMe();
        }
    }

    public void DropMe()
    {
        pigCart.gameObject.SetActive(true);
        transform.position = pigCart.position; 
        transform.parent = pigCart;
    }
}
