using FBLAManager.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace FBLAManager.Views.Members
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MembersDetailPage : ContentPage
    {
        private Member Member { get; set; }

        public MembersDetailPage(Member member)
        {
            InitializeComponent();

            this.Member = member;

            BindingContext = member;


        }

        #region Email

        //called when email button clicked
        private async void OnEmailClicked(object sender, EventArgs args)
        {
            await SendEmail();
        }

        //sends email to member's email address with blank subject and body
        public async Task SendEmail()
        {
            var recip = new List<string>();
            recip.Add(Member.Email);

            await SendEmail(string.Empty, string.Empty, recip);
        }

        //sends email through default email app
        public async Task SendEmail(string subject, string body, List<string> recipients)
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    To = recipients,
                    //Cc = ccRecipients,
                    //Bcc = bccRecipients
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device
            }
            catch (Exception ex)
            {
                // Some other exception occurred
            }
        }


        #endregion

        #region Message

        //called when dial button clicked
        public async void OnMessageClicked(object sender, EventArgs args)
        {
            await SendSms(string.Empty, Member.Phone); 
        }

        public async Task SendSms(string messageText, string recipient)
        {
            try
            {
                var message = new SmsMessage(messageText, new[] { recipient });
                await Sms.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException ex)
            {
                // Sms is not supported on this device.
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }

        #endregion

        #region Dial

        public void OnDialClicked(object sender, EventArgs args)
        {
            PlacePhoneCall(Member.Phone);
        }

        public void PlacePhoneCall(string number)
        {
            try
            {
                PhoneDialer.Open(number);
            }
            catch (ArgumentNullException anEx)
            {
                // Number was null or white space
            }
            catch (FeatureNotSupportedException ex)
            {
                // Phone Dialer is not supported on this device.
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }

        #endregion

    }
}