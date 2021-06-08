using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Script
{
    public class Option : MonoBehaviour
    {
        public AudioMixer audioMixer;
        public AudioSource audioSource;
        public float musicVolume = 1f;
        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            if (PlayerPrefs.HasKey("AudioSource"))
            {

                musicVolume = PlayerPrefs.GetInt("AudioSource");

            }

            if (PlayerPrefs.HasKey("Pause"))
            {
                if (PlayerPrefs.GetInt("Pause") == 0)
                {
                    AudioListener.pause = true;
                }
                if (PlayerPrefs.GetInt("Pause") == 1)
                {
                    AudioListener.pause = false;
                }
            }

            if (PlayerPrefs.HasKey("Quality"))
            {
                QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"));
            }

        }
        private void Update()
        {
            audioSource.volume = musicVolume;

        }
        public void SetVoluem(float volume)
        {
            musicVolume = volume;
            PlayerPrefs.SetFloat("AudioSource", musicVolume);
        }


        public void SetQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
            PlayerPrefs.SetInt("Quality", qualityIndex);
        }

        public void Sound()
        {
            AudioListener.pause = !AudioListener.pause;
            if (AudioListener.pause == true)
            {
                PlayerPrefs.SetInt("Pause", 0);
            }
            else
            {
                PlayerPrefs.SetInt("Pause", 1);
            }
        }
    }
}
