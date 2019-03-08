using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Optoma.Command;
using Optoma.Global;
using UnityEngine.Video;
using System.IO;

namespace Optoma.FileManager
{
    /// <summary>
    ///  改变物体自身的图片
    /// </summary>
    public class ChangeTextureScript : MonoBehaviour
    {
        #region 属性变量
        /// <summary>
        ///  RawImage物体
        /// </summary>
        private RawImage rawImage;
        /// <summary>
        ///  视频播放物体
        /// </summary>
        private VideoPlayer videoPlayer;
        #endregion

        #region Unity Callback
        private void Awake()
        {
            // RawImage物体
            rawImage = gameObject.GetComponent<RawImage>();
            // 初始化videoPlayer物体
            videoPlayer = gameObject.GetComponent<VideoPlayer>();
            // 初始化视频文件设置
            VideoPlayerInit();
        }

        private void Start()
        {
            // 添加图片切换的事件监听
            EventCenter.AddListener<OpenFileName>(GlobalConfig.EnumTypesManager.EventTypes.ChooseTexture,
                ChangeTextureFileFunction);
            // 添加视频切换的事件监听
            EventCenter.AddListener<OpenFileName>(GlobalConfig.EnumTypesManager.EventTypes.ChooseMovie,
                ChangeVideoFileFunction);
        }
        #endregion

        #region 方法
        /// <summary>
        ///  初始化视频文件设置
        /// </summary>
        private void VideoPlayerInit()
        {
            videoPlayer.source = VideoSource.Url;
            videoPlayer.playOnAwake = false;
            videoPlayer.renderMode = VideoRenderMode.RenderTexture;
            // 将renderTexture附在RawImage
            videoPlayer.targetTexture = Resources.Load(
                GlobalConfig.GameObjectTagsAndNamesManager.VideoPlayerRenderTextureName) as RenderTexture;
            Debug.Log("添加renderTexture");
        }

        /// <summary>
        /// 切换图片显示方法
        /// </summary>
        /// <param name="openFileName">要选择的文件信息</param>
        private void ChangeTextureFileFunction(OpenFileName openFileName)
        {
            // videoPlayer.enabled = false;
            /// 加载图片
            StartCoroutine(DownloadTextureFunction(openFileName.file, rawImage));
        }

        /// <summary>
        ///  切换视频显示方法
        /// </summary>
        /// <param name="openFileName"></param>
        private void ChangeVideoFileFunction(OpenFileName openFileName)
        {
            // 将renderTexture附在RawImage
            rawImage.texture = Resources.Load(
                GlobalConfig.GameObjectTagsAndNamesManager.VideoPlayerRenderTextureName) as Texture;
            Debug.Log("添加renderTexture");
            videoPlayer.url = openFileName.file;
            if (videoPlayer.url != null)
            {
                // 进行播放
                videoPlayer.Play();
                Debug.Log("播放视频： " + openFileName.file);
            }

        }

        /// <summary>
        ///  下载图片
        /// </summary>
        /// <param name="fileUrl">文件路径</param>
        /// <param name="texture">图片</param>
        /// <returns></returns>
        private IEnumerator DownloadTextureFunction(string fileUrl,RawImage texture)
        {
            WWW www = new WWW(fileUrl);
            yield return www;
            if (www != null && string.IsNullOrEmpty(www.error))
            {
                 texture.texture = www.texture;
                 Debug.Log("切换图片： " + fileUrl);
            }
        }


       
        #endregion
    }
}