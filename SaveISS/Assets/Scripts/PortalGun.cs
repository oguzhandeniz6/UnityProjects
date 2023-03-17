using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PortalGun : MonoBehaviour
{
    Camera cam;
    public GameObject firstPortal;
    public GameObject secondPortal;
    public Transform pivot;

    [SerializeField] GameObject Player;

    RaycastHit hit;

    bool availPortal;
    
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector3 cursorPos = cam.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetMouseButtonDown(0))
        {
            firstPortal = GameObject.FindGameObjectWithTag("First Portal");
            CreatePortal(firstPortal, cursorPos, Player);
        }
        if(Input.GetMouseButtonDown(1))
        {
            secondPortal = GameObject.FindGameObjectWithTag("Second Portal");
            CreatePortal(secondPortal, cursorPos, Player);
        }
    }

    void CreatePortal(GameObject portal, Vector3 cursorPos, GameObject pl)
    {
        float distance = Vector3.Distance (pl.transform.position, cursorPos);
        if (Mathf.Abs(distance) < 13f)
        {
            portal.transform.position = new Vector2 (cursorPos.x, cursorPos.y);
        }
    }
}
