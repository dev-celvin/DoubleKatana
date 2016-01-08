using KGCustom.Controller;
using KGCustom.Controller.CharacterController.EnemyController;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    [TaskCategory("Enemy")]
    [TaskDescription("Returns a TaskStatus of Success if this enemy can move")]
    public class LookAtPlayer : Action
    {
        public BehaviorTree bt;
        private KGEnemyController ec;

        public override void OnStart()
        {
            ec = ((Transform)bt.GetVariable("MyTransform").GetValue()).GetComponent<KGEnemyController>();
        }
        public override TaskStatus OnUpdate()
        {
            if (ec.transform.position.x > PlayerController.instance.transform.position.x)
            {
                ec.character.xDirection = Global.GlobalValue.XDIRECTION_LEFT;
            }
            else if (ec.transform.position.x < PlayerController.instance.transform.position.x)
            {
                ec.character.xDirection = Global.GlobalValue.XDIRECTION_RIGHT;
            }
            ec.transform.localScale = Vector3.right * -ec.character.xDirection + Vector3.one - Vector3.right;
            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            ec = null;
        }
    }
}