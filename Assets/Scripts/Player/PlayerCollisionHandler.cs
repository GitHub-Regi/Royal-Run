using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float hitCooldown;
    [SerializeField] float adjustChangeMoveSpeedAmount;

    LevelGenerator levelGenerator;

    float cooldownTimer = 0f;
    const string hitString = "Hit";

    void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (cooldownTimer < hitCooldown) return;

        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);

        animator.SetTrigger(hitString);

        cooldownTimer = 0;
    }
}
