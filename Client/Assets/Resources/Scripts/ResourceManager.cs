using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour {

    private static ResourceManager _instance;

    public static ResourceManager Instance {
        get { 
            if(_instance == null)
            {
                _instance = new ResourceManager();
            }
            return _instance;
        }
    }



    public GameObject NewCharacter(string name)
    {
        Object obj = Resources.Load(GameDefine.CharacterPath + name);
        if (obj == null)
        {
            Debug.LogError(name + "is not exist!");
            return null;
        }

        return (GameObject)Object.Instantiate(obj);
    }
}
