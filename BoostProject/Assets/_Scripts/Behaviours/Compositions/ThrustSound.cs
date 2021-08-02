using System;
using UnityEngine;
using Behaviours.Interfaces;

namespace Behaviours.Compositions
{
    [Serializable]
    public class ThrustSound : ISound
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioClip _clip;

        public AudioSource Source => _source;
        public AudioClip Clip => _clip;

        public void Play()
        {
            if (!Source.isPlaying)
            {
                Source.clip = Clip;
                Source?.Play();
            }
        }

        public void Stop()
        {
            Source?.Stop();
            Rewind(0f);
        }

        public void Rewind(float time)
        {
            Source.time = time;
        }
    }
}
