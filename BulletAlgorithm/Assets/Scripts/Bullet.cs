using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 BulletPos;
    private Vector2 SpeedVector;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(SpeedVector * Time.deltaTime);
    }

    public void InitBullet(Vector2 Pos, Vector2 Speed)
    {
        BulletPos = Pos;
        SpeedVector = Speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Overlap")  // if you using Object pooling, Just Refund it.
        {
            Destroy(gameObject);
        }
    }
}
