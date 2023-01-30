using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConvertisseurV2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientConvertisseurV2.Models;
using System.Collections.ObjectModel;

namespace ClientConvertisseurV2.ViewModels.Tests
{
    [TestClass()]
    public class ConvertisseurEuroViewModelTests
    {
        /// <summary>
        /// Test constructeur.
        /// </summary>
        [TestMethod()]
        public void ConvertisseurEuroViewModelTest()
        {
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();
            Assert.IsNotNull(convertisseurEuro);
        }


        [TestMethod()]
        public void ActionSetConversionTest()
        {
            //Arrange
            //Création d'un objet de type ConvertisseurEuroViewModel
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();
            //Property MontantEuro = 100 (par exemple)
            convertisseurEuro.VStart = 100;

            //Création d'un objet Devise, dont Taux=1.07
            //Property DeviseSelectionnee = objet Devise instancié
            Devise dT = new Devise(10, "Test", 1.07);

            //Act
            //Appel de la méthode ActionSetConversion
            convertisseurEuro.ActionSetConversion();

            //Assert
            //Assertion : MontantDevise est égal à la valeur espérée 107
            Assert.AreEqual(Devise.ConvertEuroToDevise(convertisseurEuro.VStart, dT),107);


        }

        /// <summary>
        /// Test GetDataOnLoadAsyncTest OK
        /// </summary>
        [TestMethod()]
        public void GetDataOnLoadAsyncTest_OK()
        {
            Thread.Sleep(1000);
            //Arrange
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();
            //Act
            convertisseurEuro.GetDataOnLoadAsync();
            //Assert
            Assert.IsNotNull(convertisseurEuro.Devises);

            ObservableCollection<Devise> devisesTest = new ObservableCollection<Devise>();
            devisesTest.Add(new Devise(1, "Dollar", 1.08));
            devisesTest.Add(new Devise(2, "Franc Suisse", 1.07));
            devisesTest.Add(new Devise(3, "Yen", 120));

            CollectionAssert.AreEqual(devisesTest, convertisseurEuro.Devises);            
        }



    }
}