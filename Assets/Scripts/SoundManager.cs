using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// サウンドの管理クラス
/// </summary>
public class SoundManager : MonoBehaviour
{
    static SoundManager instance;
    public static SoundManager Instance {
        get { return instance; }
    }

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    List<AudioClip> bgmList = new List<AudioClip>();

    /// <summary>
    /// 効果音
    /// </summary>
    [SerializeField]
    List<AudioClip> seList = new List<AudioClip>();

    /// <summary>
    /// BGM用のAudioSource
    /// </summary>
    static AudioSource sourceBGM;

    /// <summary>
    /// SE用のAudioSource
    /// </summary>
    AudioSource sourceSE;

    void Awake()
    {
        // 継承元のシングルトンクラスの為の処理
        if (instance == null) {
            instance = this;
        }
        sourceBGM = gameObject.AddComponent<AudioSource>();
        sourceBGM.loop = true;

        sourceSE  = gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
    }

    /// <summary>
    /// BGMの再生
    /// </summary>
    /// <param name="index">BGMの配列のインデックス</param>
    public void playBGM(int index)
    {
        if (bgmList.Count <= index) { return; }

        sourceBGM.Stop();

        sourceBGM.clip = bgmList[index];
        sourceBGM.Play();
    }

    /// <summary>
    /// SEを重ねて再生
    /// </summary>
    /// <param name="index">SEの配列のインデックス</param>
    public void playOverapSE(int index)
    {
        if (seList.Count <= index) { return; }

        sourceSE.PlayOneShot(seList[index]);
    }

    public void playSE(int index)
    {
        if (seList.Count <= index) { return; }

        sourceSE.clip = seList[index];
        sourceSE.Play();
    }
}
