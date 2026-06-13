using UnityEngine;

public class HitVfxSpawner : MonoBehaviour
{
    [Header("VFX")]
    [SerializeField] private GameObject hitVfx;
    [SerializeField] private Transform spawnPoint;

    [Header("Cleanup")]
    [SerializeField] private float vfxLifetime = 0.5f;

    public void Spawn()
    {
        if (hitVfx == null) return;

        Vector3 position = GetSpawnPosition();
        Quaternion rotation = GetSpawnRotation();

        GameObject vfxInstance = Instantiate(hitVfx, position, rotation);

        PlayParticleSystems(vfxInstance);

        Destroy(vfxInstance, vfxLifetime);
    }

    private Vector3 GetSpawnPosition()
    {
        if (spawnPoint != null) return spawnPoint.position;

        return transform.position;
    }

    private Quaternion GetSpawnRotation()
    {
        if (spawnPoint != null) return spawnPoint.rotation;

        return Quaternion.identity;
    }

    private void PlayParticleSystems(GameObject vfxInstance)
    {
        ParticleSystem[] particleSystems = vfxInstance.GetComponentsInChildren<ParticleSystem>();

        foreach (ParticleSystem particleSystem in particleSystems)
        {
            particleSystem.Play();
        }
    }
}