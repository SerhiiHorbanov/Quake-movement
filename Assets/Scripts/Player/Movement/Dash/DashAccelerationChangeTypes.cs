namespace Player.Movement.Dash
{
    public enum DashAccelerationChangeTypes//dash acceleration change types
    {
        exponential,//accelerationChange *= value
        linear,//accelerationChange += value
        constant,//accelerationChange = value
    }
}
