using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleShooter : MonoBehaviour
{
    //para las que solo se shootean
    public GameObject[] particleSystemGameObject;
    Dictionary<GameObject, ParticleSystem[]> particleSystemsDict = new Dictionary<GameObject, ParticleSystem[]>();

    //para las que se instancian
    //public GameObject particlePrefab;
    public float timeToDestroy = 2;
    public Vector3 offset = Vector3.zero;

    //la 0 es sprint particles
    //la 1 es jump particles
    //la 2 va a ser reward received particles
    //la 3 es splash (pisar sobre agua)

    private void Start()
    {
        //get all the particle systems in each gameobject and create a list for each of them

        foreach (GameObject item in particleSystemGameObject)
        {
            //fill the dictionary with each go and its particle systems components in children
            particleSystemsDict.Add(item, item.GetComponentsInChildren<ParticleSystem>());
        }
    }

    public void Shoot(int index)
    {
        //shoot all the ps of the go in the index
        foreach (ParticleSystem item in particleSystemsDict[particleSystemGameObject[index]])
        {
            item.Play();
        }
    }

    public void Enable(int index, bool value)
    {
        foreach (ParticleSystem item in particleSystemsDict[particleSystemGameObject[index]])
        {
            item.gameObject.SetActive(value);
        }
    }

    public void Create(int index, Transform targetTransform)
    {
        GameObject particle = Instantiate(particleSystemGameObject[index], targetTransform.position + offset, targetTransform.rotation, null);
        //particle.transform.parent = null;

        StartCoroutine(DestroyCoroutine(timeToDestroy, particle));
    }

    public IEnumerator DestroyCoroutine(float time, GameObject go)
    {
        yield return new WaitForSeconds(time);
        Destroy(go);
    }
}
