using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ZJY.Framework
{
    public class SkillView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler
    {
        [SerializeField]
        private CancelView m_CancelView;

        [SerializeField]
        private Image m_CDImage;

        [SerializeField]
        private Text m_CDText;

        [SerializeField]
        private Image m_StackNumMask;

        [SerializeField]
        private Image m_StackNumImage;

        [SerializeField]
        private Text m_StackNumtext;

        [SerializeField]
        private Image m_OuterCircle;

        [SerializeField]
        private Image m_InnerCircle;

        [SerializeField]
        private float m_OuterCircleRadius;

        [SerializeField]
        private SkillData m_SkillData;

        private bool pressed = false;
        private bool isdrag = false;
        private bool iscancel = false;

        [SerializeField]
        private GameObject cdOverEffect;

        [SerializeField]
        private int StackAmount;

        [SerializeField]
        private float m_StackCdtime;

        [SerializeField]
        private float m_CDTime;
        /// <summary>
        /// 获取是否CD中
        /// </summary>
        public bool IsCD
        {
            get
            {
                if (m_CDTime > 0)
                {
                    return true;
                }
                if (m_SkillData.StackAmount >= 2)
                {
                    return StackAmount <= 0;
                }
                return false;
            }
        }

        private void Awake()
        {
            m_CancelView.CancelEnter += CancelEnter;
            m_CancelView.CancelExit += CancelExit;
        }

        private void Start()
        {
            GameEntry.Event.CommonEvent.AddEventListener(SkillCDGameEvent.EventId, OnSkillCD);
        }

        private void OnDestroy()
        {
            m_CancelView.CancelEnter -= CancelEnter;
            m_CancelView.CancelExit += CancelExit;
            if (!GameEntry.IsShutdown)
            {
                GameEntry.Event.CommonEvent.RemoveEventListener(SkillCDGameEvent.EventId, OnSkillCD);
            }
        }

        private void OnSkillCD(GameEventBase gameEventBase)
        {
            SkillCDGameEvent skillCDGameEvent = (SkillCDGameEvent)gameEventBase;

            if (skillCDGameEvent.SkillId == m_SkillData.SkillId)
            {
                if (m_SkillData.SkillId == 10010)
                {
                    m_SkillData.SkillId = 10011;
                    BeginValueCD();
                    return;
                }
                else if (m_SkillData.SkillId == 10011)
                {
                    m_SkillData.SkillId = 10012;
                    BeginValueCD();
                    return;
                }
                else if (m_SkillData.SkillId == 10012)
                {
                    m_SkillData.SkillId = 10010;
                    BeginCD(skillCDGameEvent.CD);
                    return;
                }
                BeginCD(skillCDGameEvent.CD);
            }
        }

        private void BeginValueCD(float? cdtime = null)
        {
            m_StackNumImage.fillAmount = 0;
            m_StackCdtime = cdtime.HasValue ? cdtime.Value : m_SkillData.StackCDTime;
        }

        /// <summary>
        /// 设置UI
        /// </summary>
        /// <param name="skillData">技能数据</param>
        public void SetUI(SkillData skillData)
        {
            m_SkillData = skillData;
        }

        private void Update()
        {
            if (m_CDTime > 0)
            {
                m_CDTime -= Time.deltaTime;
                if (m_CDTime < 0)
                {
                    m_CDTime = 0;
                    if (cdOverEffect != null)
                    {
                        cdOverEffect.SetActive(false);
                        cdOverEffect.SetActive(true);
                    }
                }
                m_CDImage.fillAmount = m_CDTime / m_SkillData.CDTime;
                int cdtime = (int)m_CDTime;
                m_CDText.text = cdtime > 0 ? cdtime.ToString("f0") : string.Empty;
            }

            if (m_SkillData.StackAmount >= 2)
            {
                if (m_StackCdtime > 0)
                {
                    m_StackCdtime -= Time.deltaTime;
                    if (m_StackCdtime < 0)
                    {
                        m_StackCdtime = 0;
                        StackAmount++;
                        m_StackNumtext.text = StackAmount.ToString();
                        if (StackAmount < m_SkillData.StackAmount)
                        {
                            m_StackCdtime = m_SkillData.StackCDTime;
                        }
                        m_StackNumMask.gameObject.SetActive(false);
                    }
                    m_StackNumImage.fillAmount = 1 - (m_StackCdtime / m_SkillData.StackCDTime);
                }
            }

            if (m_SkillData.IsCombo)
            {
                if (m_StackCdtime > 0)
                {
                    m_StackCdtime -= Time.deltaTime;
                    if (m_StackCdtime < 0)
                    {
                        m_StackCdtime = 0;
                        m_SkillData.SkillId = 10010;
                        BeginCD();
                    }
                    m_StackNumImage.fillAmount = 1 - (m_StackCdtime / m_SkillData.StackCDTime);
                }
            }
        }

        /// <summary>
        /// 开始冷却
        /// </summary>
        public void BeginCD(float? cdtime = null)
        {
            m_CDImage.fillAmount = 1;
            m_CDTime = cdtime.HasValue ? cdtime.Value : m_SkillData.CDTime;
            if (cdOverEffect != null) cdOverEffect.SetActive(false);

            if (m_SkillData.StackAmount >= 2)
            {
                if (StackAmount == m_SkillData.StackAmount)
                {
                    m_StackCdtime = m_SkillData.StackCDTime;
                }
                StackAmount--;
                m_StackNumtext.text = StackAmount.ToString();
                if (StackAmount <= 0)
                {
                    m_StackNumMask.gameObject.SetActive(true);
                }
            }

            if (m_SkillData.IsCombo)
            {
                m_StackCdtime = 0;
                m_StackNumImage.fillAmount = 1;
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!pressed)
            {
                return;
            }
            isdrag = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!pressed)
            {
                return;
            }
            Vector2 touchPos;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(m_OuterCircle.rectTransform, eventData.position, GameEntry.UI.UICamera, out touchPos))
            {
                if (Vector2.Distance(touchPos, Vector2.zero) < m_OuterCircleRadius)
                    m_InnerCircle.transform.localPosition = touchPos;
                else
                    m_InnerCircle.transform.localPosition = touchPos.normalized * m_OuterCircleRadius;
            }
            Vector2 pos = m_InnerCircle.transform.localPosition / m_OuterCircleRadius;
            GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<ChangeSkillAreaGameEvent>().Fill(pos));
        }


        public void OnPointerDown(PointerEventData eventData)
        {
            if (IsCD)
            {
                return;
            }
            pressed = true;
            GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<ShowSkillAreaGameEvent>().Fill(m_SkillData.SKillAreaType));
            isdrag = false;
            m_OuterCircle.gameObject.SetActive(true);
            m_CancelView.gameObject.SetActive(true);
            m_InnerCircle.transform.localPosition = Vector3.zero;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!pressed)
            {
                return;
            }
            pressed = false;
            m_OuterCircle.gameObject.SetActive(false);
            m_CancelView.gameObject.SetActive(false);

            GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<HideSkillAreaGameEvent>());
            //如果取消了
            if (iscancel)
            {
                Debug.Log("取消");
                CancelExit();
                return;
            }

            if (isdrag)
            {
                Vector2 pos = m_InnerCircle.transform.localPosition / m_OuterCircleRadius;
                Debug.Log("技能位置" + pos);
                GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<SkillButtonClickGameEvent>().Fill(m_SkillData.SkillId, pos, false));
                //BeginCD();
            }
            else
            {
                Debug.Log("普通释放技能");
                GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<SkillButtonClickGameEvent>().Fill(m_SkillData.SkillId, Vector2.zero, true));
                //BeginCD();
            }
        }



        private void CancelEnter()
        {
            iscancel = true;
            Debug.Log("变红事件");
        }

        private void CancelExit()
        {
            iscancel = false;
            Debug.Log("还原颜色事件");
        }
    }
}
