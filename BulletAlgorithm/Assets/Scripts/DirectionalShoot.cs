using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalShoot : MonoBehaviour
{
    public ObjectPool BulletPool;

    public float ShotAngle;
    public float ShotSpeed;

   
   void Start()
   {
       StartCoroutine(GenerateBullet());
   }

    IEnumerator GenerateBullet()
    {
        while(true)
        {
            GameObject newBullet = BulletPool.GetObject();
            newBullet.transform.position = gameObject.transform.position;
            newBullet.SetActive(true);

            newBullet.GetComponent<Bullet>().InitBullet(BulletPool, ShotAngle, ShotSpeed, 0, 0); 

            yield return new WaitForSeconds(0.1f);
        }
    }
}
