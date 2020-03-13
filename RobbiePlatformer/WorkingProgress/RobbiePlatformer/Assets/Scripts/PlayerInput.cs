using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)] // 유니티 스크립트 실행순서 정렬 변수
public class PlayerInput : MonoBehaviour
{
    [HideInInspector]
    public float horizontal;   // 플레이어 입력 값
    [HideInInspector]
    public bool jumpHeld;   
    [HideInInspector]
    public bool jumpPressed;
    [HideInInspector]
    public bool crouchHeld;
    [HideInInspector]
    public bool crouchPressed;

    bool readyToClear;  // 입력 동기화를 위한 불

    void ClearInput()
    {
        if(!readyToClear)
            return;

        horizontal = 0;
        jumpPressed = false;
        jumpHeld = false;
        crouchPressed = false;
        crouchHeld = false;

        readyToClear = false;
    }

    void ProcessKeyboardInput()
    {
        /*
            GetButton

            - 버튼을 누르고 있을때 계속해서 True가 발생합니다.

            GetButtonDown

            -버튼을 누를때 한번 True가 발생합니다.

            GetButtonUp

            -버튼을 눌렀다가 땠을 경우 True가 발생합니다.

         */

        // 수평 이동
        horizontal += Input.GetAxis("Horizontal");

        jumpPressed = jumpPressed | Input.GetButtonDown("Jump");
        jumpHeld = jumpHeld | Input.GetButton("Jump");

        crouchPressed = crouchPressed | Input.GetButtonDown("Crouch");
        crouchHeld = crouchHeld | Input.GetButton("Crouch");
    }


    // Update is called once per frame
    void Update()
    {
        ClearInput();  // 이미 존재한 입력값 변수 초기화

        // 게임종료(게임매니저)

        ProcessKeyboardInput();

        horizontal = Mathf.Clamp(horizontal, -1f, 1f);
    }

    void FixedUpdate()
    {
        // Physical Update 타임이 되면 입력값 초기화를 해주게 유도한다.
        readyToClear = true;
    }
}
