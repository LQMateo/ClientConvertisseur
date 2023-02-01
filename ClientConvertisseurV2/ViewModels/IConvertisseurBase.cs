using ClientConvertisseurV2.Models;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ClientConvertisseurV2.ViewModels
{
    public interface IConvertisseurBase
    {
        Devise ChampSelectDevise { get; set; }
        ObservableCollection<Devise> Devises { get; set; }
        double VResult { get; set; }
        double VStart { get; set; }


        public void ActionSetConversion();
        void GetDataOnLoadAsync();
    }
}