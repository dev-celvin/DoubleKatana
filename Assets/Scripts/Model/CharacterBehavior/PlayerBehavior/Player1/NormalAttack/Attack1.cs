﻿using KGCustom.Controller;

namespace KGCustom.Model {
    public class Attack1 : PlayerBehavior<Attack1>
    {

        public override void begin(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            attackBegin(pc);
        }

        public override void execute(KGCharacterController cc)
        {
            if (damageCount((PlayerController)cc)) return;
            normaAttackExecute((PlayerController)cc);
            base.execute((PlayerController)cc);
        }

    }
}