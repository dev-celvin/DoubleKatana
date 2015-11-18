using KGCustom.Model;
using UnityEngine;

namespace KGCustom.Controller {
    public abstract class AttackEffectController : MonoBehaviour
    {

        public SkeletonAnimation m_SkeletonAnimation;
        public Attack m_curAttack { get; set; }
        public Transform m_Owner { get; set; }

        public abstract void release(KGCharacterController releaser, string animName);
    }

}

