using UnityEngine;
using System.Collections;

public class GameData {

    //游戏等级
    public GAME_LEVEL GameLevel = GAME_LEVEL.Four;

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
    Six = 6
}