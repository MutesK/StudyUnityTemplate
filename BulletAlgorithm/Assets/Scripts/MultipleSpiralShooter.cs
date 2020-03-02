using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleSpiralShooter : MonoBehaviour
{
    public GameObject BulletPrefab;

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
            GameObject newBullet = Instantiate(BulletPrefab,
            new Vector3(transform.position.x, transform.position.y, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
            newBullet.GetComponent<Bullet>().InitBullet(ShotAngle + (float)bulletIndex / ShotCount, ShotSpeed, 0, 0);

            ShotAngle += ShotAngleRate;
            ShotAngle -= Mathf.Floor(ShotAngle);
        }
    }
}
