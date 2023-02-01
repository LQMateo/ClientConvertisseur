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
    public class ConvertisseurEuroViewModel: ConvertisseurBase
    {
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

    }
}
