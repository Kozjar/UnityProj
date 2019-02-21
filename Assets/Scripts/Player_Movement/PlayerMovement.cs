﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    private Animation anim;
    private InteractionTrigger trigger;

	void Start () {
        trigger = GetComponent<InteractionTrigger>();
        //animator = GetComponent<Animator>();
        anim = GetComponent<Animation>();
	}

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            trigger.lightAngle = 90;
            //anim.Play("Down_0");
            //gameObject.GetComponent<Animation>().Play();
            PlayerState.instance.LookAt(PlayerState.look.up);
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + PlayerState.instance.viewDirection, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            trigger.lightAngle = 270;

            PlayerState.instance.LookAt(PlayerState.look.down);
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + PlayerState.instance.viewDirection, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            trigger.lightAngle = 0;

            PlayerState.instance.LookAt(PlayerState.look.right);
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + PlayerState.instance.viewDirection, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            trigger.lightAngle = 180;

            PlayerState.instance.LookAt(PlayerState.look.left);
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + PlayerState.instance.viewDirection, speed * Time.deltaTime);
        }
    }

}
