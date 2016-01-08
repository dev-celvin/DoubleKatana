using KGCustom.Controller;
using KGCustom.Controller.CharacterController.EnemyController;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    [TaskCategory("Enemy")]
    [TaskDescription("Returns a TaskStatus of Success if this enemy have a available skill")]
    public class Attack : Action
    {
        public BehaviorTree bt;
        private KGEnemyController ec;
        private Transform m_transform;
        private Transform targetTransform;

        public override void OnStart()
        {
            m_transform = (Transform)bt.GetVariable("MyTransform").GetValue();
            ec = m_transform.GetComponent<KGEnemyController>();
            targetTransform = ControllerManager.instance.m_PlayerController.transform;
        }
        public override TaskStatus OnUpdate()
        {
            AttackEffect ae = ec.character.m_skills.GetRandomAttack(Mathf.Abs(m_transform.position.x - targetTransform.position.x));
            if (ae != null) {
                ec.DoAttack(ae);
                bt.SetVariableValue("OutOfMind", true);
                return TaskStatus.Success;
            }
            return TaskStatus.Failure;
        }

        public override void OnReset()
        {
            m_transform = null;
            targetTransform = null;
            ec = null;
        }
    }
}