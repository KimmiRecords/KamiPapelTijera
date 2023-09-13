using UnityEngine;

public class ResourceParticleManager : Singleton<ResourceParticleManager>
{
    public ParticleSystem paperParticles;

    private void Start()
    {
        EventManager.Subscribe(Evento.OnObjectWasCut, SetParticlePosition);
        EventManager.Subscribe(Evento.OnResourceUpdated, ShootParticles);
    }

    public void SetParticlePosition(params object[] parameter)
    {
        paperParticles.transform.position = (Vector3)parameter[0];
    }

    public void ShootParticles(params object[] parameter)
    {
        if ((ResourceType)parameter[0] == ResourceType.papel)
        {
            EmitParticlesAtTarget();
        }
    }

    public void EmitParticlesAtTarget()
    {
        paperParticles.gameObject.SetActive(true);
    }
}