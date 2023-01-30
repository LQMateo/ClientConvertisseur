using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientConvertisseurV2.Models;
using ClientConvertisseurV2.Services;
using CommunityToolkit.Mvvm.Input;

namespace ClientConvertisseurV2.ViewModels
{
    public class ConvertisseurEuroViewModel: ObservableObject
    {
        //Can use a proprety binding
        public event PropertyChangedEventHandler? PropertyChanged;
      
        // Variable for binding
        private double vStart;
        private double vResult;
        private Devise champSelectDevise;

        public Devise ChampSelectDevise
        {
            get { return champSelectDevise; }
            set { champSelectDevise = value; }
        }

        ObservableCollection<Devise> devises = new ObservableCollection<Devise>();
        public double VStart { get => vStart; set => vStart = value; }
        public double VResult { get => vResult; set { vResult = value; OnPropertyChanged(); } }
        public ObservableCollection<Devise> Devises { get => devises; set { devises = value; OnPropertyChanged(); } }


        public IRelayCommand BtnSetConversion { get; }   

        
        public void ActionSetConversion()
        {
            if (ChampSelectDevise != null)
                VResult = Math.Round(Devise.ConvertEuroToDevise(VStart, ChampSelectDevise), 2);
            else
                ShowAsync("Aucune devise de selectionée.");
      }

        public ConvertisseurEuroViewModel()
        {
            GetDataOnLoadAsync();
            BtnSetConversion = new RelayCommand(ActionSetConversion);
        }

        public async void GetDataOnLoadAsync()
        {
            WSService ws = new WSService("");
            List<Devise> result = await ws.GetDevisesAsync("devises");

            if (Devises != null)
                Devises = new ObservableCollection<Devise>(result);
            else
                ShowAsync("L'API ne fonctionne pas. ");
        }

        private async void ShowAsync(String message)
        {
            ContentDialog contentDialog = new ContentDialog
            {
                Title = "Erreur",
                Content = message,
                CloseButtonText = "Ok"
            };
            contentDialog.XamlRoot = App.MainRoot.XamlRoot;
            ContentDialogResult result = await contentDialog.ShowAsync();
        }

    }
}
