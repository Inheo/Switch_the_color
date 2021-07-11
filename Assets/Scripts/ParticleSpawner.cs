using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    [SerializeField] private ParticleSystem particlePrefab;

    private Queue<ParticleSystem> particles = new Queue<ParticleSystem>();

    void Awake()
    {
        PullParticle();
    }

    private void PullParticle()
    {
        for (int i = 0; i < 10; i++)
        {
            ParticleSystem particle = Instantiate(particlePrefab, transform);
            particles.Enqueue(particle);
        }
    }

    public void Spawn(Color color)
    {
        particles.Peek().startColor = color;
        particles.Peek().Play();
        particles.Enqueue(particles.Dequeue());
    }
}
