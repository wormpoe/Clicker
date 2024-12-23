using UnityEngine;

public class SpawnPositionSignal
{
    public readonly Vector3 Position;
    public readonly float ClickPower;
    public readonly int Exponetn;

    public SpawnPositionSignal(Vector3 position, float clickPower, int exponetn)
    {
        Position = position;
        ClickPower = clickPower;
        Exponetn = exponetn;
    }
}
