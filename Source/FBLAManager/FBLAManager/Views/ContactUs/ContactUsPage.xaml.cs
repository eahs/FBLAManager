﻿using FBLAManager.Models;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace FBLAManager.Views.ContactUs
{
    /// <summary>
    /// Page to contact with user name, email and message
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactUsPage
    {
        private double frameWidth;


        /// <summary>
        /// Initializes a new instance of the <see cref="ContactUsPage" /> class.
        /// </summary>
        public ContactUsPage()
        {
            
            InitializeComponent();
        }

        /// <summary>
        /// Invoked when view size is changed.
        /// </summary>
        /// <param name="width">The Width</param>
        /// <param name="height">The Height</param>
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width > height)
            {
                if (Device.Idiom == TargetIdiom.Desktop || Device.Idiom == TargetIdiom.Tablet)
                {
                    this.frameWidth = width / 2;
                    MainStack.Orientation = StackOrientation.Horizontal;
                    MainFrame.VerticalOptions = LayoutOptions.FillAndExpand;
                    MainFrame.Margin = new Thickness(0);
                    MainFrame.CornerRadius = 0;
                    MainFrame.HasShadow = false;
                    MainFrameStack.VerticalOptions = LayoutOptions.StartAndExpand;
                    if (this.frameWidth > 0)
                    {
                        MainFrame.WidthRequest = this.frameWidth;
                        Map.WidthRequest = this.frameWidth;
                    }
                }
                else
                {
                    this.DefaultStyle(height);
                }
            }
            else
            {
                this.DefaultStyle(height);
            }
        }

        /// <summary>
        /// This default style method is called when the device is portrait mode.
        /// This method is also called when the android and ios devices are landscape mode
        /// </summary>
        /// <param name="height">The height</param>
        private void DefaultStyle(double height)
        {
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                MainFrame.HeightRequest = height / 2;
                Map.HeightRequest = height / 2;
                MainStack.Orientation = StackOrientation.Vertical;
                MainFrame.VerticalOptions = LayoutOptions.End;
                MainFrame.Margin = new Thickness(0);
                MainFrame.CornerRadius = 0;
                MainFrame.HasShadow = false;
                MainFrameStack.VerticalOptions = LayoutOptions.StartAndExpand;
                MainFrameStack.Margin = new Thickness(20, 0, 20, 0);
            }
            else
            {
                MainStack.Orientation = StackOrientation.Vertical;
                MainFrame.VerticalOptions = LayoutOptions.End;
                MainFrame.Margin = new Thickness(15, -50, 15, 15);
                MainFrameStack.VerticalOptions = LayoutOptions.EndAndExpand;
                MainFrame.CornerRadius = 5;
                MainFrame.HasShadow = true;
                MainFrameStack.Margin = new Thickness(0);
            }
        }

        private async void OnEmailClicked(object sender, EventArgs args)
        {
            await SendEmail();

            BodyControl.Text = "";
        }

        //sends email to member's email address with blank subject and body
        public async Task SendEmail()
        {
            var recip = new List<string>();

            if (RecipPicker.SelectedIndex == 2)
            {
                recip.Add("localEmailaddress");
            }
            else if (RecipPicker.SelectedIndex == 1)
            {
                recip.Add("stateEmailaddress");
            }
            else if (RecipPicker.SelectedIndex == 0)
            {
                recip.Add("nationalEmailaddress");
            }

            await SendEmail(BodyControl.Text, recip);
        }

        //sends email through default email app
        public async Task SendEmail(string body, List<string> recipients)
        {
            try
            {
                var message = new EmailMessage
                {
                    Body = body,
                    To = recipients,
                };
                await Email.ComposeAsync(message);
            }
            catch (Exception e)
            {
                var properties = new Dictionary<string, string> {
                    { "Category", "ContactUs" }
                  };
                Crashes.TrackError(e, properties);

            }
        }
    }
}