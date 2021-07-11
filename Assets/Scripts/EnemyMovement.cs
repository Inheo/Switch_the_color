using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public static float Speed = 4.5f;
    public static float StartSpeed => 4.5f;
    public static float Acceleration => 0.01f;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        //transform.Translate(Vector3.down * Speed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, Vector3.down * 10, Speed * Time.deltaTime);
    }
}
