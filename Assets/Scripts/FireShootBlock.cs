using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShootBlock : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject ShootObject;

    [SerializeField] Transform SpawnPos;

    [SerializeField] float BulletSpeed;

    [SerializeField] float BulletIntervalTime;

   [SerializeField] float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if(timer >= BulletIntervalTime)
        {
            ShootBullet();
            timer = 0;
        }


    }
    void ShootBullet()
    {
        GameObject shootObject = Instantiate(ShootObject, SpawnPos.position, Quaternion.identity);
        shootObject.transform.up = transform.up;
        shootObject.GetComponent<Rigidbody2D>().AddForce(transform.up * BulletSpeed, ForceMode2D.Impulse);
    }
    //IEnumerator ShootObjectCo()
    //{
    //  GameObject shootObject =  Instantiate(ShootObject, SpawnPos.position, Quaternion.identity);
    //    shootObject.GetComponent<Rigidbody2D>().AddForce(transform.up * BulletSpeed, ForceMode2D.Impulse);
    //    yield return new WaitForSeconds(BulletIntervalTime);
    //}
}
