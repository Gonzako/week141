using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curveAnimator : MonoBehaviour
{
    private IHaveAnimationCurve target;
    private AnimationCurve newCurve;

    public Vector2 speed;
    public MonoBehaviour curveToAnimate;

    private void OnEnable()
    {
        target = curveToAnimate as IHaveAnimationCurve;
        if(target == null)
        {
            Debug.Log("Monobehaviour" + curveToAnimate.GetType().Name + "doesnt implement IHaveAnimationCurve.");
            this.enabled = false;
        }
    }


    void Update()
    {
        newCurve = CopyAnimationCurve(target.curve);
        for (int i = 0; i < newCurve.keys.Length; i++)
        {
            var n = newCurve.keys[i];
            n.time += speed.x * Time.deltaTime;
            n.value += speed.y * Time.deltaTime;
            newCurve.keys[i] = n;
        }

        target.curve = newCurve;        
    }

    private AnimationCurve CopyAnimationCurve(AnimationCurve curve)
    {
        AnimationCurve newCurve = new AnimationCurve();

        newCurve.postWrapMode = curve.postWrapMode;
        newCurve.preWrapMode = curve.preWrapMode;
        newCurve.keys = curve.keys;

        return newCurve;
    }

}
