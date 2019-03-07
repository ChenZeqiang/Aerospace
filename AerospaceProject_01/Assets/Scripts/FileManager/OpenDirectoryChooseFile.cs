using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Optoma.Global;
using Optoma.Command;

namespace Optoma.FileManager
{
    /// <summary>
    ///  打开磁盘并且选择文件
    /// </summary>
    public class OpenDirectoryChooseFile 
    {
        /// <summary>
        ///  打开磁盘并且选择文件
        /// </summary>
        /// <param name="type">文件种类</param>
        public static void OpenDirectoryAndChooseFile(string type)
        {
            OpenFileName openFileName = new OpenFileName();
            // 得到该对象的内存的大小
            openFileName.structSize = Marshal.SizeOf(openFileName);
            // 表示需要选择的文件类型
            // \后面的意思是剔除其他非exe文件
            // 筛选需要类型的文件
            // openFileName.filter = "文件(*." + type + ")\0*." + type;
            openFileName.filter = "文件(*" + type + ")\0*." + type;
            // 初始化文件路径
            openFileName.file = new string(new char[256]);
            openFileName.maxFile = openFileName.file.Length;
            // 初始化文件标题
            openFileName.fileTitle = new string(new char[64]);
            openFileName.maxFileTitle = openFileName.fileTitle.Length;
            // 初始化文件夹
            openFileName.initialDir = Application.streamingAssetsPath.Replace("/","\\");
            // 表示打开的系统窗口名称
            GetFileTitle(openFileName, type);
            openFileName.flags = GlobalConfig.FileTypesManager.FileFlags;
            // 选择文件
            ChooseFile.OpenAndChooseFile(openFileName, type);
        }

        /// <summary>
        ///  得到文件标题
        /// </summary>
        /// <param name="type">文件类型</param>
        private static void GetFileTitle(OpenFileName openFileName,string type)
        {
            switch (type)
            {
                case GlobalConfig.FileTypesManager.FileType:
                    {
                        // 如果没固定选择
                        openFileName.title = GlobalConfig.FileTypesManager.FileTitle;
                        break;
                    }
                case GlobalConfig.FileTypesManager.TextureType:
                    {
                        // 如果选择的种类是图片,那么表示打开的系统窗口名称是“选择图片文件”
                        openFileName.title = GlobalConfig.FileTypesManager.FileTitle_Open_Texture;
                        break;
                    }
                case GlobalConfig.FileTypesManager.MovieType:
                    {
                        // 如果选择的种类是视频，那么表示打开的系统窗口名称是“选择视频文件”
                        openFileName.title = GlobalConfig.FileTypesManager.FileTitle_Open_Movie;
                        break;
                    }
                default:
                    break;
            }
        }
    }
}