using UnityEngine;
using System.Collections;

public class LoadingManager : MonoBehaviour {


    #region 变量
    private bool loadingFinished = false;

    public GameObject mainSceneGO;
    private GameObject existingModel;
    public GameObject ModelCameraPrefab;
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
        DontDestroyOnLoad(ModelCameraPrefab);
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


    #endregion

}
