using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
public class AD_Banner : MonoBehaviour
{

    private BannerView bannerView;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        this.RequestBanner();
    }

    private void RequestBanner()
    {
        #if UNITY_ANDROID
        string adUnitId = "ca-app-pub-80922690279757/5979887708";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }
}


/*
https://github.com/googleads/googleads-mobile-unity/releases/

https://developers.google.com/admob/unity/quick-start

google play console account
https://play.google.com/console/

*/