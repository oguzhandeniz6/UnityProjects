using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Sticker",menuName ="StickerSO")]
public class StickerSO : ScriptableObject
{
    //karakterin toplayabilecegi ve aldigi negatif etkileri tersine ceviren object tipleri.
    public enum ElixirTypes
    {
        AntiDepresif,
        AntiSinir,
        AntiStress,
        AntiSadness,
        AntiTired
    }

    public ElixirTypes elixirType;
}
