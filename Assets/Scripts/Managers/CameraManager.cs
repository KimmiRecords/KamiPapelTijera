using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Camara
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

    [SerializeField]
    int startingCamera;

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
        EventManager.Subscribe(Evento.OnDialogueEnd, SetCamera);

        currentCamera = startingCamera;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            ToggleNextCamera();
        }

        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    SetCamera(Camara.CloseUp);
        //}
        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    SetCamera(Camara.Normal);
        //}
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    SetCamera(Camara.General);
        //}
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

    public void SetCamera(Camara cam)
    {
        _virtualCameras[(int)cam].gameObject.SetActive(false);
        currentCamera = (int)cam;
        _virtualCameras[currentCamera].gameObject.SetActive(true);
    }

    public void SetCamera(params object[] parameter)
    {
        if (parameter[0] is int || parameter[0] is Camara)
        {
            SetCamera((int)parameter[0]);
        }
        else if (parameter[0] is Camara)
        {
            SetCamera((Camara)parameter[0]);
        }
    }
    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnDialogueStart, SetCamera);
            EventManager.Unsubscribe(Evento.OnDialogueEnd, SetCamera);
        }
    }
}
