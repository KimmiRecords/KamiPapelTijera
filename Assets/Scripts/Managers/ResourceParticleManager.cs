using System.Collections;
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
        Debug.Log("set particle position");
        paperParticles.transform.position = (Vector3)parameter[0];
        paperParticles.gameObject.SetActive(false);

    }

    public void ShootParticles(params object[] parameter)
    {
        if ((ResourceType)parameter[0] == ResourceType.papel)
        {
            Debug.Log("shoot particle");
            EmitParticlesAtTarget();
            StartCoroutine(TurnOffParticles());
        }
    }

    public void EmitParticlesAtTarget()
    {
        paperParticles.gameObject.SetActive(true);
    }

    public IEnumerator TurnOffParticles()
    {
        yield return new WaitForSeconds(1f);
        paperParticles.gameObject.SetActive(false);
    }
}