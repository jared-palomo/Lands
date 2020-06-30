﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FFImageLoading.Forms.Platform;
using Android.Graphics;
//using Plugin.Permissions;
using System.IO;

namespace Lands.Droid
{
    [Activity(
        Label = "Lands", 
        Icon = "@mipmap/icon", 
        Theme = "@style/MainTheme", 
        MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            
            CachedImageRenderer.Init(true);

            //
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Activity = this;

            //Set DB root
            string dbName = "Lands.db3";
            string dbBinder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string dbRoot = System.IO.Path.Combine(dbBinder, dbName);

            //Initialized Builder
            LoadApplication(new App(dbRoot));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}