/***
 * 
 * Title:游戏主界面
 * Author：TSoft
 * Date：18-7-11-1310
 * 
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GamePanel : MonoBehaviour {

    #region 引用

    public GameObject DragInputItem_1;
    public GameObject DragInputItem_2;
    public GameObject DragInputItem_3;
    public GameObject DragInputItem_4;
    public GameObject DragInputItem_5;
    public GameObject DragInputItem_6;
    public GameObject DragInputItem_7;
    public GameObject DragInputItem_8;
    public GameObject DragInputItem_9;

    public ShowLogPart theShowLogPart;
    public ShowResultPart theShowResultPart;
    public GameOverPanel theGameOverPanel;

    public UILabel TimeLabel;             //倒计时显示
    public UILabel ResultLabel;           //测试用显示结果           


    #endregion


    #region 变量
    private int inputNum_1;
    private int inputNum_2;
    private int inputNum_3;
    private int inputNum_4;
    private int inputNum_5;
    private int inputNum_6;
    private int inputNum_7;
    private int inputNum_8;
    private int inputNum_9;


    private int resultNum;              //正确结果
    private int round = 1;              //游戏轮数
    private string gameInput = "";      //玩家输入数据

    private Dictionary<int, int> inputDic = new Dictionary<int, int>();                     //玩家输入的数据
    private Dictionary<int, int> randomDic = new Dictionary<int, int>();                    //系统随机生成的数据
    private Dictionary<LIGHT_TYPE, int> resultDic = new Dictionary<LIGHT_TYPE, int>();      //游戏结果数据

    Dictionary<int, int> inputTempDic = new Dictionary<int, int>();                         //玩家输入待检测的数据
    #endregion

    private static GamePanel _instance;
    public static GamePanel Instance {
        get {
            return _instance;
        }
    }


    void Awake()
    {
        _instance = this;
        InitGame();

    }


    /// <summary>
    /// 游戏初始化
    /// </summary>
    public void InitGame()
    {
        GameData.Instance.gameRound = 1;
        RefreshPanel();
        //获取系统生成的随机数据
        randomDic = GetRandomNumber(GameData.Instance.GameLevel);
        //显示输入框
        ShowInputNumRoot(GameData.Instance.GameLevel);
        //显示倒计时
        StartCoroutine(TimeSliping(GameData.Instance.roundTime));
        //加载模型
        LoadingManager.Instance.LoadModelCameraPrefab();
        LoadingManager.Instance.LoadModelPrefab("DarkHunter_B");
    }


    #region 方法



    /// <summary>
    /// 刷新界面，重新开始游戏
    /// </summary>
    public void RefreshPanel()
    {
        theShowLogPart.Clear();
        theShowResultPart.Clear();
    }

    /// <summary>
    /// 倒计时显示
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    public IEnumerator TimeSliping(float time)
    {
        while (time >= 0)
        {
            yield return new WaitForSeconds(1);
            TimeLabel.text = time.ToString();
            time--;
        }

        //TODO
        //游戏结束
        Debug.LogError("游戏结束");
        theShowLogPart.Clear();
        theGameOverPanel.gameObject.SetActive(true);
    }

    /// <summary>
    /// 确定按钮
    /// </summary>
    public void OnOkBtnClick()
   {
        //获得用户输入的数据
        inputDic = GetInputNumber(GameData.Instance.GameLevel);
        //比较用户输入的数据和系统生成的数据
        resultDic = CompareInputAndRandomNum(inputDic,randomDic);
        //刷新游戏结果
        RefreshLighterShow(resultDic);
        //刷新游戏记录
        RefreshLoggerShow(resultDic);
    }


    /// <summary>
    /// 刷新红黄绿的显示
    /// </summary>
    /// <param name="dic"></param>
    private void RefreshLighterShow(Dictionary<LIGHT_TYPE, int> dic)
    {
        theShowResultPart.Apply(dic);
    }


    /// <summary>
    /// 刷新玩家游戏记录
    /// </summary>
    /// <param name="dic"></param>
    private void RefreshLoggerShow(Dictionary<LIGHT_TYPE, int> dic)
    {
        theShowLogPart.Apply(dic);
    }


    /// <summary>
    /// 比较玩家输入数据和系统生成的随机数
    /// </summary>
    /// <param name="inputDic"></param>
    /// <param name="randomDic"></param>
    /// <returns></returns>
    private Dictionary<LIGHT_TYPE, int> CompareInputAndRandomNum(Dictionary<int,int> inputDic,Dictionary<int,int> randomDic)
    {
        int green = 0;
        int yellow = 0;
        int red = 0;

        Dictionary<LIGHT_TYPE, int> resultDic = new Dictionary<LIGHT_TYPE, int>();
        foreach (var idic in inputDic)
        {
            foreach (var randDic in randomDic)                                  //数字相同
            {
                if (idic.Value == randDic.Value)                                //数字顺序相同
                {
                    
                    if (idic.Key == randDic.Key)
                    {
                        green++;                                                //数字且顺序相同的个数
                    }
                    else {
                        yellow++;                                               //数字相同但顺序不同的个数
                    }
                    
                }
            }
        }
        red = inputDic.Count - green - yellow;                                  //数字不同且顺序不同的个数

        resultDic.Add(LIGHT_TYPE.red,red);
        resultDic.Add(LIGHT_TYPE.yellow, yellow);
        resultDic.Add(LIGHT_TYPE.green, green);

        return resultDic;
    }

    /// <summary>
    /// 显示输入框
    /// </summary>
    /// <param name="gameLv"></param>
    private void ShowInputNumRoot(GAME_LEVEL gameLv)
    {
        for (int i = 1; i <= (int)gameLv; i++)
        {
            //GameObject obj = transform.Find("LeftPart/numberInputRoot/numberInput_" + i).gameObject;
            GameObject obj = transform.Find("LeftPart/DragInputNumRoot/DragInputItem_" + i).gameObject;
            obj.SetActive(true);
        }
    }

    /// <summary>
    /// 获取玩家输入的数据
    /// </summary>
    /// <returns></returns>
    public Dictionary<int, int> GetInputNumber(GAME_LEVEL gameLv)
    {
        Dictionary<int, int> reDic = new Dictionary<int, int>();
        Dictionary<int, int> dic = new Dictionary<int, int>();

        //获得用户输入的数据
        dic = GetTempInputNumber(gameLv);

        //检测输入数据是否合法
        if (CheckInputNumLegal(dic))
        {
            reDic = dic;
            GameData.Instance.gameInput = gameInput;
        }
        return reDic;
    }


    public Dictionary<int, int> GetTempInputNumber(GAME_LEVEL gameLv)
    {
        string inputStr = "";
        Dictionary<int, int> dic = new Dictionary<int, int>();

        for (int i = 1; i <= (int)gameLv; i++)
        {
            //GameObject obj = transform.Find("LeftPart/numberInputRoot/numberInput_" + i).gameObject;
            //string inputValue = obj.GetComponent<UIInput>().value;

            GameObject obj = transform.Find("LeftPart/DragInputNumRoot/DragInputItem_" + i + "/Label").gameObject;
            string inputValue = obj.GetComponent<UILabel>().text;
            inputStr += inputValue;
            dic[i] = Convert.ToInt32(inputValue);
        }
        gameInput = inputStr;
        Debug.LogError("##gameInput" + gameInput);
        return dic;
    }


    /// <summary>
    /// 判断玩家输入的数据是否合法
    /// </summary>
    /// <param name="inputDic"></param>
    /// <returns></returns>
    public bool CheckInputNumLegal(Dictionary<int, int> inputDic) 
    {
        Dictionary<int, int> checkDic = new Dictionary<int, int> { { 1, 1 }, { 2, 2 }, { 3, 3 },
        { 4, 4 },{ 5, 5 },{ 6, 6 },{ 7, 7 },{ 8, 8 },{ 9, 9 }};

        foreach (var item in inputDic)
        {
            if (checkDic.ContainsValue(item.Value))                     //
            {
                checkDic.Remove(item.Value);
            }
            else {
                //Debug.LogError("不能输入0或重复数字哦！");
                TipsManager.Instance.ShowTips("有重复数字哦！");
                return false;
            }
        }
        return true;
    }


    /// <summary>
    /// 系统随机生成数据
    /// </summary>
    /// <param name="number">生成的随机数位数</param>
    /// <returns></returns>
    private Dictionary<int, int> GetRandomNumber(GAME_LEVEL gameLv)
    {
        int randNum;
        if (gameLv == GAME_LEVEL.Three)
        {
            randomDic = GetRandomNum((int)GAME_LEVEL.Three);
        }
        else if (gameLv == GAME_LEVEL.Four)
        {
            randomDic = GetRandomNum((int)GAME_LEVEL.Four);
        }
        else if (gameLv == GAME_LEVEL.Five)
        {
            randomDic = GetRandomNum((int)GAME_LEVEL.Five);
        }
        else if (gameLv == GAME_LEVEL.Six)
        {
            randomDic = GetRandomNum((int)GAME_LEVEL.Six);
        }
        else if (gameLv == GAME_LEVEL.Seven)
        {
            randomDic = GetRandomNum((int)GAME_LEVEL.Seven);
        }
        else if (gameLv == GAME_LEVEL.Eight)
        {
            randomDic = GetRandomNum((int)GAME_LEVEL.Eight);
        }
        else if (gameLv == GAME_LEVEL.Nine)
        {
            randomDic = GetRandomNum((int)GAME_LEVEL.Nine);
        }

        Debug.LogError("@@randNum:" + randomDic.Values);
        return randomDic;
    }



    /// <summary>
    /// 拆分系统随机生成的数字（---弃用----）
    /// </summary>
    /// <param name="Num"></param>
    /// <returns></returns>
    private Dictionary<int, int> SplitRandomNumber(int num)
    {
        int i = 4;
        Dictionary<int, int> dic = new Dictionary<int, int>();
        while (num > 0)
        {
            dic.Add(i--,num % 10);
            num /= 10;
        }
        return dic;
    }


    /// <summary>
    /// 从1-9的数字字典中随机生成不重复的数字
    /// </summary>
    /// <param name="num">生成几位数</param>
    /// <returns></returns>
    private Dictionary<int, int> GetRandomNum(int num)
    {
        int randNum;
        int key = 1;
        string randNumStr = "";
        Dictionary<int, int> numArrayDic = new Dictionary<int, int> { { 1, 1 }, { 2, 2 }, { 3, 3 },
        { 4, 4 },{ 5, 5 },{ 6, 6 },{ 7, 7 },{ 8, 8 },{ 9, 9 }};
        Dictionary<int, int> randDic = new Dictionary<int, int>();

        System.Random rand = new System.Random();

        while (key <= num)
        {
            //随机生成1-9的数字
            randNum = rand.Next(1, 9);
            //数字库中是否还存在这个key，即用来判断是否有重复的数字
            if (numArrayDic.ContainsValue(randNum))
            {
                //将随机生成的1-9的数字保存到输出字典中
                randDic.Add(key++, numArrayDic[randNum]);
                Debug.LogError(numArrayDic[randNum]);
                //显示随机生成的测试数据
                randNumStr += numArrayDic[randNum];
                //移除数字库字典中已经使用过的数字
                numArrayDic.Remove(randNum);
            }
        }

        ResultLabel.text = randNumStr;
        return randDic;
    }
    #endregion
}
