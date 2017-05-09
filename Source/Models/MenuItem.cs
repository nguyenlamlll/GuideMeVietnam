using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Models
{
    public class MenuItem
    {
        public string IconFile { get; set; }
        public MenuItemCategory Category { get; set; }
    }

    public enum MenuItemCategory
    {
        //MenuItems for main navigation menu
        Homepage,
        Map,
        Settings,
        Posts,
        Photos,
        About,
        Lists,
        //MenuItems for Menu "About"
        Help,
        Credits,

    }
    public class MenuItemManager
    {
        public static List<MenuItem> GetMenuItems()
        {
            var items = new List<MenuItem>();
            items.Add(new MenuItem { IconFile = "\uE10F", Category = MenuItemCategory.Homepage });
            items.Add(new MenuItem { IconFile = "\uE909", Category = MenuItemCategory.Map });
            items.Add(new MenuItem { IconFile = "\uE115", Category = MenuItemCategory.Settings });
            items.Add(new MenuItem { IconFile = "\uE14C", Category = MenuItemCategory.Lists });
            return items;
        }
        public static List<MenuItem> GetAboutMenuItems()
        {
            var items = new List<MenuItem>();
            items.Add(new MenuItem { });
            return items;
        }
    }

}
