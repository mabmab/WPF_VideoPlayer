// 動画再生に関して以下を参照しました
// http://thinkit.co.jp/article/16/4/3.html

using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        //=============================================================================
        // コンストラクター
        //=============================================================================

        /// <summary>
        /// コンストラクター
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        //=============================================================================
        // イベントハンドラー
        //=============================================================================

        /// <summary>
        /// メディア初期化完了イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnMediaElement1Initialized(object sender, EventArgs args)
        {
            try
            {
                // 音声ボリュームスライダーの初期化
                sliderVol.Value = MediaElement1.Volume;
            }
            catch
            {
                Debug.Assert(false, MethodBase.GetCurrentMethod().Name + "で例外が発生しました");
            }
        }

        /// <summary>
        /// メディアオープン完了イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnMediaElement1MediaOpened(object sender, RoutedEventArgs args)
        {
            try
            {
                // 再生位置スライダーの初期化
                sliderPos.Maximum = MediaElement1.NaturalDuration.TimeSpan.TotalMilliseconds;
            }
            catch
            {
                Debug.Assert(false, MethodBase.GetCurrentMethod().Name + "で例外が発生しました");
            }
        }

        /// <summary>
        /// 再生ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnPlayButtonClick(object sender, RoutedEventArgs args)
        {
            try
            {
                // メディア再生
                MediaElement1.Play();
            }
            catch
            {
                Debug.Assert(false, MethodBase.GetCurrentMethod().Name + "で例外が発生しました");
            }
        }

        /// <summary>
        /// 一時停止ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnPauseButtonClick(object sender, RoutedEventArgs args)
        {
            try
            {
                // メディア一時停止
                MediaElement1.Pause();
            }
            catch
            {
                Debug.Assert(false, MethodBase.GetCurrentMethod().Name + "で例外が発生しました");
            }
        }

        /// <summary>
        /// 再生停止ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnStopButtonClick(object sender, RoutedEventArgs args)
        {
            try
            {
                // メディア再生停止
                MediaElement1.Stop();
            }
            catch
            {
                Debug.Assert(false, MethodBase.GetCurrentMethod().Name + "で例外が発生しました");
            }
        }

        /// <summary>
        /// 音声ボリューム可変イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnVolumeSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            try
            {
                MediaElement1.Volume = sliderVol.Value;
            }
            catch
            {
                Debug.Assert(false, MethodBase.GetCurrentMethod().Name + "で例外が発生しました");
            }
        }

        /// <summary>
        /// 再生位置変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnPositionSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            try
            {
                // https://msdn.microsoft.com/ja-jp/library/system.windows.controls.mediaelement.position(v=vs.110).aspx
                {
                    int SliderValue = (int)sliderPos.Value;

                    // Overloaded constructor takes the arguments days, hours, minutes, seconds, miniseconds.
                    // Create a TimeSpan with miliseconds equal to the slider value.
                    TimeSpan ts = new TimeSpan(0, 0, 0, 0, SliderValue);
                    MediaElement1.Position = ts;
                }
            }
            catch
            {
                Debug.Assert(false, MethodBase.GetCurrentMethod().Name + "で例外が発生しました");
            }
        }
    }
}
