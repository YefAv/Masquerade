using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedData: MonoBehaviour
{
    public List<int> discoveredNPC = new List<int>();
    public List<int> completedNPC = new List<int>();
    public List<int> mapNotes = new List<int>();
    public List<int> clueNotes = new List<int>();
    //public bool firstTime;
    public int day = 12;
    public bool firstBell = false;
    public bool didTutorial;
}
