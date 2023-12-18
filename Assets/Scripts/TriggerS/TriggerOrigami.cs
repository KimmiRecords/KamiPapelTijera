using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOrigami : TriggerScript
{
    //cuando entras a este trigger hace nacer al origamicheck
    //el origami check se va a encargar de chequear que apretes tab y hagas el origami

    //para cargar en el inspector
    public Origami origami;
    public MultipleRectCheck checkPrefab;
    [SerializeField] GameObject particleSystemGO;

    [Header("Particle Parameters When Step On")]
    public Color blueParticleActiveColor;
    public float activeSpeed = 1.5f;
    public float activeSize = 2f;
    public float orbitalZ = 2f;

    //auxiliares
    MultipleRectCheck currentCheck;
    ParticleSystem ps;
    ParticleSystem.MainModule mainModule;
    ParticleSystem.VelocityOverLifetimeModule velocityModule;
    Color originalStartColor;
    float originalStartSpeed;
    float originalStartSize;
    float originalorbitalZ;

    protected override void Start()
    {
        base.Start();
        ps = particleSystemGO.GetComponent<ParticleSystem>();
        mainModule = ps.main;
        velocityModule = ps.velocityOverLifetime;

        originalStartColor = mainModule.startColor.color;
        originalStartSpeed = mainModule.startSpeed.constant;
        originalStartSize = mainModule.startSize.constant;
        originalorbitalZ = velocityModule.orbitalZ.constant;
        //originalEmissionRate = mainModule.emission.rateOverTime.constant;
    }

    public override void OnEnterBehaviour(Collider other)
    {
        if (origami.wasUsed)
        {
            print("ya activaste este sello");
        }
        else
        {
            if (LevelManager.Instance.recursosRecolectados[ResourceType.papel] >= origami.paperCost)
            {
                base.OnEnterBehaviour(other);
                currentCheck = Instantiate(checkPrefab).SetOrigami(origami);
                //particulas y sonidito de entrar en la zona
                SetParticleParameters();
            }
            else
            {
                //print("no tenes suficiente papel para hacer este origami");
                TooltipManager.Instance.ShowTooltip("No tenes suficiente papel para hacer este origami", postItColor);
            }
        }
    }

    public override void OnExitBehaviour()
    {
        //print("on exit beh");

        if (currentCheck != null)
        {
            base.OnExitBehaviour();
            currentCheck.EndOrigami(origami);
            Destroy(currentCheck.gameObject);
            //apagar particulas y sonidito de salir en la zona
            ChangeBackToOriginalParticleParameters();
        }
    }

    public void SetParticleParameters()
    {
        mainModule.startColor = blueParticleActiveColor;
        mainModule.startSpeed = originalStartSpeed * activeSpeed;
        mainModule.startSize = activeSize;
        velocityModule.orbitalZ = orbitalZ;
        //mainModule.emission.rateOverTime = originalEmissionRate * 2f;
    }

    public void ChangeBackToOriginalParticleParameters()
    {
        mainModule.startColor = originalStartColor;
        mainModule.startSpeed = originalStartSpeed;
        mainModule.startSize = originalStartSize;
        velocityModule.orbitalZ = originalorbitalZ;
        //mainModule.emission.rateOverTime = originalEmissionRate;
    }
}
