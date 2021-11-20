using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeRandomizer : MonoBehaviour
{
    public Vector2 factorRange;
    public Vector2 effectRadiusRange;

    [Space]
    public Color Positive;
    public Color Negative;
    public void OnBoxSpawned(Charge charge)
    {
        var factor = Random.Range(factorRange.x, factorRange.y);
        var radius = Random.Range(effectRadiusRange.x, effectRadiusRange.y);

        charge.factor = factor;
        charge.Radius = radius;

        var spriteRenderer = charge.GetComponent<SpriteRenderer>();
        if (factor >= 0)
        {
            spriteRenderer.color = Positive;
        }
        else
        {
            spriteRenderer.color = Negative;
        }
    }
}
