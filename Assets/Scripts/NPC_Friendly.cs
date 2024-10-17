using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Represents a friendly NPC that can talk to the player.
/// </summary>
public class NpcFriendly : MonoBehaviour
{
    private const string DEFAULT_SPEECH_TEXT = "Hi there. Look out for that KOBOLD on the other side!";

    /// <summary>
    /// Event triggered when the NPC speaks, passing the speech text.
    /// </summary>
    [SerializeField]
    private UnityEvent<string> _onSpeak = new UnityEvent<string>();
    public UnityEvent<string> OnSpeak => _onSpeak;

    /// <summary>
    /// The audio source used for NPC speech sounds.
    /// </summary>
    [SerializeField]
    private AudioSource _audioSource;

    /// <summary>
    /// The text the NPC will say when talking.
    /// </summary>
    [SerializeField]
    private string _speechText = DEFAULT_SPEECH_TEXT;

    /// <summary>
    /// Triggers the NPC's speech, invoking the OnSpeak event and playing the audio.
    /// </summary>
    public void Talk()
    {
        OnSpeak?.Invoke(_speechText);
        _audioSource.Play();
    }
}
