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

    #endregion

    
    #region 变量
    private int numOne;
    private int numTwo;
    private int numThree;
    private int numFour;

    private int resultNum;

    private Dictionary<int, int> inputDic = new Dictionary<int, int>();             //玩家输入的数据
    private Dictionary<int, int> randomDic = new Dictionary<int, int>();            //系统随机生成的数据
    private Dictionary<string, int> resultDic = new Dictionary<string, int>();      //游戏结果数据
    #endregion

    void Awake()
    {
        number_One_Input.value = "0";
        number_Two_Input.value = "0";
        number_three_Input.value = "0";
        number_four_Input.value = "0";
    }

    #region 方法
    /// <summary>
    /// 确定按钮
    /// </summary>
    public void OnOkBtnClick()
   {
        //获得用户输入的数据
        inputDic = GetInputNumber();
        //获取系统生成的随机数据
        randomDic = GetRandomNumber(4);
        //比较用户输入的数据和系统生成的数据
        resultDic = CompareInputAndRandomNum(inputDic,randomDic);
        
   }



/// <summary>
/// 刷新红黄绿的显示
/// </summary>
/// <param name="dic"></param>
    private void RefreshLighterShow(Dictionary<string,int> dic)
    {


    }


    /// <summary>
    /// 比较玩家输入数据和系统生成的随机数
    /// </summary>
    /// <param name="inputDic"></param>
    /// <param name="randomDic"></param>
    /// <returns></returns>
    private Dictionary<string, int> CompareInputAndRandomNum(Dictionary<int,int> inputDic,Dictionary<int,int> randomDic)
    {
        int green = 0;
        int yellow = 0;
        int red = 0;
        Dictionary<string, int> resultDic = new Dictionary<string, int>();
        foreach (var idic in inputDic)
        {
            foreach (var randDic in randomDic)
            {
                if (idic.Value == randDic.Value)
                {
                    if (idic.Key == randDic.Key)
                    {
                        green++;
                        continue;
                    }
                    else {
                        yellow++;
                        continue;
                    }
                    
                }
            }
        }
        red = inputDic.Count - green - yellow;

        resultDic.Add("red",red);
        resultDic.Add("yellow", yellow);
        resultDic.Add("green", green);

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
    private Dictionary<int, int> GetRandomNumber(int number)
    {
        System.Random rand = new System.Random();
        int randNum;
        if (number == 3)
        {
            randNum = rand.Next(100, 999);
            randomDic = SplitRandomNumber(randNum);
        }
        else if (number == 4)
        {
            randNum = rand.Next(1000, 9999);
            randomDic = SplitRandomNumber(randNum);
        }
        else if (number == 5)
        {
            randNum = rand.Next(10000, 99999);
            randomDic = SplitRandomNumber(randNum);
        }
        else if (number == 6)
        {
            randNum = rand.Next(100000, 999999);
            randomDic = SplitRandomNumber(randNum);
        }
        

        return randomDic;
    }


    /// <summary>
    /// 拆分系统随机生成的数字
    /// </summary>
    /// <param name="Num"></param>
    /// <returns></returns>
    private Dictionary<int, int> SplitRandomNumber(int Num)
    {
        int i = 1;
        Dictionary<int, int> dic = new Dictionary<int, int>();
        while (Num != 0)
        {
            dic.Add(i++,Num%10);
            Num /= 10;
        }
        return dic;
    }
    #endregion
}
