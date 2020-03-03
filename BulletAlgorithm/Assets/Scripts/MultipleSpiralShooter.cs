using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleSpiralShooter : MonoBehaviour
{
    public ObjectPool BulletPool;

    public float ShotAngle;
    public float ShotAngleRate;
    public float ShotSpeed;
    public int ShotCount;

    void Start()
    {
        StartCoroutine(GenerateBullet());
    }

    IEnumerator GenerateBullet()
    {
        while (true)
        {
            MakeBullet();

            yield return new WaitForSeconds(0.1f);
        }
    }

    void MakeBullet()
    {
        for (int bulletIndex = 0; bulletIndex < ShotCount; ++bulletIndex)
        {
            GameObject newBullet = BulletPool.GetObject();
            newBullet.transform.position = gameObject.transform.position;
            newBullet.SetActive(true);
            newBullet.GetComponent<Bullet>().InitBullet(BulletPool, ShotAngle + (float)bulletIndex / ShotCount, ShotSpeed, 0, 0);

            ShotAngle += ShotAngleRate;
            ShotAngle -= Mathf.Floor(ShotAngle);
        }
    }
}
