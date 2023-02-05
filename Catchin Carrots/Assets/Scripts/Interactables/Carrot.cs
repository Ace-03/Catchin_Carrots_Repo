using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : Interactable
{

    protected override void Interact()
    {
        Debug.Log("Got " + gameObject.name);

    }
}
