using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum CameraMode
{
    CloseUp,
    Normal,
    General,
    BookCenter
}

public class CameraManager : MonoBehaviour
{
    //este script hace que con mouse3 (centro) cambies de camara, a la proxima en la lista.
    public static CameraManager instance;

    [SerializeField]
    Cinemachine.CinemachineVirtualCamera[] _virtualCameras;

    int currentCamera = 0;

    [SerializeField] int startingCamera;
    [SerializeField] float levelStartDelayTime = 1;

    [Header("Casos Especiales")]
    [SerializeField] Dialogue[] dialoguesEspeciales;
    [SerializeField] CameraMode[] camarasEspeciales;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        //DontDestroyOnLoad(this);
    }
    private void Start()
    {
        EventManager.Subscribe(Evento.OnDialogueStart, SetCamera);
        EventManager.Subscribe(Evento.OnDialogueEnd, PrepareCamera);
        EventManager.Subscribe(Evento.OnEncounterStart, SetCamera);
        EventManager.Subscribe(Evento.OnEncounterEnd, SetCamera);
        EventManager.Subscribe(Evento.OnOrigamiGivePaperPlaneHat, SetCamera);


        currentCamera = startingCamera;
        StartCoroutine(LevelStartCameraMovement());
    }

    IEnumerator LevelStartCameraMovement()
    {
        yield return new WaitForSeconds(levelStartDelayTime);
        SetCamera(CameraMode.Normal);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            ToggleNextCamera();
        }
    }

    public void PrepareCamera(params object[] parameter)
    {
        for (int i = 0; i < dialoguesEspeciales.Count(); i++)
        {
            if ((Dialogue)parameter[1] == dialoguesEspeciales[i]) //el dialogue
            {
                Debug.Log("prepare camera. era caso especial: no hago nada");
                //SetCamera(camarasEspeciales[i]);
                return;
            }
        }
        Debug.Log("prepare camera: no era caso especial. set camera");
        SetCamera((CameraMode)parameter[0]);
    }

    public void ToggleNextCamera()
    {
        //prendo la nueva. uso un index para saber cual tengo que encender.
        currentCamera++;
        if (currentCamera >= _virtualCameras.Length) //por si me paso del array
        {
            currentCamera = 0;
        }
        _virtualCameras[currentCamera].gameObject.SetActive(true);


        //apago la anterior. pero el index es distinto, asi que me hago un nuevo int
        int previousCamera = currentCamera - 1;
        if (previousCamera < 0) //si yo le pido index -1 al array crashea unity y se me apaga la compu todo mal. asi que primero chequeo que eso no pase
        {
            previousCamera = _virtualCameras.Length - 1;
        }

        _virtualCameras[previousCamera].gameObject.SetActive(false);
    }

    public void SetCamera(int index)
    {
        _virtualCameras[currentCamera].gameObject.SetActive(false);
        currentCamera = index;
        _virtualCameras[currentCamera].gameObject.SetActive(true);
    }

    public void SetCamera(CameraMode cam)
    {
        Debug.Log("cambio la camara a " + cam);
        _virtualCameras[(int)cam].gameObject.SetActive(false);
        currentCamera = (int)cam;
        _virtualCameras[currentCamera].gameObject.SetActive(true);
    }

    public void SetCamera(params object[] parameter)
    {
        if (parameter[0] is int || parameter[0] is CameraMode)
        {
            Debug.Log("cambio la camara a " + (int)parameter[0]);
            SetCamera((int)parameter[0]);
        }
        else if (parameter[0] is CameraMode)
        {
            Debug.Log("cambio la camara a " + (CameraMode)parameter[0]);
            SetCamera((CameraMode)parameter[0]);
        }
    }
    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnDialogueStart, SetCamera);
            EventManager.Unsubscribe(Evento.OnDialogueEnd, SetCamera);
            EventManager.Unsubscribe(Evento.OnEncounterEnd, SetCamera);
            EventManager.Unsubscribe(Evento.OnEncounterStart, SetCamera);
        }
    }
}
