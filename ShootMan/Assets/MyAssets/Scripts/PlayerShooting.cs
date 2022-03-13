using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawner;

    public static int numNPC;
    public static Vector3 vectorToShoot;

    private bool isDead = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayerShoot();
        }

        if (numNPC > 0 && isDead == true)
        {
            isDead = false;
            numNPC--;
        }
    }

    private void PlayerShoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(bulletSpawner.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), out hit))
        {
            Vector3 shootVector = hit.point - bulletSpawner.position;
            vectorToShoot = shootVector;
        }

        //Vector3 shootVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - bulletSpawner.position;
        //vectorToShoot = shootVector;

        Instantiate(bullet, bulletSpawner.position, transform.rotation);
    }
}
