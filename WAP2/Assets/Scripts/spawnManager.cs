using UnityEngine;
using System.Collections;
using System.Security.Claims;
using System.Runtime.InteropServices.ComTypes;

public class spawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnDelay = 1.5f;
    private bool isSpawn = true;
    float spawnTimer = 0f;
    WaitForSeconds seconds;
    Vector3[] positions = new Vector3[6]; // len(6)을 가진 vector3 배열 :? new는  키워드(객체)생성자 ?
 
    private void CreatePositions()
    {
        float viewPosY = Random.Range(0, 10);
        float viewPosX = Random.Range(0, 10);
        for (int i = 0; i < positions.Length; i++)
        {
            viewPosX = Random.Range(0, 10);
            Vector3 viewPos = new Vector3(viewPosX, viewPosY, 0);
            Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);  //뷰포트를 월드좌표로 바꾸어주는 함수 ?
            worldPos.z = 0f;
            positions[i] = worldPos;
            print(worldPos);
        }
    }
    private void Start()
    {
        seconds = new WaitForSeconds(spawnDelay); //  spawndelay를 인자로받아서 waitforseconds 객체가 생성/    
        CreatePositions();
        StartCoroutine(spawnEnemy());

    }
    private IEnumerator spawnEnemy()
    {
        while (true)

        {
            if (isSpawn == true)
            {
                int rand = Random.Range(0, positions.Length);
                GameObject enemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50)), Quaternion.identity); //게임오브젝트 생성함수생성함수

            }
            yield return seconds;


        }

    }
}
