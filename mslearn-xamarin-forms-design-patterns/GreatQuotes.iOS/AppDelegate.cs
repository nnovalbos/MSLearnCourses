﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Foundation;
using GreatQuotes.Contracts;
using GreatQuotes.Loaders;
using GreatQuotes.ViewModels;
using UIKit;

namespace GreatQuotes.iOS {
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
       
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
           
            global::Xamarin.Forms.Forms.Init();
            QuoteLoaderFactory.Create = () => new QuoteLoader();

            ServiceLocator.Instance.Add<ITextToSpeech, TextToSpeechService>();

            LoadApplication(new App());

            

            return base.FinishedLaunching(uiApplication, launchOptions);
        }

    }
}
