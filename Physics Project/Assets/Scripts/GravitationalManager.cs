using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GravitationalManager : MonoBehaviour
{
    public float gravitationalConstant = 1f;
    public List<GravitationalBehavior> bodies = new List<GravitationalBehavior>();
}