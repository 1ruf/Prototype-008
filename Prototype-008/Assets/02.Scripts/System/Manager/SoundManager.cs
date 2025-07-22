using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private float _speedOfSound = 340f;

    private Transform _listeningPlayer;
    private AudioListener _audioListener;

    private void Awake()
    {
        _audioListener = FindAnyObjectByType<AudioListener>();
        _listeningPlayer = _audioListener.transform;
    }
    public void PlayAudio(AudioResource audio, Vector3 playLocation,string name = "Audio")
    {
        GameObject audioObj = new GameObject(name);

        AudioSource targetAS = audioObj.AddComponent<AudioSource>();

        targetAS.resource = audio;

        float time;
        time = CalculateTime(playLocation, _listeningPlayer.position);

        StartCoroutine(AudioDelay(time,targetAS));
        StartCoroutine(AudioDestroy(time + targetAS.clip.length,targetAS));
    }

    private float CalculateTime(Vector3 playLocation, Vector3 listenLocation)
    {
        float distance;
        distance = Vector3.Distance(playLocation, listenLocation);

        return distance / _speedOfSound;
    }

    private IEnumerator AudioDelay(float time, AudioSource source)
    {
        yield return new WaitForSeconds(time);
        source.Play();
    }
    private IEnumerator AudioDestroy(float time, AudioSource source)
    {
        yield return new WaitForSeconds(time);
        Destroy(source.gameObject);
    }
}
