using Optoma.FileManager;
using Optoma.Global;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Optoma.Command
{
    /// <summary>
    ///  选择文件
    /// </summary>
    public class ChooseFile 
    {
        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="openFileName"></param>
        /// <param name="type">文件类型</param>
        public static void OpenAndChooseFile(OpenFileName openFileName, string type)
        {
            if (LocalDialog.GetOpenFileName(openFileName))
            {
                switch (type)
                {
                    // 选择的是图片/视频文件
                    case GlobalConfig.FileTypesManager.FileType:
                        {
                            // 进行判断
                            Debug.Log(string.Format("打开文件，文件是：{0}", openFileName.file));
                            Debug.Log(Path.GetExtension(openFileName.file));
                            JudgeFileType(openFileName);
                            break;
                        }
                    // 打开图片
                    case GlobalConfig.FileTypesManager.TextureType:
                        {
                            // 将图片添加到物体上
                            Debug.Log("添加了图片");
                            // 进行事件广播
                            EventCenter.Broadcast<OpenFileName>(GlobalConfig.EnumTypesManager.EventTypes.ChooseTexture,
                                openFileName);
                            break;
                        }
                    // 打开视频
                    case GlobalConfig.FileTypesManager.MovieType:
                        {
                            // 将视频添加到物体上
                            Debug.Log("添加了视频");
                            // 进行事件广播
                            EventCenter.Broadcast<OpenFileName>(GlobalConfig.EnumTypesManager.EventTypes.ChooseMovie,
                                openFileName);
                            break;
                        }
                    default:
                        break;
                }

            }
        }

        /// <summary>
        ///  判断文件类型，根据后缀名判断
        /// </summary>
        /// <param name="openFileName">选择的文件</param>
        private static void JudgeFileType(OpenFileName openFileName)
        {
            // 得到文件的扩展名
            string extension = Path.GetExtension(openFileName.file);
            string textureType = "." + GlobalConfig.FileTypesManager.TextureType;
            string movieType = "." + GlobalConfig.FileTypesManager.MovieType;
            if (textureType.Contains(extension))
            {
                // 为图片类型
                Debug.Log("选择了图片文件");
                // 进行广播事件
                EventCenter.Broadcast<OpenFileName>(GlobalConfig.EnumTypesManager.EventTypes.ChooseTexture,
                    openFileName);
            }
            else if (movieType.Contains(extension))
            {
                // 为视频类型
                Debug.Log("选择了视频文件");
                // 进行广播事件
                EventCenter.Broadcast<OpenFileName>(GlobalConfig.EnumTypesManager.EventTypes.ChooseMovie,
                    openFileName);
            }
            else
            {
                // 为其他类型
                Debug.Log("选择的为其他类型，请重新选择");
            }
        }
    }
}