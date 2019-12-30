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
        Destroy(gameObject, 10f);
        transform.position += Time.deltaTime * transform.forward * 2;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "bullet")
        {
            Destroy(col.gameObject); //удаляем врага с !КОТОРЫМ! столкнулись.
        }
        Destroy(gameObject); //удаляем нашу пулю если она в что либо врезалась.
    }
}
