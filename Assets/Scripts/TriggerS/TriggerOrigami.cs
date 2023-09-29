using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOrigami : TriggerScript
{
    //cuando entras a este trigger hace nacer al origamicheck
    //el origami check se va a encargar de chequear que apretes tab y hagas el origami

    public Origami origami;
    public MultipleRectCheck checkPrefab;
    MultipleRectCheck currentCheck;
    [SerializeField] GameObject particleSystemGO;
    ParticleSystem ps;
    ParticleSystem.MainModule mainModule;
    Color originalStartColor;
    float originalStartSpeed;
    float originalStartSize;

    [Header("Particle Parameters When Step On")]
    public Color blueParticleActiveColor;
    public float activeSpeed = 1.5f;
    public float activeSize = 2f;

    protected override void Start()
    {
        base.Start();
        ps = particleSystemGO.GetComponent<ParticleSystem>();
        mainModule = ps.main;

        originalStartColor = mainModule.startColor.color;
        originalStartSpeed = mainModule.startSpeed.constant;
        originalStartSize = mainModule.startSize.constant;
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
                print("no tenes suficiente papel para hacer este origami");
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
        //mainModule.emission.rateOverTime = originalEmissionRate * 2f;
    }

    public void ChangeBackToOriginalParticleParameters()
    {
        mainModule.startColor = originalStartColor;
        mainModule.startSpeed = originalStartSpeed;
        mainModule.startSize = originalStartSize;
        //mainModule.emission.rateOverTime = originalEmissionRate;
    }
}
