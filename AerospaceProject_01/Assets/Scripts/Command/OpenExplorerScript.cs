using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Optoma.FileManager;
using Optoma.Global;
using UnityEngine.UI;

namespace Optoma.Command
{
    /// <summary>
    ///  打开文件管理器
    /// </summary>
    public class OpenExplorerScript : MonoBehaviour
    {
        #region Unity Callback

        private void Start()
        {
            gameObject.GetComponent<Button>().onClick.AddListener(delegate() {
                // 进行广播，打开文件管理器
                EventCenter.Broadcast<string>(GlobalConfig.EnumTypesManager.EventTypes.OpenDirecory,
                    GlobalConfig.FileTypesManager.FileType);
            });
        }

        #endregion
    }
}