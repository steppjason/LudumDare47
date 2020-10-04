using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splatter : MonoBehaviour
{
    [SerializeField] int seconds = 1;

    void Update(){
        StartCoroutine(SetInactive());
    }

    IEnumerator SetInactive(){
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}
