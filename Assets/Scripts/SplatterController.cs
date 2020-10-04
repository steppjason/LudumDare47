using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatterController : MonoBehaviour
{
    [SerializeField] int splatterCount = 100;
    
    [SerializeField] GameObject splatter;
    [SerializeField] GameObject splatterParent;

    private Vector3 defaultPos = new Vector3(-100,0,0);
    private static GameObject[] splatterPool;
    private static int seconds = 1;


    // Start is called before the first frame update
    void Start()
    {
         InstantiateExplosions();
    }


    private void InstantiateExplosions(){
        splatterPool = new GameObject[splatterCount];
        for(int i = 0; i < splatterPool.Length; i++){
            splatterPool[i] = Instantiate(splatter, defaultPos, Quaternion.identity);
            splatterPool[i].transform.parent = splatterParent.transform;
            splatterPool[i].gameObject.SetActive(false);
        }
    }

    public static GameObject GetAvailble(){

        for(int i = 0; i < splatterPool.Length; i++){
            if(!splatterPool[i].gameObject.activeInHierarchy){
                return splatterPool[i];
            }
        }
        return null;
    }
}
