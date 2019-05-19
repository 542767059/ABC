//===================================================
//伸缩列表
//Time: 2019:1:11
//Autor: zhengjianyuan
//用法: 新建一个ScrollRect 然后挂上去，参数在面板调节 3个地方必须赋值：父节点预设，子节点预设 ，
//以及拖拽区域，拖拽区域就是ScrollRect 的content
//===================================================
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using UnityEngine.Events;

namespace ZJY.Framework
{
    /// <summary>
    /// 子项创建
    /// </summary>
    /// <param name="index">索引</param>
    /// <param name="obj">创建的物体</param>
    public delegate void OnItemCreateHandler(int index, GameObject obj);

    [RequireComponent(typeof(ScrollRect))]
    [AddComponentMenu("UI/UITelescopicView")]
    [DisallowMultipleComponent]
    public class UITelescopicView : MonoBehaviour
    {
        #region 属性
        [Header("是否允许多个列表同时打开")]
        [SerializeField]
        private bool IsAllowMultiple = false;

        [Header("父节点预设")]
        [SerializeField]
        private GameObject m_ParentNode;

        [Header("子节点预设")]
        [SerializeField]
        private GameObject m_ChildNode;

        [Header("拖拽的区域")]
        [SerializeField]
        private RectTransform m_Content;

        [Header("父节点宽高")]
        [SerializeField]
        private Vector2 m_ParentSize = Vector2.one;

        [Header("子节点宽高")]
        [SerializeField]
        private Vector2 m_ChildSize = Vector2.one;

        [Header("父节点间隔")]
        [SerializeField]
        [Range(0, 100)]
        private float m_SpacingParents = 0;

        [Header("子节点间隔")]
        [SerializeField]
        [Range(0, 100)]
        private float m_SpacingChilds = 0;

        [Header("父子节点间隔")]
        [SerializeField]
        [Range(0, 100)]
        private float m_SpacingParentandChild = 0;

        /// <summary>
        /// ScrollRect
        /// </summary>
        private ScrollRect m_ScrollRect;
        #endregion

        #region 列表计算需要的数据
        /// <summary>
        /// 父节点是否打开列表
        /// </summary>
        private List<Listitem> m_ParentList = new List<Listitem>();

        /// <summary>
        /// 父节点数量
        /// </summary>
        private int ParentCount;

        /// <summary>
        /// 子节点数量列表
        /// </summary>
        private List<int> m_Childlst;

        /// <summary>
        /// 父节点列表
        /// </summary>
        private List<GameObject> m_ParentObjlst;

        /// <summary>
        /// 显示子节点队列
        /// </summary>
        private Queue<GameObject> m_ChildQueue;

        /// <summary>
        /// 禁用的子节点队列 避免频繁克隆
        /// </summary>
        private Queue<GameObject> m_UnUseChildQueue;
        #endregion

        #region 创建子项完毕回调


        /// <summary>
        /// 创建子项完毕回调
        /// </summary>
        public OnItemCreateHandler OnItemCreate;
        #endregion

        private void Awake()
        {
            m_ChildQueue = new Queue<GameObject>();
            m_UnUseChildQueue = new Queue<GameObject>();
            m_ParentObjlst = new List<GameObject>();
            m_Childlst = new List<int>();
            m_ScrollRect = transform.GetComponent<ScrollRect>();

            #region 测试部分
            //==========================================测试部分===============================================
            Test();
            //==========================================测试部分===============================================
            #endregion
        }

        #region 测试部分


        //==========================================测试部分===============================================
        private void Test()
        {
            //这部分应该在别处初始化
            List<int> lst = new List<int>();
            lst.Add(10);
            lst.Add(10);
            lst.Add(15);
            lst.Add(20);
            OnInit(4, lst);

            //OnItemCreate += AAA;
        }
        private void AAA(int index, GameObject obj)
        {
            //这是测试的部分，回调的是对应gameobject 和在当前父节点下的索引;
            obj.transform.Find("Text").GetComponent<Text>().text = index.ToString();

            Button btnclick = obj.transform.GetComponent<Button>();
            btnclick.onClick.RemoveAllListeners();
            btnclick.onClick.AddListener(() =>
            {
            //Debug.Log(index);
        });
        }
        //==========================================测试部分===============================================
        #endregion

        #region OnInit 初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="parentCount">父节点数量</param>
        /// <param name="childlst">父节点拥有的子节点数量列表</param>
        public void OnInit(int parentCount, List<int> childlst)
        {
            RestData();

            if (m_Content == null)
            {
                throw new Exception("Content is invalid!");
            }
            m_Content.anchorMin = new Vector2(0, 1);
            m_Content.anchorMax = new Vector2(1, 1);
            m_Content.pivot = new Vector2(0, 1);
            m_Content.localPosition = Vector3.zero;
            SetScrollRect();


            if (m_ParentNode == null)
            {
                throw new Exception("ParentNode is invalid!");
            }

            if (m_ChildNode == null)
            {
                throw new Exception("ChildNode is invalid!");
            }

            m_Childlst.AddRange(childlst);

            ParentCount = parentCount;
            if (m_Childlst.Count != ParentCount)
            {
                throw new Exception("Parent count or childlst.count is invalid!");
            }

            CreateParentItem();
            Calculation();
            ShowList();
        }

        /// <summary>
        /// 重置数据
        /// </summary>
        private void RestData()
        {
            for (int i = 0; i < m_ParentObjlst.Count; i++)
            {
                Destroy(m_ParentObjlst[i]);
            }
            m_ParentObjlst.Clear();
            m_ParentList.Clear();
            m_Childlst.Clear();
            while (m_ChildQueue.Count > 0)
            {
                GameObject objchild = m_ChildQueue.Dequeue();
                objchild.SetActive(false);
                m_UnUseChildQueue.Enqueue(objchild);
            }
        }

        /// <summary>
        /// 创建父节点
        /// </summary>
        private void CreateParentItem()
        {
            if (m_ParentNode == null)
            {
                throw new Exception("ParentNode is invalid!");
            }

            //创建父物体，设置父物体的属性 并加入列表
            for (int i = 0; i < ParentCount; i++)
            {
                GameObject obj = Instantiate(m_ParentNode);
                int _index = i;
                Button btn = obj.GetComponent<Button>();
                if (btn == null)
                {
                    btn = obj.AddComponent<Button>();
                }
                //父节点监听
                ParentButtonAddListener(btn, _index);

                RectTransform rectTransform = obj.transform as RectTransform;
                rectTransform.SetParent(m_Content);
                //设置锚点为左上
                rectTransform.anchorMin = new Vector2(0, 1);
                rectTransform.anchorMax = new Vector2(0, 1);
                //设置中心点
                rectTransform.pivot = new Vector2(0, 1);
                //设置大小
                rectTransform.sizeDelta = m_ParentSize;

                //设置 旋转 缩放
                rectTransform.localScale = Vector3.one;
                rectTransform.eulerAngles = Vector3.zero;
                //rectTransform.localPosition = new Vector3(0, -m_ParentSize.y * i, 0);
                m_ParentObjlst.Add(obj);
                m_ParentList.Add(new Listitem(false));
                ShowList();
            }
        }
        #endregion

        #region SetScrollRect 设置ScrollRect
        /// <summary>
        /// 设置ScrollRect
        /// </summary>
        private void SetScrollRect()
        {
            if (m_ScrollRect == null)
            {
                throw new Exception("ScrollRect is invalid!");
            }
            //设置拖拽区域
            m_ScrollRect.content = m_Content;
            //设置拖拽方向
            m_ScrollRect.horizontal = false;
            m_ScrollRect.vertical = true;
        }
        #endregion

        #region ShowList 显示列表
        /// <summary>
        /// 父节点打开列表
        /// </summary>
        private List<int> m_ParentOpenlst = new List<int>();

        /// <summary>
        /// 显示列表
        /// </summary>
        private void ShowList()
        {
            //先回收所有已经显示的
            while (m_ChildQueue.Count > 0)
            {
                GameObject objchild = m_ChildQueue.Dequeue();
                objchild.SetActive(false);
                m_UnUseChildQueue.Enqueue(objchild);
            }

            m_ParentOpenlst.Clear();
            for (int i = 0; i < m_ParentList.Count; i++)
            {
                if (m_ParentList[i].IsChecked == true)
                {
                    m_ParentOpenlst.Add(i);
                }
            }

            //有打开的
            if (m_ParentOpenlst.Count > 0)
            {
                int count = m_ParentObjlst.Count;
                float yvalue = 0;
                for (int i = 0; i < count; i++)
                {
                    m_ParentObjlst[i].transform.localPosition = new Vector3(0, yvalue, 0);
                    yvalue -= m_ParentSize.y;

                    //如果这个列表是要打开的
                    if (m_ParentList[i].IsChecked)
                    {
                        int childlstcount = m_Childlst[i];
                        //如果子项列表数量是0
                        if (childlstcount == 0)
                        {
                            yvalue -= m_SpacingParents;
                        }
                        for (int j = 0; j < childlstcount; j++)
                        {
                            //第一项是与父节点的距离
                            if (j == 0)
                            {
                                yvalue -= m_SpacingParentandChild;
                            }

                            if (m_UnUseChildQueue.Count > 0)
                            {//如果缓存有，用缓存的
                                GameObject objchild = m_UnUseChildQueue.Dequeue();
                                m_ChildQueue.Enqueue(objchild);

                                objchild.SetActive(true);
                                objchild.transform.localPosition = new Vector3(0, yvalue, 0);
                                yvalue -= m_ChildSize.y;

                                if (OnItemCreate != null)
                                {
                                    OnItemCreate(j, objchild);
                                }
                            }
                            else
                            {//没有 实例化一个
                                GameObject objchild = Instantiate(m_ChildNode);
                                m_ChildQueue.Enqueue(objchild);

                                RectTransform rectTransform = objchild.transform as RectTransform;
                                rectTransform.SetParent(m_Content);
                                //设置锚点为左上
                                rectTransform.anchorMin = new Vector2(0, 1);
                                rectTransform.anchorMax = new Vector2(0, 1);
                                //设置中心点
                                rectTransform.pivot = new Vector2(0, 1);
                                //设置大小
                                rectTransform.sizeDelta = m_ChildSize;

                                //设置 旋转 缩放
                                rectTransform.localScale = Vector3.one;
                                rectTransform.eulerAngles = Vector3.zero;

                                objchild.SetActive(true);
                                objchild.transform.localPosition = new Vector3(0, yvalue, 0);
                                yvalue -= m_ChildSize.y;

                                if (OnItemCreate != null)
                                {
                                    OnItemCreate(j, objchild);
                                }
                            }

                            //设置下一个节点间隔

                            //如果已经是列表最后一个了
                            if (j == childlstcount - 1)
                            {
                                yvalue -= m_SpacingParentandChild;
                            }
                            else
                            {
                                yvalue -= m_SpacingChilds;
                            }
                        }

                    }
                    else
                    {//如果这个列表是不打开的
                        yvalue -= m_SpacingParents;
                    }
                }
            }
            else
            {//如果全部关闭
                int count = m_ParentObjlst.Count;
                float yvalue = 0;
                for (int i = 0; i < count; i++)
                {
                    m_ParentObjlst[i].transform.localPosition = new Vector3(0, yvalue, 0);
                    yvalue -= m_ParentSize.y;
                    yvalue -= m_SpacingParents;
                }
            }
        }

        /// <summary>
        /// 计算高度
        /// </summary>
        private void Calculation()
        {
            float yvalue = 0;
            Vector2 Size = Vector2.zero;

            m_ParentOpenlst.Clear();
            for (int i = 0; i < m_ParentList.Count; i++)
            {
                if (m_ParentList[i].IsChecked == true)
                {
                    m_ParentOpenlst.Add(i);
                }
            }

            if (m_ParentOpenlst.Count > 0)
            {
                for (int i = 0; i < ParentCount; i++)
                {
                    yvalue += m_ParentSize.y;
                    //如果这个列表是要打开的
                    if (m_ParentList[i].IsChecked)
                    {
                        int childlstcount = m_Childlst[i];
                        //如果子项列表数量是0
                        if (childlstcount == 0)
                        {
                            yvalue += m_SpacingParents;
                        }
                        for (int j = 0; j < childlstcount; j++)
                        {
                            //第一项是与父节点的距离
                            if (j == 0)
                            {
                                yvalue += m_SpacingParentandChild;
                            }
                            yvalue += m_ChildSize.y;

                            //设置下一个节点间隔

                            //如果已经是列表最后一个了
                            if (j == childlstcount - 1)
                            {
                                yvalue += m_SpacingParentandChild;
                            }
                            else
                            {
                                yvalue += m_SpacingChilds;
                            }
                        }

                    }
                    else
                    {//如果这个列表是不打开的
                        yvalue += m_SpacingParents;
                    }

                }
                Size = new Vector2(0, yvalue);
            }
            else
            {
                yvalue = m_ParentSize.y * ParentCount + (ParentCount - 1) * m_SpacingParents;
                Size = new Vector2(0, yvalue);
            }
            m_Content.sizeDelta = Size;
        }
        #endregion

        #region  ParentButtonAddListener 父节点点击事件
        /// <summary>
        /// 父节点点击事件
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private void ParentButtonAddListener(Button btn, int index)
        {
            btn.onClick.AddListener(() =>
            {
                for (int i = 0; i < m_ParentList.Count; i++)
                {
                    if (index == i)
                    {
                        m_ParentList[i].IsChecked = !m_ParentList[i].IsChecked;
                    }
                    else
                    {
                        if (!IsAllowMultiple)
                        {
                            m_ParentList[i].IsChecked = false;
                        }
                    }
                }

                Calculation();
                ShowList();
            });
        }
        #endregion

        #region 辅助子类 Listitem
        private class Listitem
        {
            public bool IsChecked;

            public Listitem(bool isChecked)
            {
                IsChecked = isChecked;
            }
        }
        #endregion

    }
}


