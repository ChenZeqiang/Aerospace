using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Optoma.Global
{
    /// <summary>
    ///  全局配置
    /// </summary>
    public static class GlobalConfig 
    {
        /// <summary>
        ///  文件种类管理
        /// </summary>
        public class FileTypesManager
        {
            /// <summary>
            ///  文件标记
            ///  不一定要全选，但是最后一个0x00000008不要缺少
            /// </summary>
            public readonly static int FileFlags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000200 | 0x00000008;
            /// <summary>
            ///  图片和视频
            /// </summary>
            public const string FileType = TextureType +";*" + MovieType;
            /// <summary>
            ///  图片类型
            /// </summary>
            public const  string TextureType = ".JPG;*.PNG;*.PSD;*.CDR;*.TIF;*.GIF;*.TGA;*.EXIF;*.FPX;*.SVG;*.PCD";
            /// <summary>
            ///  视频类型
            /// </summary>
            public const  string MovieType = ".mp4;*.avi;*.mpg;*.mov;*.ogv";
            /// <summary>
            ///  选择图片/视频文件
            /// </summary>
            public readonly static string FileTitle = "选择图片/视频文件";
            /// <summary>
            ///  选择图片文件
            /// </summary>
            public readonly static string FileTitle_Open_Texture = "选择图片文件";
            /// <summary>
            ///  选择视频文件
            /// </summary>
            public readonly static string FileTitle_Open_Movie = "选择视频文件";
            /// <summary>
            ///  另存为图片文件
            /// </summary>
            public readonly static string FileTitle_Save_Texture = "另存为图片文件";
            /// <summary>
            ///  另存为视频文件
            /// </summary>
            public readonly static string FileTitle_Save_Movie = "另存为视频文件";
        }

        /// <summary>
        ///  枚举类型管理
        /// </summary>
        public class EnumTypesManager
        {
            public enum EventTypes
            {
                OpenDirecory,// 打开磁盘
                ChooseTexture,// 选择图片
                ChooseMovie,// 选择视频
            }
        }

        /// <summary>
        ///  物体的Tag值
        /// </summary>
        public class GameObjectTagsManager
        {
            /// <summary>
            ///  选择图片的按钮的Tag值
            /// </summary>
            public const string ChooseButtonTag = "ChooseButton";
        }
      
    }
}