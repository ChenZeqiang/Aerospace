using Optoma.FileManager;
using Optoma.Command;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Optoma.Global
{
    /// <summary>
    ///  全局时间管理
    /// </summary>
    public class GlobalEventManagerScript : MonoBehaviour
    {
        private void Awake()
        {
            // 监听事件
            EventCenter.AddListener<string>(GlobalConfig.EnumTypesManager.EventTypes.OpenDirecory,
                OpenDirectoryChooseFile.OpenDirectoryAndChooseFile);
        }

        private void OnDestroy()
        {
            // 取消监听
            EventCenter.RemoveListener<string>(GlobalConfig.EnumTypesManager.EventTypes.OpenDirecory,
                OpenDirectoryChooseFile.OpenDirectoryAndChooseFile);
            Application.Quit();
        }
    }
}