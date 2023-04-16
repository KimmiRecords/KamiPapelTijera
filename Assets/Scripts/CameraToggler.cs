using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToggler : MonoBehaviour
{
    //este script hace que con mouse3 (centro) cambies de camara, a la proxima en la lista.
    //por ahora solo tengo 2, asi que solo pasa de la 0 a la 1 a la 0 a la 1 y asi

    [SerializeField]
    Cinemachine.CinemachineVirtualCamera[] _virtualCameras;

    int currentCamera = 0;

    [SerializeField]
    int startingCamera;

    private void Start()
    {
        currentCamera = startingCamera;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse2))
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
    }
}
