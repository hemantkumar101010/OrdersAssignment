using Microsoft.EntityFrameworkCore;
using OrdersData.Entities;


namespace OrdersData
{
    public class CRUDManager
    {
        private DemoDbContext demoDbContext;
        public CRUDManager()
        {
            demoDbContext = new DemoDbContext();
        }

        #region customer crud
        public void Insert(Customer customer)
        {
            demoDbContext.Customers.Add(customer);
            demoDbContext.SaveChanges();
        }

        public void Delete(string customerEmail)
        {
            var customer = demoDbContext.Customers.Where(x => x.CustomerEmail == customerEmail).FirstOrDefault();
            if (customer == null)
            {
                throw new Exception($"EmployeeEducation with ID:{customerEmail} Not Found");
            }

            // Entity state : Deleted
            demoDbContext.Customers.Remove(customer);

            // This issues insert statement
            demoDbContext.SaveChanges();
        }

        public bool EmailPresent(string email)
        {
            var customer = demoDbContext.Customers.Where(x => x.CustomerEmail == email)
                            .AsNoTracking()
                            .FirstOrDefaultAsync().Result;

            if (customer == null)
            {
               return false;
            }
            else
            {
                return true;
            }
        }

        public bool passwordPresent(string pass)
        {
            var customer = demoDbContext.Customers.Where(x => x.CustomerPassword == pass)
                            .AsNoTracking()
                            .FirstOrDefaultAsync().Result;

            if (customer == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void UpdateAccount(string mail,Customer updatecustomer)
        {
            var customer  = demoDbContext.Customers.Where(x => x.CustomerEmail == mail)
                            .AsNoTracking()
                            .FirstOrDefaultAsync().Result;

            customer.CustomerPhone=updatecustomer.CustomerPhone;
            customer.CustomerPassword = updatecustomer.CustomerPassword;


            // Entity state : Modified
            demoDbContext.Customers.Update(customer);

            // This issues insert statement
            demoDbContext.SaveChanges();

        }
        public Customer YourRegDetails(string email)
        {

            var customer = demoDbContext.Customers.Where(x => x.CustomerEmail == email)
                            .AsNoTracking()
                            .FirstOrDefaultAsync().Result;

            if (customer == null)
            {
                Console.WriteLine($"EmployeeEducations with ID:{email} Not Found");
            }

            return customer;
        }

        #endregion


        #region items-crud

        public bool ItemDuplicate(string itmeIs)
        {
            var item1 = demoDbContext.Items.Where(x => x.ItemName == itmeIs).FirstOrDefault();
            if (item1 == null)
            {
                return false;
            }
            else
                return true;
        }
        public void Insert(Item item)
        {
            demoDbContext.Items.Add(item);
            demoDbContext.SaveChanges();
        }

        public List<Item> ListItems()
        {
            var item = demoDbContext.Items.ToList();
            return item;
        }

        public void Update(string itemName, Item itemUpdate)
        {
            var item1 = demoDbContext.Items.Where(x => x.ItemName == itemName).FirstOrDefault();
            if (item1 == null)
            {
                Console.WriteLine($"{item1} Not Found");
            }
            else
            {
                item1.ItemsRate = itemUpdate.ItemsRate;
                item1.ItemQty = itemUpdate.ItemQty;

                demoDbContext.Items.Update(item1);

                demoDbContext.SaveChanges();
            }
        
        }
        public void DeleteI(string itemName)
        {
            var item = demoDbContext.Items.Where(x => x.ItemName == itemName).FirstOrDefault();
            if (item == null)
            {
                throw new Exception($"{item} Not Found");
            }

            // Entity state : Deleted
            demoDbContext.Items.Remove(item);

            // This issues insert statement
            demoDbContext.SaveChanges();
        }

        #endregion
    }
}
