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
        // Convertir la posición del objeto 3D a posición en la pantalla (2D)
        //Vector3 screenPosition = Camera.main.WorldToScreenPoint(target.position);

        // Crear una instancia del sistema de partículas en el canvas
        //paperParticles.transform.position = target.position;

        paperParticles.gameObject.SetActive(true);
    }
}