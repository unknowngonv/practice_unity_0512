using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    /// -----------------------------------------
    /// フィールド
    /// -----------------------------------------
    private bool getObj;

    /// -----------------------------------------
    /// メソッド　- MonoBehaviour
    /// -----------------------------------------
    private void Awake()
    {
        //x軸、z軸は-8~8の範囲。
        var randomX = 5;
        var randomY = 5;
        var randomZ = 5;

        SetActiveSelf(randomX, randomY, randomZ);
    }

    /// -----------------------------------------
    /// メソッド
    /// -----------------------------------------

    /// <summary>
    /// アイテムオブジェクトの座標管理。
    /// </summary>
    private void SetActiveSelf(int numX, int numY, int numZ)
    {
        this.transform.position = new Vector3(0,0,0);
    }

    /// <summary>
    /// トリガーとの接触時に呼ばれるコールバック。
    /// </summary>
	private void OnTriggerEnter(Collider hit)
	{
		//接触対象はPlayerタグですか？
		if (hit.CompareTag ("Player"))
		{
			GameController.instance.ObjDestroyed = true;

			//このコンポーネントを持つGameObejctを破棄する。
			Destroy (this.gameObject);		
		}
	}
    	
}
