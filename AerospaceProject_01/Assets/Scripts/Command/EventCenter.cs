﻿using System.Collections;
using System.Collections.Generic;
using System;
using Optoma.Global;

namespace Optoma.Command
{

    public class EventCenter
    {
        public delegate void CallBack();
        public delegate void CallBack<T>(T arg);
        public delegate void CallBack<T, X>(T arg1, X arg2);
        public delegate void CallBack<T, X, Y>(T arg1, X arg2, Y arg3);
        public delegate void CallBack<T, X, Y, Z>(T arg1, X arg2, Y arg3, Z arg4);
        public delegate void CallBack<T, X, Y, Z, W>(T arg1, X arg2, Y arg3, Z arg4, W arg5);
        private static Dictionary<GlobalConfig.EnumTypesManager.EventTypes, Delegate> m_EventTable = 
            new Dictionary<GlobalConfig.EnumTypesManager.EventTypes, Delegate>();
        private static void OnListenerAdding(GlobalConfig.EnumTypesManager.EventTypes eventType, Delegate callBack)
        {
            if (!m_EventTable.ContainsKey(eventType))
            {
                m_EventTable.Add(eventType, null);
            }
            Delegate d = m_EventTable[eventType];
            if (d != null && d.GetType() != callBack.GetType())
            {
                throw new Exception(string.Format("尝试为事件{0}添加不同类型的委托 ，当前事件所对应的委托是{1},要添加的委托是{2}",
                        eventType, d.GetType(), callBack.GetType()));
            }
        }
        private static void OnListenerRemoving(GlobalConfig.EnumTypesManager.EventTypes eventType, Delegate callBack)
        {
            if (m_EventTable.ContainsKey(eventType))
            {
                Delegate d = m_EventTable[eventType];
                if (d == null)
                {
                    throw new Exception(string.Format("移除监听事件错误： 事件{0}没有对应的委托", eventType));
                }
                else if (d.GetType() != callBack.GetType())
                {
                    throw new Exception(string.Format("移除监听错误：尝试为事件{0}移除不同类型的委托，当前的委托类型是{1}，要移除的委托类型是{2}",
                            eventType, d.GetType(), callBack.GetType()));
                }
            }
            else
            {
                throw new Exception(string.Format("移除监听错误：没有事件码{0}", eventType));
            }
        }
        private static void OnListenerRemoved(GlobalConfig.EnumTypesManager.EventTypes eventType)
        {
            if (m_EventTable[eventType] == null)
            {
                m_EventTable.Remove(eventType);
            }
        }
        /**
         * 添加监听
         */
        public static void AddListener(GlobalConfig.EnumTypesManager.EventTypes eventType, CallBack callBack)
        {
            OnListenerAdding(eventType, callBack);
            m_EventTable[eventType] = (CallBack)m_EventTable[eventType] + callBack;
        }
        public static void AddListener<T>(GlobalConfig.EnumTypesManager.EventTypes eventType, CallBack<T> callBack)
        {
            OnListenerAdding(eventType, callBack);
            m_EventTable[eventType] = (CallBack<T>)m_EventTable[eventType] + callBack;
        }
        public static void AddListener<T, X>(GlobalConfig.EnumTypesManager.EventTypes eventType, CallBack<T, X> callBack)
        {
            OnListenerAdding(eventType, callBack);
            m_EventTable[eventType] = (CallBack<T, X>)m_EventTable[eventType] + callBack;
        }
        public static void AddListener<T, X, Y>(GlobalConfig.EnumTypesManager.EventTypes eventType, CallBack<T, X, Y> callBack)
        {
            OnListenerAdding(eventType, callBack);
            m_EventTable[eventType] = (CallBack<T, X, Y>)m_EventTable[eventType] + callBack;
        }
        public static void AddListener<T, X, Y, Z>(GlobalConfig.EnumTypesManager.EventTypes eventType, CallBack<T, X, Y, Z> callBack)
        {
            OnListenerAdding(eventType, callBack);
            m_EventTable[eventType] = (CallBack<T, X, Y, Z>)m_EventTable[eventType] + callBack;
        }
        public static void AddListener<T, X, Y, Z, W>(GlobalConfig.EnumTypesManager.EventTypes eventType, CallBack<T, X, Y, Z, W> callBack)
        {
            OnListenerAdding(eventType, callBack);
            m_EventTable[eventType] = (CallBack<T, X, Y, Z, W>)m_EventTable[eventType] + callBack;
        }

        /**
         * 移除监听事件
         */
        public static void RemoveListener(GlobalConfig.EnumTypesManager.EventTypes eventType, CallBack callBack)
        {
            OnListenerRemoving(eventType, callBack);
            m_EventTable[eventType] = (CallBack)m_EventTable[eventType] - callBack;
            OnListenerRemoved(eventType);
        }
        public static void RemoveListener<T>(GlobalConfig.EnumTypesManager.EventTypes eventType, CallBack<T> callBack)
        {
            OnListenerRemoving(eventType, callBack);
            m_EventTable[eventType] = (CallBack<T>)m_EventTable[eventType] - callBack;
            OnListenerRemoved(eventType);
        }
        public static void RemoveListener<T, X>(GlobalConfig.EnumTypesManager.EventTypes eventType, CallBack<T, X> callBack)
        {
            OnListenerRemoving(eventType, callBack);
            m_EventTable[eventType] = (CallBack<T, X>)m_EventTable[eventType] - callBack;
            OnListenerRemoved(eventType);
        }
        public static void RemoveListener<T, X, Y>(GlobalConfig.EnumTypesManager.EventTypes eventType, CallBack<T, X, Y> callBack)
        {
            OnListenerRemoving(eventType, callBack);
            m_EventTable[eventType] = (CallBack<T, X, Y>)m_EventTable[eventType] - callBack;
            OnListenerRemoved(eventType);
        }
        public static void RemoveListener<T, X, Y, Z>(GlobalConfig.EnumTypesManager.EventTypes eventType, CallBack<T, X, Y, Z> callBack)
        {
            OnListenerRemoving(eventType, callBack);
            m_EventTable[eventType] = (CallBack<T, X, Y, Z>)m_EventTable[eventType] - callBack;
            OnListenerRemoved(eventType);
        }
        public static void RemoveListener<T, X, Y, Z, W>(GlobalConfig.EnumTypesManager.EventTypes eventType, CallBack<T, X, Y, Z, W> callBack)
        {
            OnListenerRemoving(eventType, callBack);
            m_EventTable[eventType] = (CallBack<T, X, Y, Z, W>)m_EventTable[eventType] - callBack;
            OnListenerRemoved(eventType);
        }
        /**
         * 广播事件
         */
        public static void Broadcast(GlobalConfig.EnumTypesManager.EventTypes eventType)
        {
            Delegate d;
            if (m_EventTable.TryGetValue(eventType, out d))
            {
                CallBack callBack = d as CallBack;
                if (callBack != null)
                {
                    callBack();
                }
                else
                {
                    throw new Exception(string.Format("广播事件错误：事件{0}对应委托具有不同的类型", eventType));
                }
            }
        }
        public static void Broadcast<T>(GlobalConfig.EnumTypesManager.EventTypes eventType, T arg1)
        {
            Delegate d;
            if (m_EventTable.TryGetValue(eventType, out d))
            {
                CallBack<T> callBack = d as CallBack<T>;
                if (callBack != null)
                {
                    callBack(arg1);
                }
                else
                {
                    throw new Exception(string.Format("广播事件错误：事件{0}对应委托具有不同的类型", eventType));
                }
            }
        }
        public static void Broadcast<T, X>(GlobalConfig.EnumTypesManager.EventTypes eventType, T arg1, X arg2)
        {
            Delegate d;
            if (m_EventTable.TryGetValue(eventType, out d))
            {
                CallBack<T, X> callBack = d as CallBack<T, X>;
                if (callBack != null)
                {
                    callBack(arg1, arg2);
                }
                else
                {
                    throw new Exception(string.Format("广播时间错误：事件{0}对应委托具有不同的类型", eventType));
                }
            }
        }
        public static void Broadcast<T, X, Y>(GlobalConfig.EnumTypesManager.EventTypes eventType, T arg1, X arg2, Y arg3)
        {
            Delegate d;
            if (m_EventTable.TryGetValue(eventType, out d))
            {
                CallBack<T, X, Y> callBack = d as CallBack<T, X, Y>;
                if (callBack != null)
                {
                    callBack(arg1, arg2, arg3);
                }
                else
                {
                    throw new Exception(string.Format("广播时间错误：事件{0}对应委托具有不同的类型", eventType));
                }
            }
        }
        public static void Broadcast<T, X, Y, Z>(GlobalConfig.EnumTypesManager.EventTypes eventType, T arg1, X arg2, Y arg3, Z arg4)
        {
            Delegate d;
            if (m_EventTable.TryGetValue(eventType, out d))
            {
                CallBack<T, X, Y, Z> callBack = d as CallBack<T, X, Y, Z>;
                if (callBack != null)
                {
                    callBack(arg1, arg2, arg3, arg4);
                }
                else
                {
                    throw new Exception(string.Format("广播时间错误：事件{0}对应委托具有不同的类型", eventType));
                }
            }
        }
        public static void Broadcast<T, X, Y, Z, W>(GlobalConfig.EnumTypesManager.EventTypes eventType, T arg1, X arg2, Y arg3, Z arg4, W arg5)
        {
            Delegate d;
            if (m_EventTable.TryGetValue(eventType, out d))
            {
                CallBack<T, X, Y, Z, W> callBack = d as CallBack<T, X, Y, Z, W>;
                if (callBack != null)
                {
                    callBack(arg1, arg2, arg3, arg4, arg5);
                }
                else
                {
                    throw new Exception(string.Format("广播时间错误：事件{0}对应委托具有不同的类型", eventType));
                }
            }
        }

    }
}