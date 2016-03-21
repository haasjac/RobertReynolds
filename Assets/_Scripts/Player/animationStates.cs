﻿using UnityEngine;
using System.Collections;

// A State that takes a renderer and a sprite, and implements idling behavior.
// The state is capable of transitioning to a walking state upon key press.
public class StateIdleWithSprite : State {
    partController pc;
    SpriteRenderer renderer;
    Sprite sprite;

    public StateIdleWithSprite(partController pc, SpriteRenderer renderer, Sprite sprite) {
        this.pc = pc;
        this.renderer = renderer;
        this.sprite = sprite;
    }

    public override void OnStart() {
        renderer.sprite = sprite;
    }

    public override void OnUpdate(float time_delta_fraction) {
        if (pc.current_state == EntityState.ATTACKING)
            return;
        // Transition to walking animations on key press.
        if (pc.tag == "Bottom" || pc.tag == "Whole") {
            if (Input.GetKeyDown(KeyCode.DownArrow))
                state_machine.ChangeState(new StatePlayAnimationForHeldKey(pc, renderer, pc.crouch, 20, KeyCode.DownArrow));
            if (Input.GetKeyDown(KeyCode.UpArrow))
                state_machine.ChangeState(new StatePlayAnimationForHeldKey(pc, renderer, pc.jump, 20, KeyCode.UpArrow));
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                state_machine.ChangeState(new StatePlayAnimationForHeldKey(pc, renderer, pc.runRight, 20, KeyCode.RightArrow));
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                state_machine.ChangeState(new StatePlayAnimationForHeldKey(pc, renderer, pc.runRight, 20, KeyCode.LeftArrow));
        } else {
            if (Input.GetKeyDown(KeyCode.S))
                state_machine.ChangeState(new StatePlayAnimationForHeldKey(pc, renderer, pc.crouch, 20, KeyCode.DownArrow));
            if (Input.GetKeyDown(KeyCode.W))
                state_machine.ChangeState(new StatePlayAnimationForHeldKey(pc, renderer, pc.jump, 20, KeyCode.UpArrow));
            if (Input.GetKeyDown(KeyCode.D)) {
                state_machine.ChangeState(new StatePlayAnimationForHeldKey(pc, renderer, pc.runRight, 20, KeyCode.RightArrow));
            }
            if (Input.GetKeyDown(KeyCode.A))
                state_machine.ChangeState(new StatePlayAnimationForHeldKey(pc, renderer, pc.runRight, 20, KeyCode.LeftArrow));

        }
    }
}

// A State for playing an animation until a particular key is released.
// Good for animations such as walking.
public class StatePlayAnimationForHeldKey : State {
    partController pc;
    SpriteRenderer renderer;
    KeyCode key;
    Sprite[] animation;
    int animation_length;
    float animation_progression;
    float animation_start_time;
    int fps;

    public StatePlayAnimationForHeldKey(partController pc, SpriteRenderer renderer, Sprite[] animation, int fps, KeyCode key) {
        this.pc = pc;
        this.renderer = renderer;
        this.key = key;
        this.animation = animation;
        this.animation_length = animation.Length;
        this.fps = fps;

        if (this.animation_length <= 0)
            Debug.LogError("Empty animation submitted to state machine!");
    }

    public override void OnStart() {
        animation_start_time = Time.time;
        if (key == KeyCode.LeftArrow) {
            pc.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        } else if (key == KeyCode.RightArrow) {
            pc.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    public override void OnUpdate(float time_delta_fraction) {
        if (pc.current_state == EntityState.ATTACKING)
            return;

        if (this.animation_length <= 0) {
            Debug.LogError("Empty animation submitted to state machine!");
            return;
        }

        // Modulus is necessary so we don't overshoot the length of the animation.
        int current_frame_index = ((int)((Time.time - animation_start_time) / (1.0 / fps)) % animation_length);
        renderer.sprite = animation[current_frame_index];

        // If another key is pressed, we need to transition to a different walking animation.
        if (pc.tag == "Bottom" || pc.tag == "Whole") {
            if (Input.GetKeyDown(KeyCode.DownArrow))
                state_machine.ChangeState(new StatePlayAnimationForHeldKey(pc, renderer, pc.crouch, 20, KeyCode.DownArrow));
            if (Input.GetKeyDown(KeyCode.UpArrow))
                state_machine.ChangeState(new StatePlayAnimationForHeldKey(pc, renderer, pc.jump, 20, KeyCode.UpArrow));
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                state_machine.ChangeState(new StatePlayAnimationForHeldKey(pc, renderer, pc.runRight, 20, KeyCode.RightArrow));
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                state_machine.ChangeState(new StatePlayAnimationForHeldKey(pc, renderer, pc.runRight, 20, KeyCode.LeftArrow));

            // If we detect the specified key has been released, return to the idle state.
            else if (!Input.GetKey(key))
                state_machine.ChangeState(new StateIdleWithSprite(pc, renderer, animation[0]));
        } else {
            if (Input.GetKeyDown(KeyCode.S))
                state_machine.ChangeState(new StatePlayAnimationForHeldKey(pc, renderer, pc.crouch, 20, KeyCode.DownArrow));
            if (Input.GetKeyDown(KeyCode.W))
                state_machine.ChangeState(new StatePlayAnimationForHeldKey(pc, renderer, pc.jump, 20, KeyCode.UpArrow));
            if (Input.GetKeyDown(KeyCode.D)) {
                state_machine.ChangeState(new StatePlayAnimationForHeldKey(pc, renderer, pc.runRight, 20, KeyCode.RightArrow));
            }
            if (Input.GetKeyDown(KeyCode.A))
                state_machine.ChangeState(new StatePlayAnimationForHeldKey(pc, renderer, pc.runRight, 20, KeyCode.LeftArrow));

            // If we detect the specified key has been released, return to the idle state.
            else if (!Input.GetKey(key))
                state_machine.ChangeState(new StateIdleWithSprite(pc, renderer, animation[0]));
        }
    }
}