using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt : MonoBehaviour
{
    private Animator animator;

    private void Start() => animator = GetComponent<Animator>();

    public void SetAnimationSpeed(bool run) => animator.SetFloat("Speed", run ? 2 : 0);
}
