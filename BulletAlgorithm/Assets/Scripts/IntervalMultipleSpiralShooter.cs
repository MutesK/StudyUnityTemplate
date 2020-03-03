using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntervalMultipleSpiralShooter : MonoBehaviour
{
    public ObjectPool BulletPool;
    public float ShotAngle;
    public float ShotAngleRate;
    public float ShotSpeed;
    public int ShotCount;
    public int Interval;

    private int IntervalCounter = 0;


    void Start()
    {
        StartCoroutine(GenerateBullet());
    }

    IEnumerator GenerateBullet()
    {
        while (true)
        {
            MakeBullet();

            yield return new WaitForSeconds(0.01f);
        }
    }

    void MakeBullet()
    {
        if (0 == IntervalCounter)
        {
            for (int bulletIndex = 0; bulletIndex < ShotCount; ++bulletIndex)
            {
                GameObject newBullet = BulletPool.GetObject();
                newBullet.transform.position = gameObject.transform.position;
                newBullet.SetActive(true);
                newBullet.GetComponent<Bullet>().InitBullet(BulletPool, ShotAngle + (float)bulletIndex / ShotCount, ShotSpeed, 0, 0);
            }

            ShotAngle += ShotAngleRate;
            ShotAngle -= Mathf.Floor(ShotAngle);
        }

        IntervalCounter = (IntervalCounter + 1) % Interval;
    }

}
