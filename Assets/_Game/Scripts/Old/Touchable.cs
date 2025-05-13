using UnityEngine;
using UnityEngine.Events;

public class Touchable : MonoBehaviour
{
    [SerializeField] private ParticleSystem _touchParticlePrefab;
    [SerializeField] private AudioClip _touchSound;
    public UnityEvent Touched;

    public void Touch()
    {
        //play sound
        if (_touchSound)
            AudioSource.PlayClipAtPoint
                (_touchSound, Camera.main.transform.position);
        // play particle
       if (_touchParticlePrefab)
                Instantiate(_touchParticlePrefab,
                    transform.position, Quaternion.identity);
       Touched?.Invoke();
    }
}
