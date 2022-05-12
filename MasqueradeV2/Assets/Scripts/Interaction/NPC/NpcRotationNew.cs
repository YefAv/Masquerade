using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcRotationNew : MonoBehaviour
{
    [SerializeField] Transform hips, head;
    [SerializeField] Transform Target;
    [SerializeField] float hipsSpeed = 1f, headSpeed = 0.5f;

    void HeadLookAt()
    {
        Quaternion headLookRotation = Quaternion.LookRotation(Target.position - head.position);
        Quaternion initialRotation = head.rotation;

        if (initialRotation != headLookRotation)
        {
            head.rotation = Quaternion.Slerp(initialRotation, headLookRotation, headSpeed * Time.deltaTime);            
        }
    }
    void HipsLookAt()
    {
        Quaternion hipsLookRotation = Quaternion.LookRotation(Target.position - hips.position);
        Quaternion initialRotation = hips.rotation;

        if (initialRotation != hipsLookRotation)
        {
            hips.rotation = Quaternion.Slerp(initialRotation, hipsLookRotation, hipsSpeed * Time.deltaTime);            
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HeadLookAt();
            HipsLookAt();
        }
    }

    //las corrutinas no sirven pa puta mierda :D

}
