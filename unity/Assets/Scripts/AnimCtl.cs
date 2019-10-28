using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCtl : MonoBehaviour
{
    private Animator _animator;
    public void stand()
    {
        // Debug.Log("on AnimCtl::stand()");
        _animator.SetInteger("anim", 0);
    }
    void Start()
    {
        // this.transform.Find("Strong Aquaragia break").GetComponent<ParticleSystem>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
