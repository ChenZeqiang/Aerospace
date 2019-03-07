using System.Runtime.InteropServices;// 用DllImport需要此命名空间
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Optoma.FileManager
{
    /// <summary>
    ///  使用的对话框,打开文件
    /// </summary>
    public class LocalDialog
    {
        /// <summary>
        ///  链接制定系统函数，打开文件对话框
        /// </summary>
        /// <param name="ofn"></param>
        /// <returns></returns>
        [DllImport("Comdlg32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
        public static extern bool GetOpenFileName([In, Out] OpenFileName ofn);
        public static bool GetOpenFileNameFunction([In, Out] OpenFileName ofn)
        {
            // 执行打开文件的操作
            return GetOpenFileName(ofn);
        }

        /// <summary>
        ///  链接指定系统函数，另存为对话框
        /// </summary>
        //[DllImport("Comdlg32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
        //public static extern bool GetSaveFileName([In, Out] OpenFileName ofn);
        //public static bool GetSaveFileNameFunction([In, Out] OpenFileName ofn)
        //{
        //    // 执行保存选中文件的操作
        //    return GetSaveFileName(ofn);
        //}
    }
}