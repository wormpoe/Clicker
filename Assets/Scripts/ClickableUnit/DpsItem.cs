public class DpsItem
{
    private float _powerMantissa;
    private int _powerExponent;
    private float _tickInterval;
    private bool _isRunning;
    public float TickInterval { get => _tickInterval; }
    public float PowerMantissa { get => _powerMantissa; }
    public int PowerExponent { get => _powerExponent; }
    public bool IsRunning { get => _isRunning; }
    public void Init(float tickInterval)
    {
        _powerMantissa = 0;
        _powerExponent = 0;
        _isRunning = false;
        _tickInterval = tickInterval;
    }
    public void AddPower(float mantissa, int exponent)
    {
        _powerMantissa = mantissa;
        _powerExponent = exponent;
    }
    public void ControlTicking()
    {
        _isRunning = !_isRunning;
    }
}
