using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ParticlePool : MonoBehaviour
{
    public GameObject particlePrefab;
    List<GameObject> particles = new List<GameObject>();

    GameObject SpawnParticle()
    {
        GameObject particle = Instantiate(particlePrefab);
        particle.transform.parent = transform;
        particles.Add(particle);
        return particle;
    }
}
