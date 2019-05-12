using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	[SerializeField]private Text scoreLabel;
	[SerializeField]private GameObject winnerLabelObject;

	public static GameController instance;
    private static int count = 0;

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

	private void Awake()
	{
		instance = this;
		count = GameObject.FindGameObjectsWithTag ("Item").Length;

		scoreLabel.text = count.ToString ();

		ObjDestroyed = false;
	}

    public void SetText()
	{
        if (_ObjDestroyed != false)
        {
            count--;
            scoreLabel.text = count.ToString ();

			if (count == 0)
            {
				//オブジェクトをアクティブにする
				winnerLabelObject.SetActive (true);
			}

			ObjDestroyed = false;
		}


	}
}
