using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyRandomMove : MonoBehaviour
{
    public Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyMove());    
    }
    IEnumerator EnemyMove()
    {
        rigid = GetComponent<Rigidbody>();

        while(true)
        {
            float dirx = Random.Range(-1f, 1f);
            float dirz = Random.Range(-1f, 1f);

            yield return new WaitForSeconds(2);
            rigid.velocity = new Vector3(dirx, 5, dirz);
        }
    }
}
