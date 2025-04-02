using Unity.Cinemachine;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] AudioClip collisionAudioClip;
    [SerializeField] ParticleSystem collisionParticleSystem;
    [SerializeField] float shakeModifier;
    [SerializeField] float volumeModifier;
    [SerializeField] float collisionCooldown;

    AudioSource ads;
    CinemachineImpulseSource cinemachineImpulseSource;
    float collisionTimer = 1f;

    void Awake()
    {
        ads = GetComponent<AudioSource>();
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    void Update()
    {
        collisionTimer += Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collisionTimer < collisionCooldown) return;

        FireImpulse();
        CollisionVFX(collision);
        CollisionSFX(collision);

        collisionTimer = 0f;
    }

    void FireImpulse()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float shakeIntensity = (1f / distance) * shakeModifier;
        shakeIntensity = Mathf.Min(shakeIntensity, 1f);

        cinemachineImpulseSource.GenerateImpulse(shakeIntensity);
    }

    void CollisionVFX(Collision collision)
    {
        ContactPoint contactPoint = collision.contacts[0];

        collisionParticleSystem.transform.position = contactPoint.point;
        collisionParticleSystem.Play();
    }

    void CollisionSFX(Collision collision)
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float collisionVolume = (1f / distance) * volumeModifier;
        collisionVolume = Mathf.Min(collisionVolume, 1f);

        ads.PlayOneShot(collisionAudioClip, collisionVolume);
    }
}
