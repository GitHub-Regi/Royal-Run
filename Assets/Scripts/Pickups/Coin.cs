using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : Pickup
{
    [SerializeField] AudioClip coinPickupSound;
    [SerializeField] int scoreAmount;

    AudioSource ads;
    ScoreManager scoreManager;

    void Start()
    {
        ads = GetComponent<AudioSource>();
    }

    public void Init(ScoreManager scoreManager)
    {
        this.scoreManager = scoreManager;
    }


    protected override void OnPickup()
    {
        AudioSource.PlayClipAtPoint(coinPickupSound, transform.position, 0.1f);

        GetComponent<Collider>().enabled = false; 
        GetComponentInChildren<MeshRenderer>().enabled = false; 

        scoreManager.IncreaseScore(scoreAmount);
    }

    protected override float GetDestructionDelay()
    {
        return coinPickupSound.length;
    }

}
