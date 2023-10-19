using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFlap
{
    public void OpenFlap();
    public void CloseFlap();
    public IEnumerator MoveFlap(float targetX, float targetY, float transitionDuration);
    public void ToggleFlap();
}
