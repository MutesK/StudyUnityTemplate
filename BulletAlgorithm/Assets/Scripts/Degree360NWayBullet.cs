using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Degree360NWayBullet : MonoBehaviour
{
    public GameObject BulletPrefab;

    private Vector2 ActorPos;
    private Vector2 BulletPos;
    private Vector2 SpeedVector;

    private float[] vx, vy;

    public int MAX_MISSILE_NUMBER = 50; // ?
    public float bulletSpeed;
    public bool isOddPattern;

    // Start is called before the first frame update
    void Start()
    {
        ActorPos = gameObject.transform.position;
        BulletPos = ActorPos;

        vx = new float[MAX_MISSILE_NUMBER];
        vy = new float[MAX_MISSILE_NUMBER];

        float RadianStep = Mathf.PI * 2 / MAX_MISSILE_NUMBER;
        // 2 * Pi / 미사일 갯수
        float Radian = 0.0f;  // 미사일 벡터의 이동방향 세타
        if(isOddPattern)
        {
            Radian = RadianStep / 2;
        }

        for(int index = 0; index < MAX_MISSILE_NUMBER; index++, Radian += RadianStep)
        {
            vx[index] = Mathf.Cos(Radian) * bulletSpeed;
            vy[index] = Mathf.Sin(Radian) * bulletSpeed;
        }

        StartCoroutine(BulletGenerator());

    }

    IEnumerator BulletGenerator()
    {
        while(true)
        {
            MakeBullet();
            yield return new WaitForSeconds(1.5f);
        }
    }
    
    private void MakeBullet()
    {
        for(int index =0; index< MAX_MISSILE_NUMBER; ++index)
        {
            ActorPos = gameObject.transform.position;
            BulletPos = ActorPos;

            SpeedVector.x = vx[index];
            SpeedVector.y = vy[index];
            
            GameObject newBullet = Instantiate(BulletPrefab, 
            new Vector3(0, 0, 0),
            new Quaternion(0, 0, 0, 0)) as GameObject;
            newBullet.GetComponent<Bullet>().InitBullet(BulletPos, SpeedVector);
        }
    }
}
