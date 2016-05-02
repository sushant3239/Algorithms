using SQLite.Net.Attributes;
using System.Collections.Generic;

namespace OfflineSync.Core.Model
{
    public class Token_
    {
        public string Token { get; set; }
    }

    public class AdditionalDetail
    {
        public string IsFconnect { get; set; }
        public string IsMyPayments { get; set; }
        public string IsTermsWeb { get; set; }
        public string TermsURL { get; set; }
        public string BarCodeWidth { get; set; }
        public string BarCodeHeight { get; set; }
        public string barcodeURL { get; set; }
        public string Type { get; set; }
        public string IsVenueLock { get; set; }
        public string AllMenuEnabled { get; set; }
        public string hasOffers { get; set; }
        public string NPSTransCount { get; set; }
        public string NPSDaysCount { get; set; }
        public string WalletPromoText { get; set; }
        public string PEFlag { get; set; }
        public string PETimeout { get; set; }
        public string actual_referral_amt { get; set; }
        public string max_referral_amt { get; set; }
        public string referral_share_msg { get; set; }
        public string show_referral_intro { get; set; }
        public string AppAdvURL { get; set; }
        public string BannerAdKey { get; set; }
        public string BannerAdvURL { get; set; }
        public string referralPopupText { get; set; }
        public string isReferralEnabled { get; set; }
        public string referral_home_screen_msg { get; set; }
        public string referral_share_msg_label { get; set; }
        public string referral_details_share_desc { get; set; }
        public string referral_details_other_desc { get; set; }
        public string maxUnpaidCancelChance { get; set; }
        public string cutOffShowTime { get; set; }
        public string unpaidQuotaText { get; set; }
        public string showUnpaid { get; set; }
        public string showCod { get; set; }
        public string BaseContentUrl { get; set; }
    }

    public class SeatRangeDetail
    {
        public string SeatRange { get; set; }
        public string SeatMsgText { get; set; }
    }

    public class TabDetail
    {
        public string TabName { get; set; }
        public string Sequence { get; set; }
    }

    public class Image
    {
        public int width { get; set; }
        public int height { get; set; }
        public string AdImageUrl { get; set; }
        public string AdImageUrl_WIN { get; set; }
    }

    public class Banners
    {
        public string AdImageUrl { get; set; }
        public string AdImageUrl_AND { get; set; }
        public string AdImageUrl_WIN { get; set; }
        public string Type { get; set; }
        public string AdKey { get; set; }
        public string IsActive { get; set; }
        
        [Ignore]
        public List<string> Screens { get; set; }
        [Ignore]
        public List<Image> Images { get; set; }
    }

    public class Image2
    {
        public int width { get; set; }
        public int height { get; set; }
        public string AdImageUrl { get; set; }
    }

    public class AdDetail
    {
        public string CanSkipAd { get; set; }
        public int Time { get; set; }
        public int Ad_Interval { get; set; }
        public string Skip_Color { get; set; }
        public string AdImageUrl { get; set; }
        public string AdImageUrl_AND { get; set; }
        public string AdImageUrl_WIN { get; set; }
        public string IsActive { get; set; }
        public string AdMode { get; set; }
        public string AdKey { get; set; }
        public List<Banners> arrOfferBanners { get; set; }
        public List<Image2> Images { get; set; }
    }

    public class BookMyShow
    {
        public List<Token_> Token { get; set; }
        public List<AdditionalDetail> AdditionalDetails { get; set; }
        public List<SeatRangeDetail> SeatRangeDetails { get; set; }
        public List<TabDetail> TabDetails { get; set; }
        public List<AdDetail> AdDetails { get; set; }
    }

    public class RootResponse
    {
        public BookMyShow BookMyShow { get; set; }
    }
}
