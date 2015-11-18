using KGCustom.Model;
using System.Collections.Generic;

namespace KGCustom.Controller {
    public class PikeAttackEffectController : AttackEffectController
    {
        public KGCharacterController test;

        static Dictionary<string, AttackEffect> effectModels = null;

        public static void init()
        {
            //暂时从代码读取数据，将更改为从配置文件读取
            effectModels = new Dictionary<string, AttackEffect>();
            effectModels["atk_1"] = new AttackEffect("atk_1", 5, 2.5f, 0, 0.8793499f, 1.5f);
            effectModels["atk_2"] = new AttackEffect("atk_2", 5, 2.5f, 0.898292f, 0.91f, 1.3f);
            effectModels["atk_3"] = new AttackEffect("atk_3", 5, 2.5f, 0.898292f, 0.91f, 1.1f);
            effectModels["atk_4"] = new AttackEffect("atk_4", 5, 2.5f, 0.898292f, 0.91f);
            effectModels["skill_1"] = new AttackEffect("skill_1", 5, 2.5f, 0.898292f, 0.91f);
            effectModels["skill_2"] = new AttackEffect("skill_2", 5, 2.5f, 0.898292f, 0.91f);
            effectModels["skill_3"] = new AttackEffect("skill_3", 5, 2.5f, 0.898292f, 0.91f);
            effectModels["skill_4"] = new AttackEffect("skill_4", 5, 2.5f, 0.898292f, 0.91f);
            effectModels["skill_5"] = new AttackEffect("skill_5", 5, 2.5f, 0.898292f, 0.91f);
            effectModels["skill_6"] = new AttackEffect("skill_6", 5, 2.5f, 0.898292f, 0.91f);
            effectModels["skill_7"] = new AttackEffect("skill_7", 5, 2.5f, 0.898292f, 0.91f);
            effectModels["skill_8"] = new AttackEffect("skill_8", 50, 2.5f, 0.898292f, 0.91f);
            effectModels["fly_atk_4"] = new AttackEffect("fly_atk_4", 5, 2.5f, 0.898292f, 0.91f);
        }
        // Use this for initialization
        void Start()
        {
            init();
            m_curAttack = new Attack(test, effectModels["skill_7"], transform.localScale.x);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void release(KGCharacterController releaser, string animName)
        {

        }
    }
}

