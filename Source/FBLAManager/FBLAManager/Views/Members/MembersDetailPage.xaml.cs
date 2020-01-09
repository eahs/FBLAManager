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

        //called when mail buttons clicked
        private async void OnMailClicked(object sender, EventArgs args)
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
    }
}