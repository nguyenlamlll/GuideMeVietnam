using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using VietTravel.DBModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Source.User_Interfaces
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            this.InitializeComponent();

            //using (var db = new VietTravel.VietTravelDBContext())
            //{
            //    db.ACCOUNTs.Add(new ACCOUNT() { userName = "acc1", pass = "123" });
            //    db.SaveChanges();

            //    foreach (var acc in db.ACCOUNTs)
            //    {
            //        Console.WriteLine(acc.userName);
            //    }
            //}
        }
    }
}
