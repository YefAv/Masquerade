using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MissionsTemplate : MonoBehaviour // el que la instancie es provida
{
    //asignar npc code en el inspector
    //todas las misiones heredan de esta clase y no de MonoBehaviour

    public InteNpc npcCode;
    public int npcRef;
    protected FungusLogic_Mission npcMissionLogic;
    public bool doneMission = false;

    [SerializeField] ParticleSystem completeParticles;
    [SerializeField] AudioSource completeSound;

    public void SetValues() //llamar en el start
    {
        if (npcCode != null)
        {
            npcRef = npcCode.NPCreference;
            npcMissionLogic = npcCode.gameObject.GetComponent<FungusLogic_Mission>();
            doneMission = false;
        }
        else
            Debug.LogError("no hay NPCcode");
    }

    public void MissionDone() 
    {
        doneMission = true;
        npcMissionLogic.missionComplete = true;
        completeParticles.Play();
        completeSound.Play();

        npcCode.data.completedNPC.Add(npcRef);
        npcCode.data.completedNPC = npcCode.data.completedNPC.Distinct().ToList();
    }
}
