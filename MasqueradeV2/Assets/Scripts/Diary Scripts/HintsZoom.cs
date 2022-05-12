using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HintsZoom : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    private Vector3 hoverZoom, normalScale;
    private Transform originalTrans, bigZoomTrans;
    
    private void Start()
    {
        normalScale = gameObject.transform.localScale;
        hoverZoom = normalScale * 1.3f;
        originalTrans = gameObject.transform;
        //bigZoomTrans COSAS
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.transform.localScale *= 1.3f;
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.transform.localScale /= 1.3f;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // zoom bien verga
        Debug.Log("Esto es muy xd y un zoom muy perrón");
    }
}
