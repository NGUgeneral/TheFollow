using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFollow.Models;
using TheFollow.Helpers;

namespace TheFollow.Helpers
{
    static class InventoryHelper
    {
        public static void AddItemToInventory(Item item)
        {
            GameInstance.Instance.CurrentPlayer.Inventory.Add(item);
            ConsoleHelper.LogUserMessage("{0} has been added to you inventory", item.Specifier);
        }

        public static void RemoveItemToInventory(Item item)
        {
            GameInstance.Instance.CurrentPlayer.Inventory.Remove(item);
            ConsoleHelper.LogUserMessage("{0} has been removed from your inventory", item.Specifier);
        }
    }
}
