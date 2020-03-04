using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Project Setting에 있는 Input Manager에 키 값을 받아 움직이게 합니다.
 *  모든 플레이어 관련 로직처리는 이곳에 있는게 좋습니다.
 */
public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;

    public HitEffect Effect;


    // Start is called before the first frame update
    void Start()
    {
        Effect.InitEffect(GetComponent<SpriteRenderer>());
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(horizontal, vertical, 0) * MoveSpeed
            * Time.deltaTime;

        transform.position = curPos + nextPos;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Debug.Log("OnHit");
            Effect.StartEffect();
        }
    }
}
