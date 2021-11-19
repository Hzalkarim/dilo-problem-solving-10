using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Collectibles : MonoBehaviour
{
    public PositionConstraint posConstraint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var coll = collision.gameObject.GetComponent<Collector>();
        if (coll != null)
        {
            Destroy(posConstraint.GetSource(0).sourceTransform.gameObject);
            Destroy(gameObject);
            coll.OnCollect();
        }
    }
}
