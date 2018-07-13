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
    public UIInput number_One_Input;
    public UIInput number_Two_Input;
    public UIInput number_three_Input;
    public UIInput number_four_Input;

    public ShowLogPart theShowLogPart;
    public ShowResultPart theShowResultPart;
    //测试用显示结果
    public UILabel ResultLabel;                       

    
    #endregion

    
    #region 变量
    private int numOne;
    private int numTwo;
    private int numThree;
    private int numFour;

    //正确结果
    private int resultNum;

    private Dictionary<int, int> inputDic = new Dictionary<int, int>();                     //玩家输入的数据
    private Dictionary<int, int> randomDic = new Dictionary<int, int>();                    //系统随机生成的数据
    private Dictionary<LIGHT_TYPE, int> resultDic = new Dictionary<LIGHT_TYPE, int>();      //游戏结果数据


    #endregion

    void Awake()
    {
        number_One_Input.value = "0";
        number_Two_Input.value = "0";
        number_three_Input.value = "0";
        number_four_Input.value = "0";
        //获取系统生成的随机数据
        randomDic = GetRandomNumber(GAME_LEVEL.Four);
    }



    #region 方法
    /// <summary>
    /// 确定按钮
    /// </summary>
    public void OnOkBtnClick()
   {
        //获得用户输入的数据
        inputDic = GetInputNumber();

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
    /// 获取玩家输入的数据
    /// </summary>
    /// <returns></returns>
    private Dictionary<int, int> GetInputNumber()
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        numOne = Convert.ToInt32(number_One_Input.value);
        numTwo = Convert.ToInt32(number_Two_Input.value);
        numThree = Convert.ToInt32(number_three_Input.value);
        numFour = Convert.ToInt32(number_four_Input.value);

        Debug.LogError(numOne);
        Debug.LogError(numTwo);
        Debug.LogError(numThree);
        Debug.LogError(numFour);

        dic.Add(1,numOne);
        dic.Add(2,numTwo);
        dic.Add(3,numThree);
        dic.Add(4,numFour);

        return dic;
    }

    /// <summary>
    /// 系统随机生成数据
    /// </summary>
    /// <param name="number">生成的随机数位数</param>
    /// <returns></returns>
    private Dictionary<int, int> GetRandomNumber(GAME_LEVEL gameLv)
    {
        System.Random rand = new System.Random();
        int randNum;
        if (gameLv == GAME_LEVEL.Three)
        {
            randNum = rand.Next(100, 999);
            randomDic = SplitRandomNumber(randNum);

            ResultLabel.text = randNum.ToString();
        }
        else if (gameLv == GAME_LEVEL.Four)
        {
            randNum = rand.Next(1000, 9999);
            randomDic = SplitRandomNumber(randNum)
                ;
            ResultLabel.text = randNum.ToString();
        }
        else if (gameLv == GAME_LEVEL.Five)
        {
            randNum = rand.Next(10000, 99999);
            randomDic = SplitRandomNumber(randNum);

            ResultLabel.text = randNum.ToString();
        }
        else if (gameLv == GAME_LEVEL.Six)
        {
            randNum = rand.Next(100000, 999999);
            randomDic = SplitRandomNumber(randNum);

            ResultLabel.text = randNum.ToString();
        }

        Debug.LogError("@@randNum:" + randomDic.Values);
        return randomDic;
    }


    /// <summary>
    /// 检测系统随机生成的数字是否合法（没有重复数字）
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    private bool CheckRandomNumLegal(int num)
    {

        return false;
    }

    /// <summary>
    /// 拆分系统随机生成的数字
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
 //           Debug.LogError("%%" + num % 10);
            num /= 10;
        }
        return dic;
    }
    #endregion
}
