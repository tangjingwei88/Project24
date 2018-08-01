using UnityEngine;
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
        get {
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
            targetSkyBoxOnModelCamera = objCamera.transform.GetChild(0).GetComponent<Skybox>();
        }
    }

    /// <summary>
    /// 加载模型
    /// </summary>
    /// <param name="name"></param>
    public void LoadModelPrefab(string name)
    {
        existingModel = ResourceManager.Instance.NewCharacter(name);
        if (existingModel.GetComponent<Animation>().GetClip("Idle") != null)
        {
            existingModel.GetComponent<Animation>().Play("Idle");
        }

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
        if (existingModel != null)
        {
            Destroy(existingModel);
        }
    }

    #endregion

}
