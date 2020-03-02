using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralShooter : MonoBehaviour
{
    public GameObject BulletPrefab;

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
            GameObject newBullet = Instantiate(BulletPrefab,
            new Vector3(transform.position.x, transform.position.y, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
            newBullet.GetComponent<Bullet>().InitBullet(angle, ShotSpeed, 0, 0);

            angle += AngleRate;
            angle -= Mathf.Floor(angle);

            yield return new WaitForSeconds(0.1f);
        }
    }
}
