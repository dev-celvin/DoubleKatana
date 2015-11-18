using KGCustom.Controller;
using UnityEngine;

namespace KGCustom.Model {
    public class JumpFlying : PlayerBehavior<JumpFlying>
    {
        public override void init()
        {
            xTransfer = 10;
        }

        public override void execute(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            if (damageCount(pc)) return;
            attackableExecute(pc);
            pc.transform.Translate(xTransfer * Time.deltaTime * Vector3.right);
        }

    }
}
