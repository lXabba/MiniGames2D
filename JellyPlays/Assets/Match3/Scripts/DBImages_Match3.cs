using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBImages_Match3 : MonoBehaviour
{
    public static Type_Match3[] types {get; private set;}
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]private static void Initialize(){
        types = Resources.LoadAll<Type_Match3>("Match3/");
    }

    
}
