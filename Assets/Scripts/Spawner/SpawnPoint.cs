using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private bool _isBusy = false;

    public bool IsBusy => _isBusy;

    public void Enable()
    {
        _isBusy = true;
    }

    public void Disable()
    {
        _isBusy = false;
    }
}