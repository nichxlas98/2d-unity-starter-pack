using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f; 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
 
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
 
         float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
    
         angle-=90;
        firePoint.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
