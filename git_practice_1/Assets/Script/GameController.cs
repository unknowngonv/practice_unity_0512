using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    /// -----------------------------------------
    /// フィールド[SerializeField]
    /// -----------------------------------------
	[SerializeField]private Text scoreLabel;
    [SerializeField]private Text playerScore;
    [SerializeField]private GameObject winnerLabelObject;
    [SerializeField]private GameObject itemObjects;
    [SerializeField]private Transform itemRoot;

    /// -----------------------------------------
    /// フィールド
    /// -----------------------------------------
    public static GameController instance;

    //オブジェクト数。
    private int count = 0;
    private int countNum;

    //プレイヤースコア。
    public int PlayerScore;

    public bool _ObjDestroyed = false;
    public bool ObjDestroyed
    {
        set { _ObjDestroyed = value;

                if (_ObjDestroyed != false)
                {
                    SetText();
                }
            }
    }

    /// -----------------------------------------
    /// メソッド　- MonoBehaviour
    /// -----------------------------------------
    private void Awake()
	{
		instance = this;

        countNum = 3;
        SetItemObject(countNum);

        //オブジェクト数を取得。
        count = GameObject.FindGameObjectsWithTag ("Item").Length;

		scoreLabel.text = count.ToString ();

        //プレイヤースコアを初期化する。
        PlayerScore = PlayerPrefs.GetInt("SCORE", 0);
        playerScore.text = PlayerScore.ToString();

        ObjDestroyed = false;

    }

    /// -----------------------------------------
    /// メソッド　
    /// -----------------------------------------

    /// <summary>
    /// Itemオブジェクトを配置する。
    /// </summary>
    private void SetItemObject(int num)
    {
        for(int i = 0; i < num; i++)
        {
            var item = Instantiate(itemObjects);
            item.transform.SetParent(itemRoot, false);
        }

    }

    /// <summary>
    /// 左下カウントテキスト表示処理。
    /// </summary>
    private void SetText()
	{
        if (_ObjDestroyed != false)
        {
            count--;
            scoreLabel.text = count.ToString ();

            PlayerScore += 100;

            //プレイヤースコアを保存。
            PlayerPrefs.SetInt("SCORE", PlayerScore);
            PlayerPrefs.Save();
            playerScore.text += PlayerScore.ToString();


            if (count == 0)
            {
				//オブジェクトをアクティブにする
				winnerLabelObject.SetActive (true);
                SceneManager.LoadScene("CloseMenu");
			}

			ObjDestroyed = false;
		}


	}
}
