using KGCustom.Controller;
using UnityEngine;

namespace KGCustom.Model {
    public class Damage : PlayerBehavior<Damage>
    {

        public override void init()
        {
            xTransfer = 5;
            yTransfer = 15;
        }

        public override void execute(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            fallingExecute((PlayerController)pc);
            pc.transform.Translate(-Player.instance.xDirection * xTransfer * Time.deltaTime * Vector3.right);
        }

        public override void begin(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            pc.m_animator.SetBool("Damage", false);
            pc.StopSound();
        }

    }
}
