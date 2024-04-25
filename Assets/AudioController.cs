using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class AudioController : MonoBehaviour
{
    [SerializeField]
    AudioMixerSnapshot exploring;
    [SerializeField]
    AudioMixerSnapshot battling;
    [SerializeField]
    AudioMixerSnapshot losing;
    [SerializeField]
    AudioSource stingSound;
    [SerializeField]
    AudioSource fallStingSound;

    private float transitionTime = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BattleZone")
        {
            battling.TransitionTo(transitionTime);
            stingSound.Play();
        }

        if (collision.tag == "Outside")
        {
            fallStingSound.Play();
            Text message = GameObject.FindGameObjectWithTag("Message").GetComponent<Text>();
            message.text = "You lost";
            stingSound.Play();
            losing.TransitionTo(stingSound.clip.length);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "BattleZone")
        {
            exploring.TransitionTo(transitionTime);
        }

        if (collision.tag == "Outside")
        {
            exploring.TransitionTo(transitionTime);
        }
    }
}
