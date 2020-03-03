using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float Angle;    // 회전각
    private float Speed;     // 탄속

    private float SpeedRate;
    private float AngleRate;
    private ObjectPool BulletPool;


    public void InitBullet(ObjectPool BulletPool, float Angle, float Speed, float AngleRate, float SpeedRate)
    {
        this.Angle = Angle;
        this.Speed = Speed;
        this.AngleRate = AngleRate;
        this.SpeedRate = SpeedRate;

        this.BulletPool = BulletPool;
    }

   
    // Update is called once per frame
    void Update()
    {
        Vector3 Position = gameObject.transform.position;

        float radian = Angle * Mathf.PI * 2;

        Position.x += Speed * Mathf.Cos(radian);
        Position.y += Speed * Mathf.Sin(radian);

        Angle += AngleRate;
        Speed += SpeedRate;

        gameObject.transform.position = Position;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Overlap")  // if you using Object pooling, Just Refund it.
        {
            BulletPool.SetObject(gameObject);
        }
    }
}
