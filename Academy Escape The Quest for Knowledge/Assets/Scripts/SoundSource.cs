using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundSource : MonoBehaviour
{
    [SerializeField] AudioSource mainMusicSource;
    [SerializeField] AudioSource playerMusicSource;
    [SerializeField] MusicSO musics;

    public void PlayPlayerMusic(MusicSO.AuidioTypes auidioTypes)
    {
        playerMusicSource.PlayOneShot(musics.audioClips.FirstOrDefault(p => p.type == auidioTypes).audioClips);
    }
    public void PlayMainMusic(MusicSO.AuidioTypes auidioTypes)
    {
        mainMusicSource.PlayOneShot(musics.audioClips.FirstOrDefault(p=> p.type == auidioTypes).audioClips);
    }
}
