using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    void Awake()
    {
        StartCoroutine(countDownToDie());
    }
    IEnumerator countDownToDie()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
