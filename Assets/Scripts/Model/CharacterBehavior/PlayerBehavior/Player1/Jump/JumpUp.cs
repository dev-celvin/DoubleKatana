using KGCustom.Controller;
using UnityEngine;

namespace KGCustom.Model {
    public class JumpUp : PlayerBehavior<JumpUp>
    {

        public override void init()
        {
            xTransfer = 5;
            yTransfer = 14;
        }

        public override void begin(KGCharacterController cc)
        {
            xTransfer = 5 * Player.instance.moveDragRate;
            JumpFlying.instance.xTransfer = xTransfer;
            JumpAtk4.instance.xTransfer = xTransfer;
            JumpFalling.instance.xTransfer = xTransfer;
            //pc.rigid2D.AddForce(yTransfer * Vector2.up);
        }

        public override void execute(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            if (damageCount(pc)) return;
            float rate = 1.0f - pc.getCurStateInfo().normalizedTime;
            if (rate > 0)
            {
                pc.rigid2D.velocity = Vector2.up * yTransfer * rate;
            }

            pc.transform.Translate(xTransfer * Time.deltaTime * Vector3.right);
            attackableExecute(pc);
        }

        public override void end(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            pc.rigid2D.velocity = Vector2.zero;
        }

    }
}

