using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	private bool getObj;

	//トリガーとの接触時に呼ばれるコールバック。
	public void OnTriggerEnter(Collider hit)
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
