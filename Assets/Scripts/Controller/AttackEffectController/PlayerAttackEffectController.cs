using UnityEngine;
using System.Collections.Generic;
using KGCustom.Model;
using System;

namespace KGCustom.Controller {
    public class PlayerAttackEffectController : AttackEffectController
    {

        static Dictionary<string, AttackEffect> effectModels = null;
        bool playCheck = false;

        public static void init()
        {
            //暂时从代码读取数据，将更改为从配置文件读取
            effectModels = new Dictionary<string, AttackEffect>();
            effectModels["atk_1"] = new AttackEffect("atk_1", 5, 2.5f, 0, 0.8793499f, 10, 1, 1.5f);
            effectModels["atk_2"] = new AttackEffect("atk_2", 5, 2.5f, 0.898292f, 0.91f, 10, 1, 1.3f);
            effectModels["atk_3"] = new AttackEffect("atk_3", 5, 2.5f, 0.898292f, 0.91f, 10, 1, 1.1f);
            effectModels["atk_4"] = new AttackEffect("atk_4", 5, 2.5f, 0.898292f, 0.91f);
            effectModels["skill_1"] = new AttackEffect("skill_1", 5, 2.5f, 0.898292f, 0.91f);
            effectModels["skill_2"] = new AttackEffect("skill_2", 5, 2.5f, 0.898292f, 0.91f);
            effectModels["skill_3"] = new AttackEffect("skill_3", 5, 2.5f, 0.898292f, 0.91f);
            effectModels["skill_4"] = new AttackEffect("skill_4", 5, 2.5f, 0.898292f, 0.91f);
            effectModels["skill_5"] = new AttackEffect("skill_5", 5, 2.5f, 0.898292f, 0.91f);
            effectModels["skill_6"] = new AttackEffect("skill_6", 5, 2.5f, 0.898292f, 0.91f);
            effectModels["skill_7"] = new AttackEffect("skill_7", 5, 2.5f, 0.898292f, 0.91f);
            effectModels["skill_8"] = new AttackEffect("skill_8", 5, 2.5f, 0.898292f, 0.91f);
            effectModels["fly_atk_4"] = new AttackEffect("fly_atk_4", 5, 2.5f, 0.898292f, 0.91f);
            effectModels["fan"] = new AttackEffect("fan", 0, 0, 0, 0);
        }
        // Update is called once per frame
        void Update()
        {
            if (m_SkeletonAnimation.state.GetCurrent(0).time >= m_SkeletonAnimation.state.GetCurrent(0).endTime)
            {
                GameObject.Destroy(gameObject);
            }
            else
            {
                GetComponent<MeshRenderer>().enabled = true;
                if (!playCheck && Player.instance.curState is Damage)
                {
                    playCheck = true;
                    switch (m_SkeletonAnimation.AnimationName)
                    {
                        //case "skill_2":
                        //    if (m_SkeletonAnimation.state.GetCurrent(0).time < 0.25f) GameObject.Destroy(gameObject);
                        //    break;
                        //case "skill_5":
                        //    if (m_SkeletonAnimation.state.GetCurrent(0).time < 0.8f) GameObject.Destroy(gameObject);
                        //    break;
                        default:
                            GameObject.Destroy(gameObject);
                            break;
                    }
                }
            }
        }

        public override void release(KGCharacterController releaser, string animName)
        {
            m_SkeletonAnimation.AnimationName = animName;
            m_SkeletonAnimation.timeScale = effectModels[animName].timeScale;
            transform.localScale = new Vector3(Player.instance.xDirection, 1, 1);
            m_curAttack = new Attack(releaser, effectModels[animName], Player.instance.xDirection);
        }

        public static float getSkillCost(string skillName) {
            return effectModels[skillName].costMP;
        }

        public static float getSkillReadyTime(string skillName) {
            AttackEffect ae = effectModels[skillName];
            return (Time.time - ae.lastUsedTime < ae.cd && ae.lastUsedTime != 0) ? (ae.cd + ae.lastUsedTime - Time.time) : 0;
        }

        public static void cdReverse(string skillName)
        {
            effectModels[skillName].lastUsedTime = Time.time;
        }
		public static float getNextSkillReadyTime() {
			int num = PlayerAttack.instance.skillAction[PlayerAttack.instance.skillIndex];
			if (num < 100) return 1;
			else
			{
				AttackEffect ae = effectModels["skill_" + Convert.ToString(num % 100)];
				if (Time.time - ae.lastUsedTime < ae.cd && ae.lastUsedTime != 0) return (Time.time - ae.lastUsedTime) / ae.cd;
				else return 1;
			}
		}
    }
}

