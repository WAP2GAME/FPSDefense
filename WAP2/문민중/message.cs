using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class message : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(sec_message());
    }

    IEnumerator sec_message()
    {
        int sec = 1;
        while (true) {
            Debug.Log("Hi, Friends! " + sec);
            sec++;

            if (sec == 11)
                break;

            yield return new WaitForSeconds(1);

        }
    }

}
