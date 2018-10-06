using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : AiCharacter
{

    protected override void AnimAttack()
    {
        base.AnimAttack();
        animator.SetTrigger("Attack");
    }

    protected override void AnimDie()
    {
        base.AnimDie();
        animator.SetTrigger("Death");
    }


    protected override void AnimMove(float speed)
    {
        base.AnimMove(speed);
        animator.SetFloat("Speed", speed);
    }
}
