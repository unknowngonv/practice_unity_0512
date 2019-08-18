using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour {

    /// -----------------------------------------
    /// フィールド
    /// -----------------------------------------
    public GameObject player;

	public float speed = 10;

    // delegate型の宣言
    private delegate void OnComplete(string text);

    /// -----------------------------------------
    /// メソッド　- MonoBehaviour
    /// -----------------------------------------
    void Start()
    {
        // 処理を実行するメソッドにコールバックを受け取りたいメソッドを渡す
        //ActionMethod(ActionCallbackMethod);
        // ラムダ式UnityAction
        //ActionMethod(() = &
        //{
        //    Debug.Log("ラムダ式UnityAction実行完了 : ");
        //};

        // 処理を実行するメソッドにコールバックを受け取りたいメソッドを渡す
        DelegateMethod(DelegateCallbackMethod);
    }

    /// -----------------------------------------
    /// メソッド
    /// -----------------------------------------

    // 実行メソッド
    private void DelegateMethod(OnComplete callback)
    {
        // コールバック実行
        callback("文字列だよ");
    }

    // delegateのコールバックで呼び出されるメソッド
    public void DelegateCallbackMethod(string text)
    {
        Debug.Log("delegate実行完了 : " + text);
    }


    // 実行メソッド
    private void ActionMethod(UnityAction callback)
    {
        // コールバック実行
        callback();
    }

    // UnityActionのコールバックで呼び出されるメソッド
    public void ActionCallbackMethod()
    {
        Debug.Log("UnityAction実行完了");
    }

    void FixedUpdate()
	{
		//入力をxとzに代入。
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis ("Vertical");

		//同一のGameObjectが持つRigidbodyコンポーネントを取得。
		Rigidbody rigidbody = player.GetComponent<Rigidbody>();

		//Rigidbodyのx軸(横)とz軸(奥)に力を加える。
		rigidbody.AddForce(x*speed,0,z*speed);
	}

}
