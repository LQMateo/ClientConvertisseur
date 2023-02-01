using ClientConvertisseurV2.Models;
using ClientConvertisseurV2.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.ViewModels
{
    public abstract class ConvertisseurBase : ObservableObject, IConvertisseurBase
    {
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
                     
        public async void GetDataOnLoadAsync()
        {
            WSService ws = new WSService("");
            List<Devise> result = await ws.GetDevisesAsync("devises");

            if (Devises != null)
                Devises = new ObservableCollection<Devise>(result);
            else
                ShowAsync("L'API ne fonctionne pas. ");
        }

        

        protected async void ShowAsync(String message)
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

        public void ActionSetConversion()
        {
            throw new NotImplementedException();
        }
    }
}
