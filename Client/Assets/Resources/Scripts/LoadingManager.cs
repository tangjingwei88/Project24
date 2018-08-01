﻿using UnityEngine;
using System.Collections;

public class LoadingManager : MonoBehaviour {


    #region 变量
    private bool loadingFinished = false;

    public GameObject mainSceneGO;
    private GameObject existingModel;
    public GameObject modelCameraPrefab;
    public Transform modelPositionTransform;


    public Skybox targetSkyBoxOnModelCamera;

    #endregion

    private static LoadingManager _instance;
    public static LoadingManager Instance {
        get 
        {
            return _instance;
        }
    }


    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        DontDestroyOnLoad(modelCameraPrefab);
    }


    void Update()
    {

    }


    public void EnterScene(string sceneName)
    {
        StartCoroutine(WaitLoadingTargetScene(sceneName));
    }


    #region 方法

    /// <summary>
    /// 异步场景加载
    /// </summary>
    /// <param name="sceneName"></param>
    /// <returns></returns>
    IEnumerator WaitLoadingTargetScene(string sceneName)
    {
        AsyncOperation async = Application.LoadLevelAsync(sceneName);
 //       async.priority = 0;
        yield return async;

        loadingFinished = true;
    }


    private void AfterLoadMainScene()
    {
        if (mainSceneGO == null)
        {
            mainSceneGO = GameObject.Find("UIMain");
        }

        if (mainSceneGO != null)
        {
            mainSceneGO.SetActive(true);
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
        Debug.LogError("obj " + obj);
        if (obj == null)
        {
            Debug.LogError(name + "is not existed!");
        }
        return (GameObject)Object.Instantiate(obj);
    }

    /// <summary>
    /// 加载模型相机
    /// </summary>
    public void LoadModelCameraPrefab()
    {
        Object go;
        if (modelCameraPrefab == null)
        {
            go = Resources.Load("UIPrefab/ModelCameraPrefab");
            GameObject objCamera = (GameObject)Instantiate(go);
            DontDestroyOnLoad(objCamera);
            modelCameraPrefab = objCamera;

            modelPositionTransform = objCamera.transform.GetChild(1);
            Debug.LogError("#modelPositionTransform " + modelPositionTransform);
            targetSkyBoxOnModelCamera = objCamera.transform.GetChild(0).GetComponent<Skybox>();
        }
    }

    /// <summary>
    /// 加载模型
    /// </summary>
    /// <param name="name"></param>
    public void LoadModelPrefab(string name)
    {
        Debug.LogError("#4#modelPositionTransform " + modelPositionTransform);
        existingModel = NewCharacter(name);
        Debug.LogError("##existingModel " + existingModel);
        if (existingModel.GetComponent<Animation>().GetClip("Idle") != null)
        {
            existingModel.GetComponent<Animation>().Play("Idle");
        }
        Debug.LogError("##modelPositionTransform " + modelPositionTransform);
        existingModel.transform.parent = modelPositionTransform;
        existingModel.transform.localPosition = Vector3.zero;
        existingModel.transform.localRotation = Quaternion.identity;
    }


    /// <summary>
    /// 旋转模型
    /// </summary>
    /// <param name="delta">旋转角度</param>
    public void RotateModel(float delta)
    {
        Vector3 formerLocalRotation = existingModel.transform.localRotation.eulerAngles;
        formerLocalRotation.y -= delta;
        existingModel.transform.localRotation = Quaternion.Euler(formerLocalRotation);
    }


    public void DestroyModel()
    {
        Debug.LogError("###");
        if (existingModel != null)
        {
            Destroy(existingModel);
        }
    }

    #endregion

}
