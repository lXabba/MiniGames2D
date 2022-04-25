using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagCells : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] lPosNums;
    public GameObject[] lSqNums;
    public GameObject prefabPlaceNum;
    public GameObject allSquares;
    void Start()
    {
        lPosNums = new GameObject[16];
        lSqNums = new GameObject[15];

        Cells();
        GetSquares();
        RandSortSquares();
    }


    // Update is called once per frame
    void Update()
    {

    }
    private void GetSquares()
    {
        int i = 0;
        foreach (var sq in allSquares.GetComponentsInChildren<TagNumSq>())
        {
            lSqNums[i] = sq.gameObject;
            i++;

        }


    }

    private void RandSortSquares()
    {
        int[] availableCells = new int[16] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        int numCell = -1;

        for (int i = 0; i < lSqNums.Length; i++)
        {

            numCell = -1;

            while (numCell == -1)
            {
                numCell = availableCells[(int)Random.Range(0, 16)];
                if (numCell != -1) availableCells[numCell] = -1;
            }
            
            
            lSqNums[i].transform.position = new Vector2(lPosNums[numCell].transform.position.x, lPosNums[numCell].transform.position.y);
            

            lPosNums[numCell].GetComponent<TagNumCell>().isAvailable = false;
            lSqNums[i].GetComponent<TagMoveSq>().numCell = numCell+1;
        }
    }
    private void Cells()
    {

        for (int i = 0; i < 16; i++)
        {
            lPosNums[i] = Instantiate(prefabPlaceNum, new Vector3(0, 0, 0), Quaternion.identity);
            lPosNums[i].GetComponent<TagNumCell>().number = i + 1;
        }
        int num = 15;

        for (int y = -3; y < 1 + 3; y += 2)
        {
            for (int x = 3; x > -4; x -= 2)
            {
                if (num < lPosNums.Length)
                {
                    lPosNums[num].transform.position = new Vector2(x, y);
                    num--;
                }
            }
        }
    }

    public int CheckNearAvailability(int numCell)
    {
        
        int availableCell = 0;

        for (int i = 0; i < lPosNums.Length; i++)
        {
            if (lPosNums[i].GetComponent<TagNumCell>().isAvailable) availableCell = lPosNums[i].GetComponent<TagNumCell>().number;
        }
      
        if (numCell + 1 == availableCell || numCell - 1 == availableCell) return availableCell;
        if (numCell - 4 == availableCell || numCell + 4 == availableCell) return availableCell;


        return -1;
    }

    public void CheckIsWin(){
        int checkWin = 0;
        for (int i=0; i < lSqNums.Length; i++){
            if (lSqNums[i].GetComponent<TagNumSq>().number == lSqNums[i].GetComponent<TagMoveSq>().numCell)
            {
                checkWin++;
            }
        }
        
        if (checkWin==15) print ("win!!!");
        else print(checkWin);
    }
}
