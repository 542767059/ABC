using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// ����̧���¼�
    /// </summary>
    public class InputPointUpGameEvent : GameEventBase
    {
        /// <summary>
        /// ����̧���¼����
        /// </summary>
        public static readonly int EventId = typeof(InputPointUpGameEvent).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        /// <summary>
        /// ����Id
        /// </summary>
        public int FingerId
        {
            get;
            private set;
        }

        /// <summary>
        /// λ��
        /// </summary>
        public Vector2 Postion
        {
            get;
            private set;
        }

        /// <summary>
        /// ��������
        /// </summary>
        public FingerType FingerType
        {
            get;
            private set;
        }

        /// <summary>
        /// �������̧���¼�
        /// </summary>
        /// <param name="fingerId"></param>
        /// <param name="postion"></param>
        /// <param name="fingerType"></param>
        /// <returns></returns>
        public InputPointUpGameEvent Fill(int fingerId, Vector2 postion, FingerType fingerType)
        {
            FingerId = fingerId;
            Postion = postion;
            FingerType = fingerType;
            return this;
        }
    }
}
