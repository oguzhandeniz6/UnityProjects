using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName ="Music",menuName ="MusicSO")]
public class MusicSO : ScriptableObject
{
    public enum AuidioTypes
    {
        ElixirSound,
        ButtonClickSound,
        DieSound,
        FireSound,
        MainStoryMusic,
        MainGameMusic,
        BombCollectSound,
        HurtSound
    }
    [Serializable]
    public struct Auidio
    {
        [SerializeField] public AuidioTypes type;
        [SerializeField] public AudioClip audioClips;
    }

    public List<Auidio> audioClips;
}
   
