using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagController : MonoBehaviour
{
    public GameObject[] lPosNums;
    void Start()
    {
        lPosNums = TagStaticController.tagCells.lPosNums;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
