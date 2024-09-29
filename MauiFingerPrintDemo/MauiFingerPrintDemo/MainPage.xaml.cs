﻿using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;

namespace MauiFingerPrintDemo
{
    public partial class MainPage : ContentPage
    {
        private readonly IFingerprint fingerprint;

        public MainPage(IFingerprint fingerprint)
        {
            InitializeComponent();
            this.fingerprint = fingerprint;
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var request = new AuthenticationRequestConfiguration("Prove you have fingers!",
                "Because without it you can't have access");
            var result = await CrossFingerprint.Current.AuthenticateAsync(request);
            if (result.Authenticated)
            {
                await DisplayAlert("Authenticated!", "Access granted", "Cool beans");
            }
            else
            {
                await DisplayAlert("Not authenticated!", "Access denied", "aww");
            }
        }
    }

}
