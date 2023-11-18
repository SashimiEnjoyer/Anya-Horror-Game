using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class VendingMachingeInteractable : InteractableItems
{
    [SerializeField] private AudioSource audioPlayer;
    [SerializeField] private AudioClip haveWallet;
    [SerializeField] private AudioClip noWallet;

    private void Awake()
    {
        if(audioPlayer == null)
            audioPlayer = GetComponent<AudioSource>();
    }

    public override void Execute()
    {
        if (InGameStatus.myProgressTracker.walletTaken)
        {
            onInteractEvent?.Invoke();
            PlayClip(haveWallet);
        }
        else
        {
            onFalseConditionEvent?.Invoke();
            PlayClip(noWallet);
        }
    }

    private void PlayClip(AudioClip clip)
    {
        if (clip == null)
            return;

        audioPlayer.PlayOneShot(clip);
    }
}
