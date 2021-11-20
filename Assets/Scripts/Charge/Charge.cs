using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ConstantForce2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Charge : MonoBehaviour
{
    private CircleCollider2D collider;
    private ConstantForce2D force2D;


    public float factor = 5f;
    public bool isEffected = true;
    public float maxFactorInteraction = 100f;
    public float Radius
    {
        get
        {
            return collider.radius;
        }
        set
        {
            collider.radius = value;
        }
    }
    public List<Charge> charges = new List<Charge>();


    private void Awake()
    {
        collider = GetComponent<CircleCollider2D>();
        force2D = GetComponent<ConstantForce2D>();
    }

    private void FixedUpdate()
    {
        if (!isEffected) return;

        if (charges.Count > 0 && charges.Any(i => i == null))
        {
            for (int i = charges.Count - 1; i >= 0; --i)
            {
                if (charges[i] == null)
                    charges.RemoveAt(i);
            }
        }

        if (charges.Count > 0)
        {
            var force = 
                charges.Select(i =>
                {
                    var dis = Vector3.Distance(transform.position, i.transform.position);
                    float interactionF = GetInteraction(factor, i.factor, dis);

                    var dir = (transform.position - i.transform.position).normalized * interactionF;
                    Vector3 force = new Vector3(dir.x, dir.y);

                    return dir;
                }).Aggregate((i, j) => i + j);

            force2D.force = new Vector2(force.x, force.y);
        }
        else if (force2D.force.magnitude != 0)
        {
            force2D.force = GetDissipatedForce(force2D.force);
        }
    }

    private Vector2 GetDissipatedForce(Vector2 force)
    {
        if (force.magnitude < .2f)
        {
            return Vector2.zero;
        }
        else
        {
            return force * .8f;
        }
    }

    private float GetInteraction(float firstFactor, float secondFactor, float dis)
    {
        return Mathf.Clamp((firstFactor * secondFactor) / Mathf.Pow(dis, 2), -maxFactorInteraction, maxFactorInteraction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var charge = collision?.GetComponent<Charge>();
        if (charge != null)
        {
            charges.Add(charge);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var charge = collision?.GetComponent<Charge>();
        if (charge != null)
        {
            charges.Remove(charge);
        }
    }
}
