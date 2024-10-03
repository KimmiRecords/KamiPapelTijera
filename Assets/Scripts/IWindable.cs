using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWindable
{
    void GetAffectedByWind(float windForce, Vector3 windDirection);
    void EndAffectedByWind();
    void StartAffectedByWind(float windForce, Vector3 windDirection);
}
