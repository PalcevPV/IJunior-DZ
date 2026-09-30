using UnityEngine;

public class ParticalSystem : MonoBehaviour
{
    [SerializeField] private ParticleSystem _smoke;
    [SerializeField] private ParticleSystem _fire;

    public void Reset()
    {
        _smoke.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        _fire.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

        _smoke.Play();
        _fire.Play();
    }
}
