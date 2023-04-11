using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Enemy",menuName ="EnemySO")]
public class EnemySO : ScriptableObject
{
    //Dusman Tipleri
    public enum EnemyTypes
    {
        Deli,
        Sinirli,
        Depresif,
        Mutsuz,
        Uykulu
    }

    [SerializeField] public float speed;

    [SerializeField] public float deathSpeed;

    [SerializeField] public EnemyTypes enemyType;
}
