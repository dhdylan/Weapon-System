using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    private ParticleSystem attachedParticleSystem;
    private float particleSystemDuration;
    void Start()
    {
        attachedParticleSystem = GetComponent<ParticleSystem>();
        particleSystemDuration = attachedParticleSystem.main.duration;
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(particleSystemDuration);
        Destroy(this.gameObject);
    }
}
