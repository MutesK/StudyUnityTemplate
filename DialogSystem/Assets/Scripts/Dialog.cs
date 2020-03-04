using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // For Inspector
public class Dialog
{
    public string name;  // NPC Name

    [TextArea(3, 10)] // For Inspector 유니티 에디터에서 텍스트 창이 3*10 크기로 나옴
    public string[] Sentences;  // Dialogs 
}
