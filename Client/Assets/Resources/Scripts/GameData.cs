﻿using UnityEngine;
using System.Collections;

public class GameData
{

    #region 变量

    public GAME_LEVEL GameLevel = GAME_LEVEL.Five;          //游戏等级
    public string gameInput;         //玩家输入数据
    public int gameRound = 1;        //玩家输入次数
    public float roundTime = 2;     //每局游戏时间
    public bool win = false;         //游戏结果
    #endregion

    private static GameData _instance;
    public static GameData Instance {
        get
        {
            if (_instance == null)
            {
                _instance = new GameData();
            }
            return _instance;
        }
    }

}


/// <summary>
/// 红黄绿类型
/// </summary>
public enum LIGHT_TYPE
{
    red,
    yellow,
    green
}

/// <summary>
/// 游戏等级
/// </summary>
public enum GAME_LEVEL
{ 
    Three = 3,
    Four =  4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9
}