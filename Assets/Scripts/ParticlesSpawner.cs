using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesSpawner : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleObjectPrefab;
    private ParticleSystem particleTemporary;
    public void PlayParticles()
    {
        if (!particleObjectPrefab) return;
        if (!particleTemporary)
        {
            particleTemporary = Instantiate(particleObjectPrefab, transform.position, Quaternion.identity);
            particleTemporary.transform.localScale *= 2;
        }
        particleTemporary.Play();
    }
}
