using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject revolverPrefab;
    public Transform muzzle;

    private GameObject bullet;
    public float power = 50f;
    public float distance = 500f;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {

        bullet = Instantiate(revolverPrefab, muzzle.position, muzzle.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * power, ForceMode.Impulse);

        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance))
        {
            
            if (hit.collider.tag == "Enemy")
            {
                Destroy(bullet,0.15f);
                Destroy(hit.collider.gameObject);
            }
        }


        



        Destroy(bullet, 2f);   
            
    }
}
