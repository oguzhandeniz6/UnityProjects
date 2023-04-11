using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineController : MonoBehaviour
{
    public static CinemachineController Instance {get; private set; }

    CinemachineVirtualCamera cam;

    private GameObject player;

    [SerializeField] float shakeAmount = 1f;

    void Start() 
    {
        Instance = this;
        cam = GetComponent<CinemachineVirtualCamera>();
        endShake();
        player = GameObject.FindGameObjectWithTag("Player");
        cam.Follow = player.transform;
    }

    public void startShake()
    {
        cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = shakeAmount;
    }

    public void endShake()
    {
        cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0f;
    }
}
