using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Linq;

//Karakterin trigger olaylarını düzenelr
public class TriggerController : MonoBehaviour
{

    PlayerMovement playerMovement;
    GameManager gameManager;

    void Start() 
    {
        playerMovement = GetComponent<PlayerMovement>();
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Enemy enemyScript = collision.GetComponent<Enemy>();

            switch (enemyScript.enemySO.enemyType)
            {
                case EnemySO.EnemyTypes.Sinirli:
                    CinemachineController.Instance.startShake();
                    break;

                case EnemySO.EnemyTypes.Deli:
                    // Deli karakterin yön tuşlarını tersine çevirir
                    playerMovement.invert = true;
                    break;

                case EnemySO.EnemyTypes.Uykulu:
                    // Uykulu karakterin hızını yarıya düşürür
                    playerMovement.moveSpeed /= 2f;
                    break;

                case EnemySO.EnemyTypes.Depresif:
                    //Karakterin toplam enerjisi 1 olduğu için onu 0.2 azaltır.
                    gameManager.ReduceEnergy(0.2f);
                    break;

                case EnemySO.EnemyTypes.Mutsuz:
                    playerMovement.timerMultiplier = 0.5f;
                    break;
            }

            collision.GetComponent<Enemy>().enemyDead();
            
            playerMovement.animator.SetTrigger("isHurt");
            gameManager.PlayPlayerMusic(MusicSO.AuidioTypes.HurtSound);
            //Her kötü olay karakterin canını 0.1 azaltır. Not: Karakterin enerji miktarı 1 dir.
            gameManager.ReduceEnergy();
        }

        else if (collision.tag == "Sticker")
        {
            Sticker stickerScript = collision.GetComponent<Sticker>();

            switch (stickerScript.stickerSO.elixirType)
            {
                case StickerSO.ElixirTypes.AntiSinir:
                    CinemachineController.Instance.endShake();
                    break;

                case StickerSO.ElixirTypes.AntiStress:
                    // AntiStress karakterin yön tuşlarını normale çevirir
                    playerMovement.invert = false;
                    break;

                case StickerSO.ElixirTypes.AntiTired:
                    // Uykulu karakterin hızını normale çevirir
                    if(playerMovement.moveSpeed == 2.5f)
                    {
                        playerMovement.moveSpeed *= 2f;
                    }
                    break;

                case StickerSO.ElixirTypes.AntiDepresif:
                    // Energy miktarını 0.2 artırır.
                    gameManager.IncreaseEnergy(0.2f);
                    break;

                case StickerSO.ElixirTypes.AntiSadness:
                    playerMovement.timerMultiplier = 1f;
                    break;
            }
            gameManager.PlayPlayerMusic(MusicSO.AuidioTypes.ElixirSound);
            Destroy(collision.gameObject);
        }

        
    }
}
