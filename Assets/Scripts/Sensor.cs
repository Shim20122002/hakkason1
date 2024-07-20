using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public GameObject enemy;
    EnemyController encs;
    // Start is called before the first frame update
    void Start()
    {
        encs = enemy.GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            encs.sensor = true;
            encs.animator.SetBool("Run",true);
            encs.Enemymove();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            encs.sensor = false;
            encs.animator.SetBool("Run",false);
            encs.Enemymove();
        }
    }
}
