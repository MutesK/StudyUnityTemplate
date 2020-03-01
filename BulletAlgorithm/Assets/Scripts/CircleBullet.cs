using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBullet : MonoBehaviour
{
    public GameObject BulletPrefab;

    private float theta = 0;

    private Vector2 ActorPos;
    private Vector2 BulletPos;

    public float thetaStep; // 공차 각도
    public float bulletSpeed;

    void Start()
    {
        StartCoroutine(BulletGenerator());
    }

    IEnumerator BulletGenerator()
    {
        while(true)
        {
           MakeBullet();
           yield return new WaitForSeconds(0.1f);
        }
    }


    private void MakeBullet()
    {
        ActorPos = gameObject.transform.position;
        BulletPos = ActorPos;

        if(theta + thetaStep >= 360)
            theta = 0;
        else
            theta += thetaStep;        

        GameObject newBullet = Instantiate(BulletPrefab,
        new Vector3(0,0,0), new Quaternion(0,0,0,0)) as GameObject;
        newBullet.GetComponent<Bullet>().InitBullet(BulletPos, InitDirectBullet.GetDirectVector(theta) * bulletSpeed);    
    }
}
