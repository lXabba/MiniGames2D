using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagController : MonoBehaviour
{
    //public GameObject[] lPosNums;
    void Start()
    {
        //lPosNums = TagStaticController.tagCells.lPosNums;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                hit.transform.GetComponent<TagMoveSq>().ClickSq();
            }
        }


    }
}
