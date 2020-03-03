using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 *  추천 예제
 * 0, 0.02, 0.005, 1, 10, 0 0
 * 0, 0.02, 0.005, 1, 10, -0.003, 0
 * 0, 0.02, 0.005, 1, 10, 0, 0.0002
 * 0, 0.02, 0.005, 1, 10, -0.003 0.0002
 */
public class BentSpiralShooter : MonoBehaviour
{
    public ObjectPool BulletPool;

    public float ShotAngle;
    public float ShotAngleRate;
    public float ShotSpeed;
    public int ShotCount;
    public int Interval;
    public float BulletAngleRate;
    public float BulletSpeedRate;

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

            yield return new WaitForSeconds(0.0001f);
        }
    }

    private void MakeBullet()
    {
        if(IntervalCounter == 0)
        {
            for(int i=0; i< ShotCount; ++i)
            {
                GameObject newBullet = BulletPool.GetObject();
                newBullet.transform.position = gameObject.transform.position;
                newBullet.SetActive(true);

                newBullet.GetComponent<Bullet>().InitBullet(BulletPool,
                    ShotAngle + (float)i / ShotCount, ShotSpeed,
                    BulletAngleRate, BulletSpeedRate);
            }

            ShotAngle += ShotAngleRate;
            ShotAngle -= Mathf.Floor(ShotAngle);
        }

        IntervalCounter = (IntervalCounter + 1) % Interval;
    }
}
