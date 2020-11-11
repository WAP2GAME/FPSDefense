using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;
public class enemyAI : MonoBehaviour
{
    private NavMeshAgent agent = null;
    private SearchComponent searchcomponent = null;
    private Vector3 destination;
    public GameObject enemyTransform;
    private float dist;
    [SerializeField] private GameObject target;
    [SerializeField] private Animator Animator;
    private void Start()
    {
        searchcomponent = GetComponent<SearchComponent>();

        agent =GetComponent<NavMeshAgent>();

    }

    void Update() // searchcomponent 를 통해 찾은 적들을 향해 가도록 하는 코드는 넣어야함
    {
        
        int size = searchcomponent.SearchedObjs.Count;
        GameObject[] objects = searchcomponent.SearchedObjs.ToArray(); // 큐에있는 모든 원소를 배열로 변환 ?
        foreach (GameObject distvar in objects)
        {
            if (searchcomponent.SearchedObjs.Count != 0) //주위에 적이있다면 !=0 이라면
            {
                enemyTransform = searchcomponent.SearchedObjs.Dequeue(); // 찾은 적들
                agent.transform.LookAt(target.transform.position); // 타겟을 바라봄
                bool ZombieRun = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
                Animator.SetBool("Z_Run", ZombieRun);
                destination = enemyTransform.transform.position; //이동
                
                //agent.GetComponent<Animation>().Play("Z_Run"); // agent의 Animation에 접근해서 Z_Run 이라는 Animation을 Play시켜라 ?
                agent.destination = destination;  // searchcomponent 를 통해 찾는 위치로 agent가 이동 
                
                /* dist = Vector3.Distance(destination, agent.transform.position); //거리를 재는 변수
                if (dist <= 30.0f) { agent.Stop(); } // 디큐한 플레이어와의 거리가 30이하이면 그 자리에 멈춤 */
            }
            else { agent.destination = target.transform.position; } //target(목표오브젝트) 로 이동
            
        }
    }
}
            

