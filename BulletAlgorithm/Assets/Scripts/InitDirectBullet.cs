using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitDirectBullet : MonoBehaviour
{
    public static Vector2 GetDirectVector(float theta)
    {
        Vector2 Ret;
        Ret.x = Mathf.Cos(Mathf.PI / 180 * theta);
        Ret.y = Mathf.Sin(Mathf.PI / 180 * theta);

        return Ret;
    }
}
