using UnityEngine;
using UnityEngine.Advertisements;

public class AdController : MonoBehaviour,IUnityAdsListener
{
    public static AdController instance;
    private string gameId = "3443841";

    private string videoAd = "video";
    private string rewardedVideoAd = "rewardedVideo";
    //private string bannerAd = "BannerAd";

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
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowVideoAd()
    {
        if(Advertisement.IsReady(videoAd))
        {

            Advertisement.Show(videoAd);
            
        }

    }
    public void ShowRewardedVideoAd()
    {
        if (Advertisement.IsReady(rewardedVideoAd))
        {
            Advertisement.Show(rewardedVideoAd);
        }
    }
    
    public bool RewardedVideoIsReady()
    {
        if (Advertisement.IsReady(rewardedVideoAd))
        {
            return true;
        }
        return false;
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            // Reward the user for watching the ad to completion.
            if(placementId==rewardedVideoAd)
            FindObjectOfType<GameSession>().UpdateScoreByRandomAmount();
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }
}
