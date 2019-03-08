using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Optoma.Global;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<RawImage>().texture = 
            Resources.Load(GlobalConfig.GameObjectTagsAndNamesManager.VideoPlayerRenderTextureName) as Texture;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(DownloadTextureFunction("C:\\Users\\hy\\Pictures\\Image\\01.png",
                gameObject.GetComponent<RawImage>()));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            gameObject.GetComponent<RawImage>().texture =
           Resources.Load(GlobalConfig.GameObjectTagsAndNamesManager.VideoPlayerRenderTextureName) as Texture;
        }
    }

    /// <summary>
    ///  下载图片
    /// </summary>
    /// <param name="fileUrl">文件路径</param>
    /// <param name="texture">图片</param>
    /// <returns></returns>
    private IEnumerator DownloadTextureFunction(string fileUrl, RawImage texture)
    {
        WWW www = new WWW(fileUrl);
        yield return www;
        if (www != null && string.IsNullOrEmpty(www.error))
        {
            texture.texture = www.texture;
            Debug.Log("切换图片： " + fileUrl);
        }
    }
}
