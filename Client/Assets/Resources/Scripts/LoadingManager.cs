using UnityEngine;
using System.Collections;

public class LoadingManager : MonoBehaviour {

    private static LoadingManager _instance;
    public static LoadingManager Instance {
        get {
            return _instance;
        }
    }


    void Awake()
    {
        _instance = this;
    }


    void Update()
    {

    }
}
