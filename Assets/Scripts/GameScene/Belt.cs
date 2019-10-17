using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt : MonoBehaviour
{
    private Animator animator;

    private void Start() => animator = GetComponent<Animator>();

    public void SetAnimationSpeed(float Speed) => animator.SetFloat("Speed", Speed * 0.9f);
}
