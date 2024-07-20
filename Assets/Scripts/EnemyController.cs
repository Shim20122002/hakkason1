using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform[] goals;  // 目標地点の配列
    private GameObject player; // プレイヤーのTransform
    private NavMeshAgent agent;
    private int destNum = 0;
    public bool sensor;
    private Transform tr;
    public Animator animator;
    //private int currentGoalIndex = 0;  // 現在の目標地点のインデックス

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Capsule");
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goals[destNum].position;
        Enemymove();
        animator = GetComponent<Animator>();
        Enemymove();
    }

    // Update is called once per frame
    void Update()
    {
        //navMeshAgent.destination = player.transform.position;
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            Enemymove();
        }
    }

    public void Enemymove()
    {
        if (sensor == false)
        {
            if (goals.Length == 0)
            {
                return;
            }
            destNum += 1;
            if (destNum == 3)
            {
                destNum = 0;
            }
            agent.destination = goals[destNum].position;
        }
        else
        {
            agent.destination = player.transform.position;
        }
    }

}
