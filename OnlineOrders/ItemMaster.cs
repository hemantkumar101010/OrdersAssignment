using OrdersData;
using OrdersData.Entities;

namespace OnlineOrders
{

    public class ItemMaster
    {
        CRUDManager obj = new();
        public string? ItemNameIs { get; set; }
        public int? ItemRateIs { get; set; }
        public int? ItemsQtyIs { get; set; }
        public void PrintValues()
        {
            Console.WriteLine("Printing all items");
            CRUDManager obj = new();
            foreach (Item i in obj.ListItems())
            {
                Console.WriteLine($"{i.ItemName}\t{i.ItemsRate}\t{i.ItemQty}");
            }
        }
        public void Insert()
        {
        ItemName:
            Console.WriteLine("Enter item name:");
            ItemNameIs = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(ItemNameIs))
            {
                Console.WriteLine("Item name should not be empty!");
                goto ItemName;
            }

        ItemRate:
            Console.WriteLine("Enter item rate:");
            string? itemRates = (Console.ReadLine());
            if (string.IsNullOrEmpty(itemRates))
            {
                Console.WriteLine("Item rate should not be empty!");

                goto ItemRate;
            }
            ItemRateIs = Convert.ToInt32(itemRates);
        ItemQty:
            Console.WriteLine("Enter quantity:");
            string? itemQtys = (Console.ReadLine());
            if (string.IsNullOrEmpty(itemQtys))
            {
                Console.WriteLine("Item quantity should not be empty!");
                goto ItemQty;
            }
            ItemsQtyIs = Convert.ToInt32(itemQtys);

            obj.Insert(new Item { ItemName = ItemNameIs, ItemsRate = ItemRateIs, ItemQty = ItemsQtyIs });
            Console.WriteLine("Data inserted");
        }
        public void Update()
        {
            Console.WriteLine("Enter item name to update it's rate and qty.");
            ItemNameIs = Console.ReadLine();
            Console.WriteLine("Enter item rate to update.");
            ItemRateIs = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter item qty to update");
            ItemsQtyIs = Convert.ToInt32(Console.ReadLine());
            if (ItemNameIs == null)
            {
                Console.WriteLine("Item no found!");
            }
            else
            {
                obj.Update(ItemNameIs, new Item { ItemName = ItemNameIs, ItemsRate = ItemRateIs, ItemQty = ItemsQtyIs });
                Console.WriteLine("Records updated!");
            }
        }
        public void ItemMasterMethods()
        {
            //CRUDManager obj = new ();

            Console.WriteLine("Welcome to Item Master portal.");
            Console.WriteLine();
        MAIN_MENU:
            Console.WriteLine("Enter 1 to add item in Items Table.");
            Console.WriteLine("Enter 2 to update item in Items Table.");
            Console.WriteLine("Enter 3 to list all item in Items Table.");
            Console.WriteLine("Enter 4 to delete item in Items Table.");
            Console.WriteLine("Enter 5 to exit.");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        Insert();
                        break;
                    }
                    case 2:
                    {
                        Update();
                        break;

                    }
                case 3:
                    {
                        Console.WriteLine("All available items are:");
                        PrintValues();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Enter item name to delete its record from the list.");
                        ItemNameIs = Console.ReadLine();
                        obj.DeleteI(ItemNameIs);
                        Console.WriteLine("Records deleted!");
                        break;
                        
                    }
                case 5:
                    {
                        return;
                    }
            }
            goto MAIN_MENU;
           
        }
    }
}
