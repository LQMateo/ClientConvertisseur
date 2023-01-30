using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConvertisseurV2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ClientConvertisseurV2.Models;

namespace ClientConvertisseurV2.ViewModels.Tests
{
    [TestClass()]
    public class ConvertisseurDeviseViewModelTests
    {
        [TestMethod()]
        public void ActionSetConversionTest()
        {
            ConvertisseurDeviseViewModel convertisseurDevise = new ConvertisseurDeviseViewModel();
            Assert.IsNotNull(convertisseurDevise);
        }

        [TestMethod()]
        public void ConvertisseurDeviseViewModelTest()
        {
            //Arrange
            //Création d'un objet de type ConvertisseurEuroViewModel
            ConvertisseurDeviseViewModel convertisseurDevise = new ConvertisseurDeviseViewModel();
            //Property MontantEuro = 100 (par exemple)
            convertisseurDevise.VStart = 107;

            //Création d'un objet Devise, dont Taux=1.07
            //Property DeviseSelectionnee = objet Devise instancié
            Devise dT = new Devise(10, "Test", 1.07);

            //Act
            //Appel de la méthode ActionSetConversion
            convertisseurDevise.ActionSetConversion();

            //Assert
            //Assertion : MontantDevise est égal à la valeur espérée 107
            Assert.AreEqual(Devise.ConvertEuroToDevise(convertisseurDevise.VStart, dT), 100);
        }

        [TestMethod()]
        public void GetDataOnLoadAsyncTest()
        {
            Thread.Sleep(1000);
            //Arrange
            ConvertisseurDeviseViewModel convertisseurDevise = new ConvertisseurDeviseViewModel();
            //Act
            convertisseurDevise.GetDataOnLoadAsync();
            //Assert
            Assert.IsNotNull(convertisseurDevise.Devises);

            ObservableCollection<Devise> devisesTest = new ObservableCollection<Devise>();
            devisesTest.Add(new Devise(1, "Dollar", 1.08));
            devisesTest.Add(new Devise(2, "Franc Suisse", 1.07));
            devisesTest.Add(new Devise(3, "Yen", 120));

            CollectionAssert.AreEqual(devisesTest, convertisseurDevise.Devises);
        }
    }
}


