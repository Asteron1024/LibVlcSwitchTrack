using LibVLCSharp.Shared;
using System;
using System.Windows;
using MediaPlayer = LibVLCSharp.Shared.MediaPlayer;

namespace LibVlcSwitchTrack
{

    public partial class MainWindow : Window
    {
        private LibVLC _libVLC;
        private MediaPlayer _mediaPlayer;

        public MainWindow()
        {
            InitializeComponent();

            Core.Initialize();

            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);

            VideoView.Loaded += (sender, e) => VideoView.MediaPlayer = _mediaPlayer;
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (!VideoView.MediaPlayer.IsPlaying)
            {
                var uri = new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4");
                using (var media = new Media(_libVLC, uri))
                    VideoView.MediaPlayer.Play(media);
            }
        }

        private void Audio0_Click(object sender, RoutedEventArgs e)
        {
            VideoView.MediaPlayer.SetAudioTrack(0);
        }

        private void Audio1_Click(object sender, RoutedEventArgs e)
        {
            VideoView.MediaPlayer.SetAudioTrack(-1);
        }
    }
}
