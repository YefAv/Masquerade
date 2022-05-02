using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diary : MonoBehaviour
{
    private List<Pages> pages = new List<Pages>();
    public bool activePage;
    void Start()
    {
        
    }

    public void ButtonNext()
    {
    }

    private void TaskCompleted()
    {
        activePage = true;
    }
    private void PageComparer()
    {
        pages.Sort(delegate (Pages x, Pages y)
        {
            return x.IndexPage.CompareTo(y.IndexPage);
        });
    }
    private Pages CreatePage()
    {
        Pages page = new Pages();
        pages.Add(page);
        return page;
    }
}
