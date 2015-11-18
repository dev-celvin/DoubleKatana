using KGCustom.Controller;
using UnityEngine;

namespace KGCustom.Model {
    public class JumpFalling : PlayerBehavior<JumpFalling>
    {
        public override void init()
        {
            yTransfer = 30;
        }

        public override void execute(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            if (damageCount(pc)) return;
            fallingExecute(pc);
            pc.transform.Translate(xTransfer * Time.deltaTime * Vector3.right);
        }

    }
}
