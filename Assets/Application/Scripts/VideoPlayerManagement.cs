using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


namespace VideoManagement
{
    public class VideoPlayerManagement : MonoBehaviour, IVideoSeek, IVideoPrevNext
    {
        [SerializeField] private VideoPlayer _videoPlayer;
        [SerializeField] private AllVideos _allVideos;
        [SerializeField] private int _currentVideoIndex;

        public static Action lastVideoIsPlaying, firstVideoIsPlaying;

        public int videoSkipTime;
        public VideoPlayer VideoPlayer { get { return _videoPlayer; } }

        private void Awake()
        {
            _videoPlayer.source = VideoSource.VideoClip;
        }

        private void Init()
        {
            _videoPlayer.clip = _allVideos.Clips[0];
            _currentVideoIndex = 0;
        }

        public void Forward()
        {
            _videoPlayer.time += videoSkipTime;
        }

        public void Backward()
        {
            _videoPlayer.time -= videoSkipTime;
            
        }

        public void Next()
        {
            if (_currentVideoIndex >= _allVideos.Clips.Count-1)
            {
                Debug.LogError("No next video available");
                lastVideoIsPlaying?.Invoke();
                return;
            }
            _currentVideoIndex += 1;
            _videoPlayer.clip = _allVideos.Clips[_currentVideoIndex];
        }

        public void Previous()
        {
            if (_currentVideoIndex <= 0)
            {
                Debug.LogError("No previus video available");
                firstVideoIsPlaying?.Invoke();
                return;
            }
            _currentVideoIndex -= 1;
            _videoPlayer.clip = _allVideos.Clips[_currentVideoIndex];
        }
    }
}
