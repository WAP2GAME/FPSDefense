using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
    [SerializeField] Transform TurretBody = null; // 터렛몸체 회전부분
    [SerializeField] float TurretRange = 0f; //터렛 사정거리
    [SerializeField] LayerMask T_layerMask = 0; // layermask 특정 레이어를 가진 대상만 검출함.
    [SerializeField] float SpinSpeed = 0f; // 회전속도
    [SerializeField] float FireRate = 0f; // 연사속도변수
    float m_currentFireRate; // 실제 연산에 사용할 변수

    Transform T_target = null; // target transform
    // Start is called before the first frame update
    void SearchEnemy() // 적을 탐색
    {
        Collider[] Tcols = Physics.OverlapSphere(transform.position, TurretRange, T_layerMask); // 터렛의 사정거리에 있는 콜라이더를 모두 검출 overlapSphere: 객체주변의 콜라이더를 검출
        Transform S_target = null; // 터렛과 가장 가까운 대상을 담을 변수

        if (Tcols.Length > 0) // 검출된 콜라이더가 있을경우 >0
        {
            float S_distance = Mathf.Infinity; // 거리를 비교하기위해 일단 infinity값 대입
            foreach (Collider t_colTarget in Tcols) // 검출된 콜라이더의 개수만큼 foreach문이 돌아감
            {
                float t_distance = Vector3.SqrMagnitude(transform.position - t_colTarget.transform.position); // suqmagnitude : 제곱반환(실제거리x실제거리) Distance :루트계산후 반환(실제거리)
                if (S_distance > t_distance) // 그 거리가 distance 보다작다면
                {
                    S_distance = t_distance; // distance 값을 대입하고
                    S_target = t_colTarget.transform; // 가장 가까이있는 대상이라 생각함.
                }
            }
        }
        T_target = S_target; // 최종타겟에 가장 가까운 타겟으로 대입
    }
    void Start()
     {
         m_currentFireRate = FireRate;
         InvokeRepeating("SearchEnemy", 0f, 0.5f); // InvokeRepeation 지연호출, 일정간격호출/  SearchEnemy 메소드를 0초후에 0.5초마다 실행시켜라 ? 
     }
    void Update()
     {
         if (T_target == null)
            TurretBody.Rotate(new Vector3(0, 45, 0) * Time.deltaTime); // 타겟이 없다면 터렛의 몸체가 계속 회전함
         else
         {
            Quaternion t_lookRotation = Quaternion.LookRotation(T_target.position); //lookRotation:특정좌표를 바라보게만드는 회전값을 리턴 , T.target의 위치를 바라봄
            Vector3 t_euler = Quaternion.RotateTowards(TurretBody.rotation, t_lookRotation, SpinSpeed * Time.deltaTime).eulerAngles; //RotateTowards:a지점에서 b지점까지c스피드로 회전

            TurretBody.rotation = Quaternion.Euler(0, t_euler.y, 0); // 터렛이 y축으로만 회전하도록

             Quaternion t_fireRotation = Quaternion.Euler(0, t_lookRotation.eulerAngles.y, 0); // 터렛이 조준해야 할 방향
             if(Quaternion.Angle(TurretBody.rotation, t_fireRotation) <5f) // 터렛의 방향과 조준 할 방향의 각도차를 계산 , 5미만이되면 발사
             {
                m_currentFireRate -= Time.deltaTime;  // 연사변수가 1씩 감소하다가
                if (m_currentFireRate <= 0) // 0보다 작아지면
                {
                    m_currentFireRate = FireRate; // 연사속도 변수를 초기화
                    Debug.Log("1"); // "1" 발사
                }
             }
         }
     }
}