using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "ExplodeValueSO", menuName = "SO/System/ExplodeValueSO")]
public class ExplodeValueSO : ScriptableObject
{
    public float Radius;
    public float Pressure;

    public AudioResource ExplosionAudio;
}
