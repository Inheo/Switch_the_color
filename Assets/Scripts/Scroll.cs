using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    public float Speed = 2;
    [SerializeField] private float Duration;
    private float back_Size;

    public Ease AnimationType;

    private float coefAcceleration;
    void Start()
    {
        back_Size = GetComponent<SpriteRenderer>().bounds.size.y;

        coefAcceleration = Speed / EnemyMovement.Speed;
        //transform.DOMove(transform.position + Vector3.down * 20, Duration * (EnemyMovement.Speed / EnemyMovement.StartSpeed)).SetLoops(-1, LoopType.Restart).SetEase(AnimationType);
    }

    private void Update()
    {
        if(transform.position.y == -10)
        {
            transform.position = new Vector3(transform.position.x, 10, transform.position.z);
        }
        else
        {
            float speed = Speed / EnemyMovement.StartSpeed * EnemyMovement.Acceleration;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, -10, transform.position.z), Time.deltaTime * (Speed + (EnemyMovement.Speed - EnemyMovement.StartSpeed) * coefAcceleration));
        }
    }
}
