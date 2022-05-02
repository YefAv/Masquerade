using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    [SerializeField] GameObject diary;
    [SerializeField] GameObject back, next;
    private int currentPage;
    public List<int> savedPages = new List<int>();  //Paginas Disponibles
    
    void Start()
    {
        next.SetActive(false);
        back.SetActive(false);
        OpenDiary();
    }

    private void Update()
    {
        Navigation();
    }
    void Navigation()
    {

        if (savedPages.Count > 0 && savedPages.IndexOf(currentPage) < savedPages.Count - 1)
        {
            next.SetActive(true);
        }
        else next.SetActive(false);
        if(savedPages.IndexOf(currentPage) >= 1) 
        {
            back.SetActive(true);
        }
        else back.SetActive(false);

        //Debug.Log(currentPage);
        //Debug.Log(savedPages.IndexOf(currentPage));
    }

    public void NextButton()
    {
        gameObject.transform.GetChild(currentPage).gameObject.SetActive(false);
        if (savedPages.IndexOf(currentPage) < savedPages.Count - 1)
            currentPage = savedPages[savedPages.IndexOf(currentPage) + 1];
        gameObject.transform.GetChild(currentPage).gameObject.SetActive(true);
    }
    public void BackButton()
    {
        gameObject.transform.GetChild(currentPage).gameObject.SetActive(false);
        if (savedPages.IndexOf(currentPage) >= 1) 
            currentPage = savedPages[savedPages.IndexOf(currentPage) - 1];
        gameObject.transform.GetChild(currentPage).gameObject.SetActive(true);
    }
    void PagesOff()

    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    void FirstPageOn()
    {
        if (savedPages.Count > 0)
        {
            transform.GetChild(savedPages[0]).gameObject.SetActive(true);
            currentPage = savedPages[0];
        }
    }

    public void OpenDiary()
    {
        savedPages = diary.GetComponent<SavedData>().discoveredNPC;
        PagesOff();
        FirstPageOn();
    }
    
}
