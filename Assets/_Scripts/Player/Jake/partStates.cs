﻿using UnityEngine;
using System.Collections;

public class half_movement : State {

    partController pc;
    Rigidbody2D rb;
    float x_input;

    public half_movement(partController pc) {
        this.pc = pc;
    }

    public override void OnStart() {
        rb = pc.part.GetComponent<Rigidbody2D>();
    }

    public override void OnUpdate(float time_delta_fraction) {
        x_input = Input.GetAxis("L_XAxis_" + pc.playerNum.ToString());
        rb.velocity = new Vector3(x_input * pc.moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("A_" + pc.playerNum.ToString()) && pc.grounded) {
            //Jump
            pc.grounded = false;
            rb.AddForce(Vector2.up * pc.jumpForce);
        }

        if (Input.GetButtonDown("B_" + pc.playerNum.ToString())) {
            //Attack
            Debug.Log("Player " + pc.playerNum.ToString() + " Attacking");
        }
    }
}

public class full_movement : State {

    partController pc;
    partController bottompc;
    partController toppc;
    Rigidbody2D rb;
    float x_input;

    public full_movement(partController pc, partController toppc, partController bottompc) {
        this.pc = pc;
        this.toppc = toppc;
        this.bottompc = bottompc;
    }

    public override void OnStart() {
        rb = pc.part.GetComponent<Rigidbody2D>();
    }

    public override void OnUpdate(float time_delta_fraction) {
        x_input = Input.GetAxis("L_XAxis_" + bottompc.playerNum.ToString());
        rb.velocity = new Vector3(x_input * pc.moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("A_" + bottompc.playerNum.ToString()) && pc.grounded) {
            //Jump
            pc.grounded = false;
            rb.AddForce(Vector2.up * pc.jumpForce);
        }

        if (Input.GetButtonDown("B_" + toppc.playerNum.ToString())) {
            //Attack
            Debug.Log("Together Attacking");
        }
    }

    public override void OnFinish() {
        
    }
}

public class inactive : State {

    partController pc;

    public inactive(partController pc) {
        this.pc = pc;
    }

    public override void OnStart() {
        pc.part.SetActive(false);
    }

    public override void OnFinish() {
        pc.part.SetActive(true);
    }
}