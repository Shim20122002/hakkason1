using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isUnlocked = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void Unlock()
    {
        isUnlocked = true;
        Debug.Log("Door is unlocked!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isUnlocked && other.CompareTag("Player"))
        {
            Debug.Log("Player has escaped!");
            // エスケープ処理（例えばシーンの遷移）
            // SceneManager.LoadScene("NextScene");
        }
    }
}
