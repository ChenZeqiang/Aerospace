using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Optoma.FileManager
{

    /**
     * Sequential表示顺序存储，按照成员的先后顺序进行排列
     * CharSet定义在结构中的字符串成员在结构被传给Dll时的排列方式
     */
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class OpenFileName
    {
        /// <summary>
        ///  结构体的大小
        /// </summary>
        public int structSize = 0;
        // IntPtr它是一个类，用于包装在调用Windows API函数时使用的指针。
        // 根据平台的不同，底层指针可以是32位或64位。
        // C#调用Win32 API时，调用Dll时
        // 表示已初始化为零的指针或句柄的只读字段。
        public IntPtr dlgOwner = IntPtr.Zero;
        public IntPtr instance = IntPtr.Zero;
        /// <summary>
        /// 过滤文件字符串
        /// </summary>
        public String filter = null;
        /// <summary>
        /// 自定义过滤器
        /// </summary>
        public String customFilter = null;
        /// <summary>
        /// 最大自定义过滤器个数
        /// </summary>
        public int maxCustFilter = 0;
        /// <summary>
        /// 过滤器索引
        /// </summary>
        public int filterIndex = 0;
        /// <summary>
        /// 文件路径
        /// </summary>
        public String file = null;
        /// <summary>
        ///  文件最大个数
        /// </summary>
        public int maxFile = 0;
        /// <summary>
        /// 文件标题
        /// </summary>
        public String fileTitle = null;
        /// <summary>
        /// 文件标题最大个数
        /// </summary>
        public int maxFileTitle = 0;
        /// <summary>
        ///  最初的文件夹
        /// </summary>
        public String initialDir = null;
        /// <summary>
        ///  标题
        /// </summary>
        public String title = null;
        /// <summary>
        ///  标记
        /// </summary>
        public int flags = 0;
        /// <summary>
        ///  文件偏移量
        /// </summary>
        public short fileOffset = 0;
        /// <summary>
        ///  文件扩展名字
        /// </summary>
        public short fileExtension = 0;
        /// <summary>
        ///  扩展名字
        /// </summary>
        public String defExt = null;
        /// <summary>
        ///  自定义数据
        /// </summary>
        public IntPtr custData = IntPtr.Zero;
        /// <summary>
        ///  hook
        /// </summary>
        public IntPtr hook = IntPtr.Zero;
        /// <summary>
        ///  模板名称
        /// </summary>
        public String templateName = null;
        /// <summary>
        ///  保留的Ptr
        /// </summary>
        public IntPtr reservedPtr = IntPtr.Zero;
        /// <summary>
        ///  保留的Int
        /// </summary>
        public int reservedInt = 0;
        /// <summary>
        ///  标记的扩展
        /// </summary>
        public int flagsEx = 0;
    }
}