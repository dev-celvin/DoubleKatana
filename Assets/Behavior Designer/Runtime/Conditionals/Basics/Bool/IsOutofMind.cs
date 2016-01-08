using KGCustom.Controller.CharacterController.EnemyController;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityString
{
    [TaskCategory("Basic/Bool")]
    [TaskDescription("Returns success if the enemy is out of mind")]
    public class IsOutOfMind : Conditional
    {
        public BehaviorTree bt;
        private KGEnemyController ec;

        public override void OnStart()
        {
            ec = ((Transform)bt.GetVariable("MyTransform").GetValue()).GetComponent<KGEnemyController>();
        }
        public override TaskStatus OnUpdate()
        {
            if (ec.character.curState == null) return TaskStatus.Failure;
            switch (ec.character.curState.behaviorType) {
                case CharacterBehavior.BehaviorType.Attack:
                    return TaskStatus.Success;
                case CharacterBehavior.BehaviorType.Damage:
                    return TaskStatus.Success;
                case CharacterBehavior.BehaviorType.Defence:
                    return TaskStatus.Success;
            }
            return TaskStatus.Failure;
        }

        public override void OnReset()
        {
            ec = null;
        }
    }
}