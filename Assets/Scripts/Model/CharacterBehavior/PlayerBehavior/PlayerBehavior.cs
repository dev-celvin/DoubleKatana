﻿using KGCustom.Controller;
using KGCustom.Model;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior<T> : CharacterBehavior where T : PlayerBehavior<T>, new()
{
    public  AnimationCurve animCurve = null;
    protected float startTime;
    protected void attackBegin(PlayerController pc)
    {
        startTime = Time.time;
        if (startTime == PlayerAttack.instance.chagneComboTime) pc.m_animator.SetBool("IsOver", true);
        else PlayerAttack.instance.chagneComboTime = -1;
        GameObject atkEffect = (GameObject)GameObject.Instantiate(pc.m_AttackEffect, pc.transform.position, pc.m_AttackEffect.transform.rotation);
        atkEffect.GetComponent<PlayerAttackEffectController>().release(pc, pc.curState);
        atkEffect.GetComponent<PlayerAttackEffectController>().m_Owner = pc.transform;
        if (Player.instance.curState is Skill7)atkEffect.transform.parent = pc.transform.parent;
        else atkEffect.transform.parent = pc.transform;
        pc.m_animator.SetInteger("AttackAction", 0);
        pc.m_animator.SetInteger("SkillAction", 0);
        PlayerAttack.instance.combo = false;
    }


    protected void skillCombo(PlayerController pc)
    {
#if UNITY_STANDALONE_WIN
        if (Input.GetKeyDown(KeyCode.L))
        {
            int sIndex = PlayerAttack.instance.skillAction[PlayerAttack.instance.skillIndex];
            PlayerAttack.instance.normalIndex = 0;
            if (sIndex < 100)
            {   
                pc.m_animator.SetInteger("SkillAction", 0);
                pc.m_animator.SetInteger("AttackAction", sIndex);
            }

            else {
                if (!releaseSkillCount(sIndex % 100)) {
                    pc.m_animator.SetBool("IsOver", true);
                    return;
                }
                pc.m_animator.SetInteger("AttackAction", 0);
                pc.m_animator.SetInteger("SkillAction", sIndex % 100);
            }
            PlayerAttack.instance.skillIndex = (PlayerAttack.instance.skillIndex + 1) % PlayerAttack.instance.skillAction.Count;
            PlayerAttack.instance.combo = true;
        }
#else
		if (KeyManager.instance.GetKeyMessageDown(KeyManager.KeyCode.Combo))
           {
            int sIndex = PlayerAttack.instance.skillAction[PlayerAttack.instance.skillIndex];
            PlayerAttack.instance.normalIndex = 0;
            if (sIndex < 100)
            {   
                pc.m_animator.SetInteger("SkillAction", 0);
                pc.m_animator.SetInteger("AttackAction", sIndex);
            }

            else {
                if (!releaseSkillCount(sIndex % 100)) {
                    pc.m_animator.SetBool("IsOver", true);
                    return;
                }
                pc.m_animator.SetInteger("AttackAction", 0);
                pc.m_animator.SetInteger("SkillAction", sIndex % 100);
            }
            PlayerAttack.instance.skillIndex = (PlayerAttack.instance.skillIndex + 1) % PlayerAttack.instance.skillAction.Count;
            PlayerAttack.instance.combo = true;
           }
#endif
        pc.m_animator.SetBool("IsOver", true);
    }

    protected void normalCombo(PlayerController pc)
    {
#if UNITY_STANDALONE_WIN
        if (Input.GetKeyUp(KeyCode.K))
        {
            pc.m_animator.SetInteger("SkillAction", 0);
            pc.m_animator.SetInteger("AttackAction", PlayerAttack.instance.normalAction[PlayerAttack.instance.normalIndex]);
            PlayerAttack.instance.normalIndex = (PlayerAttack.instance.normalIndex + 1) % PlayerAttack.instance.normalAction.Count;
            PlayerAttack.instance.combo = true;
        }
#else
		if (KeyManager.instance.GetKeyMessageUp(KeyManager.KeyCode.Attack))
           {
                pc.m_animator.SetInteger("SkillAction", 0);
                pc.m_animator.SetInteger("AttackAction", PlayerAttack.instance.normalAction[PlayerAttack.instance.normalIndex]);
                PlayerAttack.instance.normalIndex = (PlayerAttack.instance.normalIndex + 1) % PlayerAttack.instance.normalAction.Count;
                PlayerAttack.instance.combo = true;
           }
#endif
        pc.m_animator.SetBool("IsOver", true);
    }

    public override void end(KGCharacterController pc)
    {
        
    }

    protected void nextToAttackExecute(PlayerController pc)
    {
#if UNITY_STANDALONE_WIN

        if (Input.GetKeyDown(KeyCode.H))
        {
            pc.m_animator.SetTrigger("Fan");
        }

#else
        if (KeyManager.instance.GetKeyMessageDown(KeyManager.KeyCode.Hitback))
        {
            pc.m_animator.SetTrigger("Fan");
        }
#endif
#if UNITY_STANDALONE_WIN
        if (Input.GetKeyDown(KeyCode.L))
        {
            int sIndex = PlayerAttack.instance.skillAction[PlayerAttack.instance.skillIndex];

            if (sIndex < 100)
                pc.m_animator.SetInteger("AttackAction", sIndex);
            else {
                if (!releaseSkillCount(sIndex % 100)) {
                    return;
                }
                pc.m_animator.SetInteger("SkillAction", sIndex % 100);
            }
                
            PlayerAttack.instance.skillIndex = (PlayerAttack.instance.skillIndex + 1) % PlayerAttack.instance.skillAction.Count;

        }
#else
					if (KeyManager.instance.GetKeyMessageDown(KeyManager.KeyCode.Combo))
                    {
                       int sIndex = PlayerAttack.instance.skillAction[PlayerAttack.instance.skillIndex];

            if (sIndex < 100)
                pc.m_animator.SetInteger("AttackAction", sIndex);
            else {
                if (!releaseSkillCount(sIndex % 100)) {
                    return;
                }
                pc.m_animator.SetInteger("SkillAction", sIndex % 100);
            }
                
            PlayerAttack.instance.skillIndex = (PlayerAttack.instance.skillIndex + 1) % PlayerAttack.instance.skillAction.Count;

                    }
#endif
#if UNITY_STANDALONE_WIN
        else if (Input.GetKeyUp(KeyCode.K))
        {
            PlayerAttack.instance.normalIndex = 0;
            pc.m_animator.SetInteger("AttackAction", PlayerAttack.instance.normalAction[PlayerAttack.instance.normalIndex]);
            PlayerAttack.instance.normalIndex = (PlayerAttack.instance.normalIndex + 1) % PlayerAttack.instance.normalAction.Count;
        }
#else
					else if (KeyManager.instance.GetKeyMessageUp(KeyManager.KeyCode.Attack))
                    {
                        PlayerAttack.instance.normalIndex = 0;
            pc.m_animator.SetInteger("AttackAction", PlayerAttack.instance.normalAction[PlayerAttack.instance.normalIndex]);
            PlayerAttack.instance.normalIndex = (PlayerAttack.instance.normalIndex + 1) % PlayerAttack.instance.normalAction.Count;

                    }
#endif
#if UNITY_STANDALONE_WIN
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            pc.m_animator.SetTrigger("Shift");
        }
#else
					else if (KeyManager.instance.GetKeyMessageDown(KeyManager.KeyCode.Evade))
                    {
                        pc.m_animator.SetTrigger("Shift");
                    }
#endif
#if UNITY_STANDALONE_WIN
        else if (Input.GetKeyDown(KeyCode.J))
        {
            pc.m_animator.SetTrigger("Jump");
        }
#else
					else if (KeyManager.instance.GetKeyMessageDown(KeyManager.KeyCode.Jump))
                    {
                        pc.m_animator.SetTrigger("Jump");
                    }
#endif
    }

    public override void execute(KGCharacterController pc)
    {
        if (animCurve != null) pc.transform.Translate(Time.deltaTime * (Player.instance.xDirection * animCurve.Evaluate(Time.time - startTime) * xTransfer * Vector2.right));
        else pc.transform.Translate(Time.deltaTime * (Player.instance.xDirection * xTransfer * Vector2.right));
        pc.transform.parent.position -= pc.transform.parent.position.y * Vector3.up;
    }

    public override void begin(KGCharacterController pc)
    {

    }

    protected static T m_Instance = null;

    public static T instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new T();
                m_Instance.init();
            }
            return m_Instance;
        }
    }

    public virtual void init()
    {
        xTransfer = 0;
        yTransfer = 0;
    }

    protected void moveableExecute(PlayerController pc)
    {
        pc.curMoveRate = pc.m_animator.GetFloat("MoveRate");
#if UNITY_STANDALONE_WIN
        Player.instance.moveDragRate = Input.GetAxis("Horizontal");
        pc.m_animator.SetFloat("MoveRate", Mathf.Abs(Player.instance.moveDragRate));
#else
        Player.instance.moveDragRate = KeyManager.instance.GetMoveDis();
        float rate = Mathf.Abs(Player.instance.moveDragRate);
        switch (pc.moveToRun)
        {
            case 0:
                pc.m_animator.SetFloat("MoveRate", Mathf.Abs(Player.instance.moveDragRate));
                if (rate > 0.4f) pc.moveToRun = 1;
                else if (rate < 0.4f && pc.curMoveRate >= 0.4f) pc.moveToRun = -1;
                break;
            case 1:
                pc.m_animator.SetFloat("MoveRate", Mathf.Lerp(pc.curMoveRate, 1, 5 * Time.deltaTime));
                if (rate < 0.4f && pc.curMoveRate >= 0.4f) pc.moveToRun = -1;
                break;
            case -1:
                pc.m_animator.SetFloat("MoveRate", Mathf.Lerp(pc.curMoveRate, rate, 5 * Time.deltaTime));
                if (rate > 0.4f) pc.moveToRun = 1;
                else if (rate < 0.01f) pc.moveToRun = 0;
                break;
        }
#endif

        //玩家转向
        if (Player.instance.moveDragRate > 0)
        {
            pc.transform.localScale = new Vector3(1, 1, 1);
            Player.instance.xDirection = Global.GlobalValue.XDIRECTION_RIGHT;
        }
        else if (Player.instance.moveDragRate < 0)
        {
            pc.transform.localScale = new Vector3(-1, 1, 1);
            Player.instance.xDirection = Global.GlobalValue.XDIRECTION_LEFT;
        }
    }

    protected void attackableExecute(PlayerController pc) {
#if UNITY_STANDALONE_WIN
        if (Input.GetKeyDown(KeyCode.K))
        {
            pc.m_animator.SetBool("JumpAttack", true);
            PlayerAttack.instance.combo = true;
        }
#else
				if (KeyManager.instance.GetKeyMessage(KeyManager.KeyCode.Attack))
                {
                    pc.m_animator.SetBool("JumpAttack", true);
            PlayerAttack.instance.combo = true;
                }
#endif
    }

    protected void fallingExecute(PlayerController pc) {
        if (pc.transform.parent.position.y <= 0.01f)
        {
            pc.rigid2D.velocity = Vector2.zero;
            pc.transform.parent.position -= pc.transform.parent.position.y * Vector3.up;
            pc.m_animator.SetBool("IsGround", true);
        }
        else
        {
            float rate = pc.getCurStateInfo().normalizedTime;
            pc.rigid2D.velocity = Vector2.down * yTransfer * rate;
            pc.m_animator.SetBool("IsGround", false);
        }
    }

    protected void skillExecute(PlayerController pc) {
        if (PlayerAttack.instance.chagneComboTime != -1)
        {
            pc.m_animator.SetBool("IsOver", true);
            pc.m_animator.SetInteger("AttackAction", 0);
            pc.m_animator.SetInteger("SkillAction", 0);
        }
        else {
            if (!PlayerAttack.instance.combo)
                skillCombo(pc);
            else pc.m_animator.SetBool("IsOver", false);
        }
        
    }

    protected bool damageCount(PlayerController pc) {
        if (pc.hitAttacks.Count != 0) {
            Attack atk = pc.hitAttacks.Pop();
            Player.instance.hp -= atk.m_AttackEffect.getDamageValue();
            pc.setDamage(atk.direction, atk.hitPos);
            if (Player.instance.hp <= 0) pc.m_animator.SetBool("Dead", true);
            //当前设定为一次只能被一种攻击攻击到，所以这里把栈清空
            pc.hitAttacks.Clear();
            return true;
        }
        return false;
    }

    protected void normaAttackExecute(PlayerController pc) {
        if (PlayerAttack.instance.chagneComboTime != -1)
        {
            pc.m_animator.SetBool("IsOver", true);
            pc.m_animator.SetInteger("AttackAction", 0);
            pc.m_animator.SetInteger("SkillAction", 0);
        }
        else {
            if (!PlayerAttack.instance.combo)
                normalCombo(pc);
            else pc.m_animator.SetBool("IsOver", false);
        }
    }

    bool releaseSkillCount(int index) {
        string skillName = "skill_" + Convert.ToString(index);
        float skillCost = PlayerAttackEffectController.getSkillCost(skillName);
        if (Player.instance.mp >= skillCost && PlayerAttackEffectController.getSkillReadyTime(skillName) == 0) {
            Player.instance.mp -= skillCost;
            PlayerAttackEffectController.cdReverse(skillName);
            return true;
        }
        return false;
    }

}