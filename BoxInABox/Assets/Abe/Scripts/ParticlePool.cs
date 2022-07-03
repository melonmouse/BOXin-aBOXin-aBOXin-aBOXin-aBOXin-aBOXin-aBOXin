using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ParticlePool : MonoBehaviour
{
    public GameObject particlePrefab;
    public float min_depth_from;
    public float min_depth_to;
    public float max_depth_from;
    public float max_depth_to;
    public float particle_speed;
    HashSet<GameObject> particles = new HashSet<GameObject>();

    void SpawnParticle()
    {
        GameObject particle = Instantiate(particlePrefab);
        particle.transform.parent = transform;
        particle.transform.localPosition = new Vector3(
            Random.Range(-5f, 5f),
            min_depth_from,
            Random.Range(-3f, 3f)
        );
        particle.transform.localEulerAngles = Random.Range(0, 360) * Vector3.up;
        particles.Add(particle);
    }

    void Update()
    {
        if (particles.Count < 100)
        {
            if (Random.value < 20f*Time.deltaTime)
                SpawnParticle();
        }
        List<GameObject> to_remove = new List<GameObject>();
        foreach (GameObject particle in particles)
        {
            float depth = particle.transform.localPosition.y;
            float alpha = 1f;
            //particle.transform.Translate(Vector3.up * depth * (Mathf.Pow(particle_speed, Time.deltaTime) - 1));
            particle.transform.Translate(Vector3.up * particle_speed * Time.deltaTime);
            if (depth < min_depth_to)
            {
                alpha = Mathf.Min(alpha,
                    (depth - min_depth_from) / (min_depth_to - min_depth_from));
            }
            if (depth > max_depth_from)
            {
                alpha = Mathf.Min(alpha,
                    (max_depth_to - depth) / (max_depth_to - max_depth_from));
            }

            particle.GetComponentInChildren<SpriteRenderer>().color =
                new Color(1, 1, 1, alpha);
            if (particle.transform.localPosition.y > max_depth_to)
            {
                to_remove.Add(particle);
            }
        }
        for (int i = 0; i < to_remove.Count; i++)
        {
            particles.Remove(to_remove[i]);
            Destroy(to_remove[i]);
        }
    }
}
