using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagMoveSq : MonoBehaviour
{
    //int numSq;
    public int numCell = 0;
    void Start()
    {
        //numSq = gameObject.GetComponent<TagNumSq>().number;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickSq(){
        int availableCell = TagStaticController.tagCells.CheckNearAvailability(numCell);
     
        if (availableCell == -1) return;

        Vector2 pos = TagStaticController.tagCells.lPosNums[availableCell-1].transform.position;
        gameObject.transform.position = pos;
        
        TagStaticController.tagCells.lPosNums[availableCell-1].GetComponent<TagNumCell>().isAvailable = false;
        TagStaticController.tagCells.lPosNums[numCell-1].GetComponent<TagNumCell>().isAvailable = true;
        numCell = availableCell;

        TagStaticController.tagCells.CheckIsWin();
    }
}
