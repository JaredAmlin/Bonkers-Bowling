using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item.asset", menuName = "Pin Positions")]
public class PinPositions : ScriptableObject
{
    public Vector3[] positions;
}
