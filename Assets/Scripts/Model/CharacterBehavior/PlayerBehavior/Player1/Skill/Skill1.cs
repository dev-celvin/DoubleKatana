﻿using KGCustom.Controller;

namespace KGCustom.Model {
    public class Skill1 : PlayerBehavior<Skill1>
    {
        public override void begin(KGCharacterController cc)
        {
            attackBegin((PlayerController)cc);
        }

        public override void execute(KGCharacterController cc)
        {
            if (damageCount((PlayerController)cc)) return;
            skillExecute((PlayerController)cc);
            base.execute((PlayerController)cc);
        }

    }
}
