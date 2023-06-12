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

    [SerializeField] 
    GameObject particleSystemGO;
    
    ParticleSystem ps;
    ParticleSystem.MainModule mainModule;

    public Color blueActiveColor;

    private Color originalStartColor;
    private float originalStartSpeed;
    private float originalStartSize;
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
        //print("on enter beh");
        if (!origami.wasUsed)
        {
            if (LevelManager.instance.recursosRecolectados[ResourceType.papel] >= origami.paperCost)
            {
                base.OnEnterBehaviour(other);
                currentCheck = Instantiate(checkPrefab).SetOrigami(origami);
                //particulas y sonidito de entrar en la zona
                SetParameters();
            }
            else
            {
                print("no tenes suficiente papel para hacer este origami");
            }
            
        }
        else
        {
            print("ya activaste este sello");
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
            ChangeBackToOriginalParameters();

        }
    }


    public void SetParameters()
    {
        mainModule.startColor = blueActiveColor;
        mainModule.startSpeed = originalStartSpeed * 2f;
        mainModule.startSize = 1.66f;
        //mainModule.emission.rateOverTime = originalEmissionRate * 2f;
    }

    public void ChangeBackToOriginalParameters()
    {
        mainModule.startColor = originalStartColor;
        mainModule.startSpeed = originalStartSpeed;
        mainModule.startSize = originalStartSize;
        //mainModule.emission.rateOverTime = originalEmissionRate;
    }
}
