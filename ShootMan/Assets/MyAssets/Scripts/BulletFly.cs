using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    public float speedBullet;
    public float timeToDestroy;

    private Vector3 vectorToShoot;

    private void Start()
    {
        Invoke("DestroyBullet", timeToDestroy);
    }

    void Update()
    {
        vectorToShoot = PlayerShooting.vectorToShoot;

        transform.Translate(vectorToShoot * Time.deltaTime * speedBullet);
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
