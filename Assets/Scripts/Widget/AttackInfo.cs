using KGCustom.Controller;
using UnityEngine;

namespace KGCustom.Model {
    public class AttackInfo : MonoBehaviour
    {

        public AttackEffectController m_AttackEffectController;

        public Attack getHitAttack()
        {
            return m_AttackEffectController.m_curAttack;
        }

        public float getDirection()
        {
            return m_AttackEffectController.transform.localScale.x;
        }

    }
}

