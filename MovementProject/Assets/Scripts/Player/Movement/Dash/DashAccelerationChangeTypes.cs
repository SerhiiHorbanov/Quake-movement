using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DashAccelerationChangeTypes//dash acceleration change types
{
    exponential,//accelerationChange *= value
    linear,//accelerationChange += value
    constant,//accelerationChange = value
}
