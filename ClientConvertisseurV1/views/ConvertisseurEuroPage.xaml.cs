// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using ClientConvertisseurV1.models;
using ClientConvertisseurV1.services;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Portable;
using Windows.Foundation;
using Microsoft.Extensions.DependencyInjection;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ClientConvertisseurV1.views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConvertisseurEuroPage : Page, INotifyPropertyChanged
    {
        //Can use a proprety binding
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler? handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        // Variable for binding
        private double vStart;
        private double vResult;
        ObservableCollection<Devise> devises = new ObservableCollection<Devise>();
        public double VStart { get => vStart; set => vStart = value; }
        public double VResult { get => vResult; set { vResult = value; OnPropertyChanged("VResult");  } }
        public ObservableCollection<Devise> Devises { get => devises; set { devises = value; OnPropertyChanged("Devises"); } }
          
        // Get WS
        public IService? VWebService
        {
            get { return App.Current.Services.GetService<IService>(); }
        }

        public ConvertisseurEuroPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            GetDataOnLoadAsync();
        }
        


        private async void GetDataOnLoadAsync()
        {
            WSService ws = new WSService("");
            List<Devise> result = await ws.GetDevisesAsync("devises");
            if (result == null)
                ShowAsync("API non disponible");

            if (Devises != null)
                Devises = new ObservableCollection<Devise>(result);
        }

        private void Convertir_EuroToDevise(object sender, RoutedEventArgs e)
        {            
            Devise? laDeviseSelect = ChampSelectDevise.SelectedItem as Devise;

            if (laDeviseSelect == null)
                ShowAsync("Aucune devise de selectionnée.");
            else
            {
                VResult = Math.Round(Devise.ConvertEuroToDevise(VStart, laDeviseSelect), 2);
                Console.WriteLine(VResult);
            }
        }

        private async void ShowAsync(String message)
        {
            ContentDialog contentDialog = new ContentDialog
            {
                Title = "Erreur",
                Content = message,
                CloseButtonText = "Ok"
            };
            contentDialog.XamlRoot = this.Content.XamlRoot;
            ContentDialogResult result = await contentDialog.ShowAsync();
        }


    }
}
