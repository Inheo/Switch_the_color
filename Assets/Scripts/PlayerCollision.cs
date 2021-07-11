using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private ParticleSpawner particleSpawner;
    [SerializeField] private AudioSource collisionSound;
    public static event Action onCorrectCollision;
    public static event Action onLose;

    private void Start()
    {
        onLose += Lose;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            particleSpawner.Spawn(enemy.Color);
            collision.gameObject.SetActive(false);
            PlayCollisionSound();

            if (enemy.IndexColor == PlayerColorSwitch.Instance.IndexColor)
            {
                onCorrectCollision?.Invoke();
                EnemyMovement.Speed += EnemyMovement.Acceleration;
            }
            else
            {
                onLose?.Invoke();
            }
        }
    }

    private void Lose()
    {
        ShakeCamera();
        gameObject.SetActive(false);
    }
    private void ShakeCamera()
    {
        Camera.main.transform
                       .DOShakePosition(1f, .2f, 20, 90f)
                       .OnComplete(() => {
                           Game.Instance.ShowResultPanel();
                           gameObject.SetActive(true);
                           Camera.main.transform.position = new Vector3(0, 0, -10);
                    });
    }

    private void PlayCollisionSound()
    {
        if(PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            collisionSound.Play();
        }
    }

    private void OnDestroy()
    {
        onLose -= Lose;
    }
}
