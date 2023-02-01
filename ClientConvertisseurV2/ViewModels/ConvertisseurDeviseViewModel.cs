using ClientConvertisseurV2.Models;
using ClientConvertisseurV2.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.ViewModels
{
    public class ConvertisseurDeviseViewModel: ConvertisseurBase
    {
        public IRelayCommand BtnSetConversion { get; }

        public ConvertisseurDeviseViewModel()
        {
            GetDataOnLoadAsync();
            BtnSetConversion = new RelayCommand(ActionSetConversion);
        }

        public void ActionSetConversion()
        {
            if (ChampSelectDevise != null)
                VResult = Math.Round(Devise.ConvertDeviseToEuro(VStart, ChampSelectDevise), 2);
            else
                ShowAsync("Aucune devise de selectionée.");
        }  

    }
}
