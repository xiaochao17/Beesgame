using UnityEngine;

public class Cooldown
{
    private readonly float _initialSeconds;
    private float _remainingSeconds;

    public Cooldown(float initialSeconds)
    {
        _initialSeconds = initialSeconds;
        _remainingSeconds = 0;
    }

    public void AddRemainingSeconds(float delta)
    {
        _remainingSeconds += delta;
        Mathf.Clamp(_remainingSeconds, 0f, Mathf.Infinity);
    }

    public bool CanUse()
    {
        return _remainingSeconds <= 0f;
    }

    public bool TryUse()
    {
        if (CanUse())
        {
            _remainingSeconds = _initialSeconds;
            return true;
        }
        
        return false;
    }
}