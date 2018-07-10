using UnityEngine;
using System.Collections;

public class LoadingManager : MonoBehaviour {


    #region 变量
    private bool loadingFinished = false;

    public GameObject mainSceneGO;
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
    #endregion

}
