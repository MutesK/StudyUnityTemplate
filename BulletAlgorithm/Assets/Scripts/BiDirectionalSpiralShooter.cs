﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiDirectionalSpiralShooter : MonoBehaviour
{
    [System.Serializable]  // 인스펙터에서 노출하기 위해 Attribute 추가(Meta)
    public struct AngleInfo
    {
        public float ShotAngle;
        public float ShotAngleRate;
    }

    public AngleInfo[] AngleInfos = new AngleInfo[2];

    public GameObject BulletPrefab;
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
            for(int AngleCount = 0; AngleCount < AngleInfos.Length; ++AngleCount)
            {
                for (int BulletIndex = 0; BulletIndex < ShotCount; ++BulletIndex)
                {
                    GameObject newBullet = Instantiate(BulletPrefab,
                        new Vector3(transform.position.x, transform.position.y, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
                    newBullet.GetComponent<Bullet>().InitBullet(AngleInfos[AngleCount].ShotAngle + (float)BulletIndex / ShotCount, ShotSpeed, 0, 0);

                }

                AngleInfos[AngleCount].ShotAngle += AngleInfos[AngleCount].ShotAngleRate;
                AngleInfos[AngleCount].ShotAngle -= Mathf.Floor(AngleInfos[AngleCount].ShotAngle);
            }
        }

        IntervalCounter = (IntervalCounter + 1) % Interval;
    }
}
