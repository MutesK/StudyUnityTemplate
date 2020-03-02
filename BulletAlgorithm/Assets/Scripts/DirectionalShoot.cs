using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalShoot : MonoBehaviour
{
    public GameObject BulletPrefab;

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
            GameObject newBullet = Instantiate(BulletPrefab,
            new Vector3(transform.position.x, transform.position.y, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
            newBullet.GetComponent<Bullet>().InitBullet(ShotAngle, ShotSpeed, 0, 0); 

            yield return new WaitForSeconds(0.1f);
        }
    }
}
