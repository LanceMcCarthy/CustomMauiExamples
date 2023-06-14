#if ANDROID
using System.Diagnostics;
using Android.Webkit;
using Microsoft.Maui.Handlers;
using CustomReportViewer.Controls;
using static Android.Views.ViewGroup;

namespace CustomReportViewer.Handlers
{
    public partial class MauiReportViewerHandler: ViewHandler<MauiReportViewer, AndroidReportViewer>
    {
        protected override AndroidReportViewer CreatePlatformView()
        {
            var platformView = new AndroidReportViewer(Context, VirtualView)
            {
                LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent),
                VerticalScrollBarEnabled = false,
                HorizontalScrollBarEnabled = false
            };

            platformView.SetWebViewClient(new WebViewClient());
            platformView.SetWebChromeClient(new WebChromeClient());

            platformView.Settings.JavaScriptEnabled = true;
            platformView.Settings.DomStorageEnabled = true;
            platformView.Settings.JavaScriptCanOpenWindowsAutomatically = true;
            platformView.Settings.MediaPlaybackRequiresUserGesture = false;
            platformView.Settings.SetSupportMultipleWindows(true);
            
            return platformView;
        }

        public bool IsInitialized { get; private set; }

        protected override void ConnectHandler(AndroidReportViewer platformView)
        {
            base.ConnectHandler(platformView);

            platformView.LoadReportViewer();

            IsInitialized = true;
        }

        protected override void DisconnectHandler(AndroidReportViewer platformView)
        {
            base.DisconnectHandler(platformView);

            platformView.Dispose();
        }

        public static void MapRestServiceUrl(MauiReportViewerHandler handler, MauiReportViewer viewer)
        {
            handler.PlatformView.UpdateRestServiceUrl(viewer.RestServiceUrl);
           
            if(handler.IsInitialized)
            {
                Debug.WriteLine($"MapRestServiceUrl called");
                handler.PlatformView.LoadReportViewer();
            }
        }

        public static void MapReportName(MauiReportViewerHandler handler, MauiReportViewer viewer)
        {
            handler.PlatformView.UpdateReportName(viewer.ReportName);

            if(handler.IsInitialized)
            {
                Debug.WriteLine($"MapReportName called");
                handler.PlatformView.LoadReportViewer();
            }
        }
    }
}
#endif