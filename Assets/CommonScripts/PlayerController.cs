using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Animator))]
public class PlayerController : Character {

    public float speed;
    public Camera cam;
    public ParticleSystem attackEffect;
    private CharacterController player;
    public float maxMana;
    public float maxDamage;
    public float maxArmor;
    public float mana;
    public float armor;

    protected override void Awake()
    {
        base.Awake();
        player = GetComponent<CharacterController>();
        }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (!isActive) return;
        if (Input.GetMouseButton(0) && !attacking)
        {
            Move(new Vector3());
            Attack();
        }
        else if (!attacking && (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0))
        {
            animator.ResetTrigger("Attack1");
            Vector3 goFront = cam.transform.forward;
            goFront.y = 0;
            goFront = Vector3.Normalize(goFront);
            Vector3 goRight = cam.transform.right;
            goRight.y = 0;
            goRight = Vector3.Normalize(goRight);
            Vector3 moveDir = Vector3.Normalize(goRight * Input.GetAxis("Horizontal") + goFront * Input.GetAxis("Vertical"));
            Move(speed * moveDir);
        }
        else
        {
            Move(new Vector3());
        }

    }

    void Move(Vector3 velocity)
    {
        player.transform.forward =Vector3.Lerp(velocity, player.transform.forward,2.0f*Time.deltaTime);
        player.SimpleMove(velocity);
    }

    protected override void Attack()
    {
        if(target != null) TurnToTarget();
        base.Attack();
    }



    protected override void AnimMove(float speed)
    {
        base.AnimMove(speed);
        animator.SetFloat("Speed",speed);
    }

    protected override void AnimAttack()
    {
        base.AnimAttack();
        animator.SetTrigger("Attack1");
        attackEffect.Play();
    }

    protected override void AnimDie()
    {
        base.AnimDie();
        animator.SetTrigger("Death");
    }
    

}
