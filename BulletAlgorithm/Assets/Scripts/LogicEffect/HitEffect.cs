using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    SpriteRenderer Sprite;
    float EffectTime = .0f;
    public float FlickTime;
    public float DurationTime;
    bool isStop = true;

    public void InitEffect(SpriteRenderer RenderSprite)
    {
        Sprite = RenderSprite;
    }

    public void StartEffect()
    {
        if (isStop)
        {
            isStop = false;

            Invoke("OnFlickSprite", 0f);
        }
    }

    public void ForceStopEffect()
    {
        isStop = true;
    }

    public bool isEffecting()
    {
        return isStop;
    }

    private void Update()
    {
        if(!isStop)
        {
            EffectTime = Time.deltaTime;
        }
    }

    void OnFlickSprite()
    { 
        if(isStop || DurationTime <= EffectTime)
        {
            Sprite.color = new Color(1, 1, 1, 1);
            isStop = true;
            return;
        }

        Sprite.color = new Color(1, 1, 1, 0.4f);
        Invoke("OffFlickSprite", 0.5f);
    }

    void OffFlickSprite()
    {
        Sprite.color = new Color(1,1,1,1);
        Invoke("OnFlickSprite", 0.5f);
    }
}
