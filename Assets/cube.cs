using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    public Transform explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * 2;
    }

    //void OnTriggerEnter(Collider collision)
    //{

    //    Destroy(collision.gameObject);
    //    print(collision.gameObject.name);
    //}
}
