using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagStaticController : MonoBehaviour
{
    public static TagCells tagCells;

    void Start(){
        tagCells = FindObjectOfType<TagCells>();
    }
}
