using FBLAManager.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

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
    }
}