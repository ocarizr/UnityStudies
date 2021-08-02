using UnityEngine;

namespace Behaviours.Interfaces
{
    public interface ISound
    {
        AudioSource Source { get; }
        AudioClip Clip { get; }
        void Play();
        void Stop();
        void Rewind(float time);
    }
}
