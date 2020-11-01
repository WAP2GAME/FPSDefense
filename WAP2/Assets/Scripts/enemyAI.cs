using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemyAI : MonoBehaviour
{
    private NavMeshAgent agent = null;
    private SearchComponent searchcomponent = null;
    private Vector3 destination;
    public GameObject enemyTransform;
    private float dist;
    [SerializeField]
    private GameObject target;


    private void Start()

    {
        searchcomponent = GetComponent<SearchComponent>();

        agent = GetComponent<NavMeshAgent>();

    }

    void Update() // searchcomponent 를 통해 찾은 적들을 향해 가도록 하는 코드는 넣어야함
    {
        int size = searchcomponent.SearchedObjs.Count;
        GameObject[] objects = searchcomponent.SearchedObjs.ToArray(); // 큐에있는 모든 원소를 배열로 변환 ?
        foreach (GameObject distvar in objects)
        {
            if (searchcomponent.SearchedObjs.Count != 0)
            {
                enemyTransform = searchcomponent.SearchedObjs.Dequeue(); // 찾은 적들
                destination = enemyTransform.transform.position;
                agent.destination = destination;  // searchcomponent 를 통해 찾는 위치로 agent가 이동 
                dist = Vector3.Distance(destination, agent.transform.position);
                if (dist <= 30.0f) { agent.Stop(); } // 디큐한 플레이어와의 거리가 30이하이면 그 자리에 멈춤
            }
            else { agent.destination = target.transform.position; }

        }
    }
}
            

