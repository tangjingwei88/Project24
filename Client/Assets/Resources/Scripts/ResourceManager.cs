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


    /// <summary>
    /// 实例化模型
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
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



    public GameObject NewUIParticle(string name)
    {
        Object obj = Resources.Load(GameDefine.UIParticlePath + name);
        if (obj == null)
        {
            Debug.LogError(name + "is not existed!");
        }
        return (GameObject)Object.Instantiate(obj);
    }
}
