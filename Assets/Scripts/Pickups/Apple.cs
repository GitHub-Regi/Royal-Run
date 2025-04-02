using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] AudioClip applePickupSound;
    [SerializeField] float adjustChangeMoveSpeedAmount;
    
    AudioSource ads;
    LevelGenerator levelGenerator;

    void Start()
    {
        ads = GetComponent<AudioSource>();
    }

    public void Init(LevelGenerator levelGenerator)
    {
        this.levelGenerator = levelGenerator;
    }

    protected override void OnPickup()
    {
        AudioSource.PlayClipAtPoint(applePickupSound, transform.position, 0.2f);

        GetComponent<Collider>().enabled = false; 
        GetComponentInChildren<MeshRenderer>().enabled = false; 

        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
    }
}
