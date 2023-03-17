using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] switches;

    [SerializeField]
    GameObject exit;

    int numberOfSwitches;

    void Start() 
    {
        exit.GetComponent<Animator>().SetFloat("DoorState", 1);
    }

    public int GetNumberOfSwitches()
    {
        int count = 0;

        for(int i = 0; i < switches.Length; i++)
        {
            if(switches[i].GetComponent<Switch>().isOn == true)
            {
                count++;
            }
            else
            {
                count--;
            }
        }

        numberOfSwitches = count;

        return numberOfSwitches;
    }

    public void GetExitDoorState()
    {
        GetNumberOfSwitches();
        if (numberOfSwitches <= 0)
        {
            exit.GetComponent<Door>().OpenDoor();
        }
    }

    void Update()
    {
        GetExitDoorState();
    }
}
