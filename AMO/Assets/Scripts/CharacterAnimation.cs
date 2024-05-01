using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetAnimationCondition(string conditionName, bool value)
    {
        animator.SetBool(conditionName, value);
    }

    public void SetAnimationCondition(string conditionName, float value)
    {
        animator.SetFloat(conditionName, value);
    }

    public void SetAnimationCondition(string conditionName, int value)
    {
        animator.SetInteger(conditionName, value);
    }

    public void SetAnimationCondition(string conditionName)
    {
        animator.SetTrigger(conditionName);
    }
}
