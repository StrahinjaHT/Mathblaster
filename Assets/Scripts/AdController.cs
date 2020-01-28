using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class AdController : MonoBehaviour
{
    public static AdController instance;
    private string gameId = "3443841";

    private string videoAd = "video";
    private string rewardedVideoAd = "rewardedVideo";
    private string bannerAd = "BannerAd";

    private void Awake()
    {
        if(instance!=null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Monetization.Initialize(gameId, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowVideoAd()
    {
        if(Monetization.IsReady(videoAd))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(videoAd) as ShowAdPlacementContent;

            if(ad!=null)
            {
                ad.Show();
            }
            
        }

    }
    public void ShowRewardedVideoAd()
    {
        if (Monetization.IsReady(rewardedVideoAd))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(rewardedVideoAd) as ShowAdPlacementContent;

            if (ad != null)
            {
                ad.Show();
            }
        }
    }
    public void ShowBannerVideoAd()
    {
        if (Monetization.IsReady(bannerAd))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(bannerAd) as ShowAdPlacementContent;

            if (ad != null)
            {
                ad.Show();
            }
        }
    }
}
