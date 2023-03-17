using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator anim;

    [SerializeField]
    GameObject DoorType;

    int stateOfDoor = 1;

    void Start() 
    {
        anim = GetComponent<Animator>();

        if(DoorType.name == "EntryDoor")
        {
            anim.SetFloat("DoorState", 3);
        }

        if(DoorType.name == "ExitDoor")
        {
            anim.SetFloat("DoorState", 1);
        }
    }

    public void LockDoor()
    {
        if(DoorType.name == "ExitDoor")
        {
            anim.SetFloat("DoorState", 1);
            stateOfDoor = 1;
        }
    }

    public void UnlockDoor()
    {
        if(DoorType.name == "ExitDoor")
        {
            anim.SetFloat("DoorState", 2);
            stateOfDoor = 2;
        }
    }

    public void OpenDoor()
    {
        if(DoorType.name == "ExitDoor")
        {
            anim.SetFloat("DoorState", 3);
            stateOfDoor = 3;
        }
    }
}
