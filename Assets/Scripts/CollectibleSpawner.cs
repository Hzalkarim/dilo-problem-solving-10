using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CollectibleSpawner : MonoBehaviour
{
    public PositionConstraint collectiblePrefab;

    public void OnBoxSpawned(Transform box)
    {
        var go = Instantiate(collectiblePrefab, transform);

        var cs = new ConstraintSource();
        cs.sourceTransform = box;
        cs.weight = 1;

        go.SetSource(0, cs);
        go.constraintActive = true;
    }
}
