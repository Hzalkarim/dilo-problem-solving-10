using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Charge))]
public class ChargeChanger : MonoBehaviour
{

    public Charge charge;
    public SpriteRenderer spriteRenderer;

    public Color positive;
    public Color negative;

    public int step = 20;
    public float interval = 0.1f;

    private bool isCoroutineOnProgress = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isCoroutineOnProgress) return;

            if (charge.factor > 0)
            {
                StartCoroutine(ChangeCharge(-1));
            }
            else
            {
                StartCoroutine(ChangeCharge(1));
            }
            isCoroutineOnProgress = true;
        }
    }

    public IEnumerator ChangeCharge(int sign)
    {
        var target = Mathf.Abs(charge.factor) * sign;
        var delta = target * 2 / step;

        for (int i = 0; i < step; ++i)
        {
            charge.factor += delta;
            Color newColor = Color.Lerp(
                sign == -1 ? positive : negative,
                sign == -1 ? negative : positive,
                i / (float)step
            );

            spriteRenderer.color = newColor;
            yield return new WaitForSeconds(interval);
        }
        isCoroutineOnProgress = false;
    }
}
