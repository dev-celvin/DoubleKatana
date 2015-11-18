using KGCustom.Controller;
using UnityEngine;

namespace KGCustom.Model {
    public class RunAttack : PlayerBehavior<RunAttack>
    {
        public override void init()
        {
            xTransfer = 5;
        }
        public override void begin(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            pc.skeletonGhost.ghostingEnabled = true;
            xTransfer = 5 * Player.instance.xDirection;
        }

        public override void execute(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            if (damageCount(pc)) return;
            pc.transform.Translate(xTransfer * Time.deltaTime * Vector3.right);
            pc.transform.parent.position -= pc.transform.parent.position.y * Vector3.up;
        }

        public override void end(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            base.end(pc);
            pc.skeletonGhost.ghostingEnabled = false;
        }

    }
}
