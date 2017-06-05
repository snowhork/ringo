using UnityEngine;

namespace Script.Maps
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        public void Play(AudioClip clip)
        {
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }
}
