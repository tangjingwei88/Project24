using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIMain : MonoBehaviour {

    #region 引用

    public GameObject topBottomAnchorStorageForUIMainLoadedPanel;

    public TipsPopUpPanel theTipsPopUpPanel;
    public StartPanel theLoginPartPanel;
    public RegisterPanel theRegisterPanel;



    #endregion


    #region 变量

    Stack<UIState> uiStateStack = new Stack<UIState>();

    #endregion


    #region 属性
    private static UIMain _Instance;
    public static UIMain Instance
    {
        get
        {
            return _Instance;
        }
    }

    private static UIState recentUIState = UIState.MainState;
    public static UIState RecentUIState {
        get {
            return recentUIState;
        }
    }


    #endregion



    void Awake()
    {
        _Instance = this;
    }

    void Start() {
        EnterUIState(UIState.LoginStartState);
    
    }


    public enum UIState
    {
        LoginStartState,                        //登陆界面
        RegisterPartState,                      //注册界面
        MainState,
        TipsPopUpPanelState,

    }

    /// <summary>
    /// 获取UI的名称
    /// </summary>
    /// <param name="InputUIStateName"></param>
    /// <returns></returns>
    public string GetUIStateName(UIState InputUIStateName)
    {
        if (InputUIStateName == UIState.MainState)
        {
            return "主界面";
        }
        else if (InputUIStateName == UIState.TipsPopUpPanelState)
        {
            return "Tips";
        }

        return "";
    }



    public class UIMainPanelHelper
    {
        public UIState targetState;
        public string prefabPath;
        public string typeName;

        public UIMainPanelHelper(UIState inputTargetState, string inputPrefabPath, string inputTypeName)
        {
            targetState = inputTargetState;
            prefabPath = inputPrefabPath;
            typeName = inputTypeName;
        }

    }

    public List<UIMainPanelHelper> uiMainPanelHelperList = new List<UIMainPanelHelper>
    {
        new UIMainPanelHelper(UIState.LoginStartState,"SmallPanel/LoginPartPanel","LoginPartPanel"),
        new UIMainPanelHelper(UIState.RegisterPartState,"SmallPanel/RegisterPartPanel","RegisterPartPanel")
    };


    /// <summary>
    /// UI入栈
    /// </summary>
    /// <param name="targetState"></param>
    public void FadeToUIState(UIState targetState)
    {
        if (targetState == UIState.MainState)
            uiStateStack.Clear();
        else if (targetState != RecentUIState)
            uiStateStack.Push(targetState);
    }


    /// <summary>
    /// 进入UI
    /// </summary>
    /// <param name="targetState"></param>
    public void EnterUIState(UIState targetState)
    { 
        if(targetState == UIState.LoginStartState)
        {
            theLoginPartPanel.gameObject.SetActive(true);
            //TODO

        }
        else if (targetState == UIState.RegisterPartState)
        {
            theRegisterPanel.gameObject.SetActive(true);
            //TODO
        }


    }

    /// <summary>
    /// 退出UI
    /// </summary>
    /// <param name="targetState"></param>
    public void LeaveUIState(UIState targetState)
    {
        if (targetState == UIState.LoginStartState)
        {
            theLoginPartPanel.gameObject.SetActive(false);
        }
        else if (targetState == UIState.RegisterPartState)
        {
            theRegisterPanel.gameObject.SetActive(false);
        }


    }



    public GameObject GetHelp(UIState inputTargetState, Component inputComponent)
    {
        if (inputComponent == null)
        {
            for (int i = 0; i < uiMainPanelHelperList.Count; i++)
            {
                if (uiMainPanelHelperList[i].targetState == inputTargetState)
                { 
                    UIMainPanelHelper targetUIMainPanelHelper = uiMainPanelHelperList[i];
                    GameObject newGO = HelperTools.NewUI(targetUIMainPanelHelper.prefabPath);

                    GameObject targetGO = newGO.GetComponent<UIMainLoadedPanel>().targetPanel;

                    targetGO.transform.parent = transform.GetChild(0);
                    targetGO.transform.localPosition = Vector3.zero;
                    targetGO.transform.localScale = Vector3.zero;

                    GameObject topBottomAnchorRoot = newGO.GetComponent<UIMainLoadedPanel>().topBottomAnchorRoot;
                    if (topBottomAnchorRoot != null)
                    {
                        topBottomAnchorRoot.transform.parent = topBottomAnchorStorageForUIMainLoadedPanel.transform;
                        topBottomAnchorRoot.transform.localScale = Vector3.zero;
                    }

                    UIResolutionHelper script = targetGO.GetComponent<UIResolutionHelper>();
                    if (script != null)
                    {
                        script.theUIRoot = GetComponent<UIRoot>();
                    }

                    Destroy(newGO);

                    return targetGO;
                }
            }
        }

        return inputComponent.gameObject;
    }
}
