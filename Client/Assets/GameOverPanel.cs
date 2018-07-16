using UnityEngine;
using System.Collections;

public class GameOverPanel : MonoBehaviour {


    public void OKBtnClick()
    {
        this.gameObject.SetActive(false);
    }
}
