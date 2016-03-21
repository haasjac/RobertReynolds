using UnityEngine;
using System.Collections;

public class Together : State  {

    playerController pc;

    public Together(playerController pc) {
        this.pc = pc;
    }

    public override void OnStart() {
        Vector3 pos = pc.bottomController.part.transform.position - pc.bottomController.transform.position;
        pc.fullController.part.transform.position = pos + pc.fullController.transform.position;

        pc.topController.control_state_machine.ChangeState(new inactive(pc.topController));
        pc.bottomController.control_state_machine.ChangeState(new inactive(pc.bottomController));
        pc.fullController.control_state_machine.ChangeState(new full_movement(pc.fullController, pc.topController, pc.bottomController));
        pc.pState = playerState.TOGETEHER;
    }

}

public class Apart : State {

    playerController pc;

    public Apart(playerController pc) {
        this.pc = pc;
    }

    public override void OnStart() {
        Vector3 pos = pc.fullController.part.transform.position - pc.fullController.transform.position;

        pc.topController.part.transform.position = pos + pc.topController.transform.position;
        pc.bottomController.part.transform.position = pos + pc.bottomController.transform.position;

        pc.topController.control_state_machine.ChangeState(new half_movement(pc.topController));
        pc.bottomController.control_state_machine.ChangeState(new half_movement(pc.bottomController));
        pc.fullController.control_state_machine.ChangeState(new inactive(pc.fullController));
        pc.pState = playerState.APART;
    }

}
