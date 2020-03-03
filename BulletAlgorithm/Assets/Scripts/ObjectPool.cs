using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
   public GameObject Prefab;
   Stack<GameObject> Objects = new Stack<GameObject>();

   public GameObject GetObject()
   {
       if(Objects.Count <= 0)
        {
            GameObject Obj = Instantiate(Prefab) as GameObject;
            Obj.SetActive(false);

            Objects.Push(Obj);
        }

        return Objects.Pop();
   }

    public void SetObject(GameObject Object)
    {
        Object.SetActive(false);

        Objects.Push(Object);
    }
}
