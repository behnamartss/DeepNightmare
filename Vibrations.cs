﻿//using UnityEngine;
//using System.Collections;

//public static class Vibration
//{

//#if UNITY_ANDROID && !UNITY_EDITOR
//    public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
//    public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
//    public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
//#else
//    public static AndroidJavaClass unityPlayer;
//    public static AndroidJavaObject currentActivity;
//    public static AndroidJavaObject vibrator;
//#endif

//    public static void Vibrate()
//    {
//        if (isAndroid())
//            vibrator.Call("vibrate");
//        else
//            Handheld.Vibrate();
//    }


//    public static void Vibrate(long milliseconds)
//    {
//        if (isAndroid())
//            vibrator.Call("vibrate", milliseconds);
//        else
//            Handheld.Vibrate();
//    }

//    public static void Vibrate(long[] pattern, int repeat)
//    {
//        if (isAndroid())
//            vibrator.Call("vibrate", pattern, repeat);
//        else
//            Handheld.Vibrate();
//    }

//    public static bool HasVibrator()
//    {
//        return isAndroid();
//    }

//    public static void Cancel()
//    {
//        if (isAndroid())
//            vibrator.Call("cancel");
//    }

//    private static bool isAndroid()
//    {
//#if UNITY_ANDROID && !UNITY_EDITOR
//	return true;
//#else
//        return false;
//#endif
//    }
//}

////using UnityEngine;
////#if UNITY_IOS && !UNITY_EDITOR
////using System.Collections;
////using System.Runtime.InteropServices;
////#endif

////public static class Vibration
////{
////#if UNITY_IOS && !UNITY_EDITOR
////    [DllImport ( "__Internal" )]
////    private static extern bool _HasVibrator ();

////    [DllImport ( "__Internal" )]
////    private static extern void _Vibrate ();

////    [DllImport ( "__Internal" )]
////    private static extern void _VibratePop ();

////    [DllImport ( "__Internal" )]
////    private static extern void _VibratePeek ();

////    [DllImport ( "__Internal" )]
////    private static extern void _VibrateNope ();

////    ///<summary>
////    ///Only on iOS
////    ///</summary>
////    public static void VibratePop ()
////    {
////        _VibratePop ();
////    }

////    ///<summary>
////    ///Only on iOS
////    ///</summary>
////    public static void VibratePeek ()
////    {
////        _VibratePeek ();
////    }

////    ///<summary>
////    ///Only on iOS
////    ///</summary>
////    public static void VibrateNope ()
////    {
////        _VibrateNope ();
////    }
////#endif

////#if UNITY_ANDROID && !UNITY_EDITOR
////	public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
////	public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
////	public static AndroidJavaObject vibrator =currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
////	public static AndroidJavaObject context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");

////	///<summary>
////	/// Only on Android
////	/// https://developer.android.com/reference/android/os/Vibrator.html#vibrate(long)
////	///</summary>

////    public static void Vibrate(long milliseconds)
////    {
////        vibrator.Call("vibrate", milliseconds);
////    }

////    ///<summary>
////    /// Only on Android
////    /// https://proandroiddev.com/using-vibrate-in-android-b0e3ef5d5e07
////    ///</summary>
////    public static void Vibrate(long[] pattern, int repeat)
////    {
////        vibrator.Call("vibrate", pattern, repeat);
////    }

////    ///<summary>
////    ///Only on Android
////    ///</summary>
////    public static void Cancel()
////    {
////        vibrator.Call("cancel");
////    }

////#endif
////    public static bool HasVibrator()
////    {
////#if UNITY_ANDROID && !UNITY_EDITOR
////		AndroidJavaClass contextClass = new AndroidJavaClass("android.content.Context");
////		string Context_VIBRATOR_SERVICE = contextClass.GetStatic<string>("VIBRATOR_SERVICE");
////		AndroidJavaObject systemService = context.Call<AndroidJavaObject>("getSystemService", Context_VIBRATOR_SERVICE);
////		if (systemService.Call<bool>("hasVibrator"))
////		{
////			return true;
////		}
////		else
////		{
////			return false;
////		}
////#elif UNITY_IOS && !UNITY_EDITOR
////        return _HasVibrator ();
////#else
////        return false;
////#endif
////    }

////    public static void Vibrate()
////    {
////#if UNITY_EDITOR
////        Debug.Log("Bzzzt! Cool vibration!");
////#endif
////        Handheld.Vibrate();
////    }
////}