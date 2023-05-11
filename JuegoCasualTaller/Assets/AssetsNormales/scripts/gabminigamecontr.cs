using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gabminigamecontr : MonoBehaviour
{
    public mingameLogic screws;
    // Start is called before the first frame update

    public void AddToCounter()
    {
        screws.screwsRemoved++;
    }
    public void deactivateObject()
    {
        this.gameObject.SetActive(false);
    }
}
