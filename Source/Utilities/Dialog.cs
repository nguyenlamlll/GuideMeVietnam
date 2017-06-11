using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Utilities
{
    public static class Dialog
    {
        /// <summary>
        /// Show a pop-up dialog (of the old Winform and WPF's style).
        /// </summary>
        /// <param name="content"></param>
        /// <param name="title"></param>
        /// <param name="option"></param>
        public static async void ShowDialog(string content, string title = "", DialogButtons option = 0)
        {
            var dialog = new Windows.UI.Popups.MessageDialog(content, title);

            if (option == DialogButtons.OK)
            {
                dialog.Commands.Add(new Windows.UI.Popups.UICommand("OK") { Id = 0 });
                dialog.DefaultCommandIndex = 0;
                //dialog.CancelCommandIndex = 1;
            }
            if (option == DialogButtons.YesNo)
            {
                dialog.Commands.Add(new Windows.UI.Popups.UICommand("Yes") { Id = 0 });
                dialog.Commands.Add(new Windows.UI.Popups.UICommand("No") { Id = 1 });
                dialog.DefaultCommandIndex = 0;
                dialog.CancelCommandIndex = 1;
            }
            if (option == DialogButtons.OKCancel)
            {
                dialog.Commands.Add(new Windows.UI.Popups.UICommand("OK") { Id = 0 });
                dialog.Commands.Add(new Windows.UI.Popups.UICommand("Cancel") { Id = 1 });
                dialog.DefaultCommandIndex = 0;
                dialog.CancelCommandIndex = 1;
            }

            var result = await dialog.ShowAsync();
        }

        public static void GetMapIconDialog()
        {

        }
    }
}
