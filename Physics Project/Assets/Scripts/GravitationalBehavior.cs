using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GravitationalBehavior : MonoBehaviour
{
    [SerializeField] GravitationalManager gravManager;
    public Rigidbody rB;

    // Start is called before the first frame update
    void Awake()
    {
        rB = GetComponent<Rigidbody>();

        if (gravManager != null)
        {
            gravManager.bodies.Add(this);
        }

        if (gameObject.name == "Earth") rB.AddForce(Vector3.left * rB.mass, ForceMode.Impulse);
        if(gameObject.name == "Mars") rB.AddForce(Vector3.right * rB.mass, ForceMode.Impulse);
    }

    private void Update()
    {
        foreach (GravitationalBehavior body in gravManager.bodies.Where(b => b != this))
        {
            var gravitationalIntensity = gravManager.gravitationalConstant * rB.mass * body.rB.mass / (rB.position - body.rB.position).sqrMagnitude;
            rB.AddForce(gravitationalIntensity * (body.rB.position - rB.position).normalized);
        }
    }
}
