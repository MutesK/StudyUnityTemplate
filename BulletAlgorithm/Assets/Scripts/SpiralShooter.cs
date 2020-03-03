using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralShooter : MonoBehaviour
{
    public ObjectPool BulletPool;

    public float ShotAngle;
    public float ShotSpeed;

    public float AngleRate;

    void Start()
    {
       StartCoroutine(GenerateBullet());
    }

    IEnumerator GenerateBullet()
    {
        float angle = ShotAngle;

        while(true)
        {
            GameObject newBullet = BulletPool.GetObject();
            newBullet.transform.position = gameObject.transform.position;
            newBullet.SetActive(true);

            newBullet.GetComponent<Bullet>().InitBullet(BulletPool, angle, ShotSpeed, 0, 0);

            angle += AngleRate;
            angle -= Mathf.Floor(angle);

            yield return new WaitForSeconds(0.1f);
        }
    }
}
