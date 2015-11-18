using UnityEngine;
using KGCustom.Controller;
using KGCustom.Model;

namespace KGCustom.Controller {
    public class DamageColliderController : MonoBehaviour
    {
        public KGCharacterController characterController;
        void OnCollisionEnter2D(Collision2D collision2d)
        {
            Attack hitAttack = collision2d.gameObject.GetComponent<AttackInfo>().getHitAttack();
            if (!characterController.hitAttacks.Contains(hitAttack))
            {
                hitAttack.hitPos = collision2d.contacts[0].point;
                characterController.hitAttacks.Push(hitAttack);
            }
        }
    }
}

