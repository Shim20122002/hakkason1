using UnityEngine;
using System.Collections;

public class ClosetInteraction : MonoBehaviour
{
    public Camera playerCamera;
    public float interactionRange = 5f;
    public Transform lockerInsidePosition;
    private bool isInsideLocker = false;
    public Animation lockerAnimation;

    void Start()
    {
        lockerAnimation = GetComponent<Animation>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isInsideLocker)
            {
                ExitLocker();
            }
            else
            {
                Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, interactionRange))
                {
                    if (hit.collider.CompareTag("Closet"))
                    {
                        StartCoroutine(EnterLockerCoroutine(hit.collider.gameObject));
                    }
                }
            }
        }
    }

    IEnumerator EnterLockerCoroutine(GameObject locker)
    {
        if (lockerAnimation != null)
        {
            lockerAnimation.Play("Cube.005|Cube.005Action.001"); // アニメーションの再生
        }

        // アニメーションの再生が完了するまで待機
        yield return new WaitForSeconds(lockerAnimation.clip.length);

        transform.position = lockerInsidePosition.position;
        isInsideLocker = true;
        Debug.Log("ロッカーの中に入りました！");
    }

    void ExitLocker()
    {
        transform.position += transform.forward * 2.0f;
        isInsideLocker = false;
        Debug.Log("ロッカーの外に出ました！");

        // アニメーションの停止
        if (lockerAnimation != null)
        {
            lockerAnimation.Stop("Cube.005|Cube.005Action.001"); // "Open"アニメーションの停止
        }
    }
}
