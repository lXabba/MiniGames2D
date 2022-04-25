using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class Image_Match3 : MonoBehaviour
{
    private Button button;
    private void Start(){
        button = GetComponent<Button>();
        button.onClick.AddListener(Select);
    }

    private void Select(){
        ItemsController_Match3.instance.SwitchImages(GetComponent<Image_Match3>());
    }
}
