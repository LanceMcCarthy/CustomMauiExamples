using Microsoft.UI.Composition;
using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Xaml;
using WinRT;

namespace FlyoutExample.Platforms.Windows;

public static class WindowHelpers
{
    public static void TryMicaOrAcrylic(this Microsoft.UI.Xaml.Window window)
    {
        var dispatcherQueueHelper = new WindowsSystemDispatcherQueueHelper();
        dispatcherQueueHelper.EnsureWindowsSystemDispatcherQueueController();
        
        var configurationSource = new SystemBackdropConfiguration
        {
            IsInputActive = true
        };

        switch (((FrameworkElement)window.Content).ActualTheme)
        {
            case ElementTheme.Dark:
                configurationSource.Theme = SystemBackdropTheme.Dark;
                break;
            case ElementTheme.Light:
                configurationSource.Theme = SystemBackdropTheme.Light;
                break;
            case ElementTheme.Default:
                configurationSource.Theme = SystemBackdropTheme.Default;
                break;
        }

        MicaController micaController = null;
        DesktopAcrylicController acrylicController = null;
        
        if (MicaController.IsSupported()) // Let's try Mica first
        {
            micaController = new MicaController();
            micaController.AddSystemBackdropTarget(window.As<ICompositionSupportsSystemBackdrop>());
            micaController.SetSystemBackdropConfiguration(configurationSource);

            window.Activated += WindowActivated;
            window.Closed += WindowClosed;
        }
        else if (DesktopAcrylicController.IsSupported()) // If no Mica, maybe we can use Acrylic instead
        {
            acrylicController = new DesktopAcrylicController();
            acrylicController.AddSystemBackdropTarget(window.As<ICompositionSupportsSystemBackdrop>());
            acrylicController.SetSystemBackdropConfiguration(configurationSource);

            window.Activated += WindowActivated;
            window.Closed += WindowClosed;
        }

        void WindowActivated(object sender, WindowActivatedEventArgs args)
        {
            if (configurationSource != null)
                configurationSource.IsInputActive = args.WindowActivationState != WindowActivationState.Deactivated;
        }

        void WindowClosed(object sender, WindowEventArgs args)
        {
            if (acrylicController != null)
            {
                acrylicController.Dispose();
                acrylicController = null;
            }

            if (micaController != null)
            {
                micaController.Dispose();
                micaController = null;
            }

            configurationSource = null;
        }
    }
    
    //public static void PlacementCenterWindowInMonitorWin32(this Microsoft.UI.Xaml.Window window)
    //{
    //    IntPtr hwnd = WinRT.Interop.WindowNative.GetWindowHandle(window);

    //    PInvoke.RECT rc;
    //    PInvoke.User32.GetWindowRect(hwnd, out rc);

    //    ClipOrCenterRectToMonitorWin32(ref rc, true, true);

    //    PInvoke.User32.SetWindowPos(hwnd, PInvoke.User32.SpecialWindowHandles.HWND_TOP,
    //        rc.left, rc.top, 0, 0,
    //        PInvoke.User32.SetWindowPosFlags.SWP_NOSIZE |
    //        PInvoke.User32.SetWindowPosFlags.SWP_NOZORDER |
    //        PInvoke.User32.SetWindowPosFlags.SWP_NOACTIVATE);
    //}

    //public static AppWindow GetAppWindowForWinUI(this Microsoft.UI.Xaml.Window window)
    //{
    //    IntPtr nativeWindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
    //    WindowId win32WindowsId = Win32Interop.GetWindowIdFromWindow(nativeWindowHandle);
    //    AppWindow winuiAppWindow = AppWindow.GetFromWindowId(win32WindowsId);
    //    return winuiAppWindow;
    //}


    //// Private translations

    //private static void ClipOrCenterRectToMonitorWin32(ref PInvoke.RECT prc, bool UseWorkArea, bool IsCenter)
    //{
    //    IntPtr hMonitor;
    //    PInvoke.RECT rc;
    //    int w = prc.right - prc.left;
    //    int h = prc.bottom - prc.top;

    //    hMonitor = PInvoke.User32.MonitorFromRect(ref prc, PInvoke.User32.MonitorOptions.MONITOR_DEFAULTTONEAREST);

    //    PInvoke.User32.MONITORINFO mi = new PInvoke.User32.MONITORINFO();
    //    mi.cbSize = Marshal.SizeOf(mi);

    //    PInvoke.User32.GetMonitorInfo(hMonitor, ref mi);

    //    rc = UseWorkArea ? mi.rcWork : mi.rcMonitor;

    //    if (IsCenter)
    //    {
    //        prc.left = rc.left + (rc.right - rc.left - w) / 2;
    //        prc.top = rc.top + (rc.bottom - rc.top - h) / 2;
    //        prc.right = prc.left + w;
    //        prc.bottom = prc.top + h;
    //    }
    //    else
    //    {
    //        prc.left = Math.Max(rc.left, Math.Min(rc.right - w, prc.left));
    //        prc.top = Math.Max(rc.top, Math.Min(rc.bottom - h, prc.top));
    //        prc.right = prc.left + w;
    //        prc.bottom = prc.top + h;
    //    }
    //}
}
