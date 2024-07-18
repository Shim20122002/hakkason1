using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator animator;  // ドアのAnimatorコンポーネント
    public string animationName = "DoorOpen";  // 再生するアニメーションの名前
    public Transform doorTransform;  // ドアのTransformコンポーネント
    public Vector3 openPosition;  // ドアが開いたときの位置
    public Vector3 openRotation;  // ドアが開いたときの回転

    private bool isDoorOpen = false;  // ドアが開いているかどうかのフラグ

    void Awake()
    {
        // doorTransformが設定されていない場合、自身のTransformを設定する
        if (doorTransform == null)
        {
            doorTransform = transform;
        }
    }

    void Update()
    {
        // スペースキーを押したらアニメーションを再生
        if (Input.GetKeyDown(KeyCode.Space) && !isDoorOpen)
        {
            animator.Play(animationName);
            StartCoroutine(KeepDoorOpen());
        }
    }

    private IEnumerator KeepDoorOpen()
    {
        // アニメーションが終了するまで待つ
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        // アニメーションが終了したらドアを開いた状態にする
        doorTransform.position = openPosition;
        doorTransform.eulerAngles = openRotation;
        isDoorOpen = true;
    }
}