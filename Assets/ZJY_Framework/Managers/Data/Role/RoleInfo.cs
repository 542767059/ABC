using System;

namespace ZJY.Framework
{
    [Serializable]
    public class RoleInfo :RoleInfoBase
    {
        public int Exp; //经验
        public int MaxMP; //最大MP
        public int CurrMP; //当前MP
        public int Attack; //攻击力
        public int Defense; //防御
        public int Hit; //命中
        public int Dodge; //闪避
        public int Cri; //暴击
        public int Res; //抗性
        public int Fighting; //综合战斗力

        

        public RoleInfo(RoleOperation_SelectRoleInfoReturnProto RoleInfoProto)
        {
            RoleId = RoleInfoProto.RoldId;
            RoleNickName = RoleInfoProto.RoleNickName;
            JobId = RoleInfoProto.JobId;
            Level = RoleInfoProto.Level;
            Exp = RoleInfoProto.Exp;
            MaxHP = RoleInfoProto.MaxHP;
            MaxMP = RoleInfoProto.MaxMP;
            CurrHP = RoleInfoProto.CurrHP;
            CurrMP = RoleInfoProto.CurrMP;
            Attack = RoleInfoProto.Attack;
            Defense = RoleInfoProto.Defense;
            Hit = RoleInfoProto.Hit;
            Dodge = RoleInfoProto.Dodge;
            Cri = RoleInfoProto.Cri;
            Res = RoleInfoProto.Res;
            Fighting = RoleInfoProto.Fighting;
        }
    }
}
