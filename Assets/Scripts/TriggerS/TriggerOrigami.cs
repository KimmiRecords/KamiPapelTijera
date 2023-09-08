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

    public Color blueParticleActiveColor;
    Color originalStartColor;
    float originalStartSpeed;
    float originalStartSize;
    //private float originalEmissionRate;

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
                TooltipManager.instance.ShowTooltip("No tenes suficiente papel para hacer este origami", postItColor);
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
        mainModule.startSpeed = originalStartSpeed * 1.5f;
        mainModule.startSize = 2f;
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
