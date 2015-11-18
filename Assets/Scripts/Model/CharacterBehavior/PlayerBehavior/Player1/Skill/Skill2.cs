﻿using KGCustom.Controller;

namespace KGCustom.Model {
    public class Skill2 : PlayerBehavior<Skill2>
    {
        public override void begin(KGCharacterController cc)
        {
            attackBegin((PlayerController)cc);
        }
        public override void init()
        {
            xTransfer = 0.2f;
            yTransfer = 0;
        }
        public override void execute(KGCharacterController cc)
        {
            if (damageCount((PlayerController)cc)) return;
            skillExecute((PlayerController)cc);
            base.execute((PlayerController)cc);
        }

    }
}
