using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChanger : MonoBehaviour
{
    public void DoSomething()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }
}
