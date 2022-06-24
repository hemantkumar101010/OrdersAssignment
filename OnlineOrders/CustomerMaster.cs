using OrdersData;
using MailKit.Net.Smtp;
using MimeKit;
using System.Text.RegularExpressions;
using OrdersData.Entities;

namespace OnlineOrders
{
    public class CustomerMaster
    {
        #region props
        public string? CustomerFNameIs { get; set; }
        public string? CustomerLNameIs { get; set; }
        public int CustomerPhoneIs { get; set; }
        public string? CustomerEmailIs { get; set; }
        public string? CustomerPasswordIs { get; set; }

        readonly CRUDManager obj = new();
        #endregion
        public void PrintCDetails(string yourMail)
        {
            Console.WriteLine("your registration details:");

            Customer cus = obj.YourRegDetails(yourMail);

            Console.WriteLine($"{cus.CustomerFName}\t{cus.CustomerLName}\t{cus.CustomerPhone}\t{cus.CustomerEmail}\t{cus.CustomerPassword}");

        }
        public void RegistrationInput()
        {
            Console.WriteLine("Enter first name");
            CustomerFNameIs = Console.ReadLine(); ;
            Console.WriteLine("Enter last name");
            CustomerLNameIs = Console.ReadLine();
            Console.WriteLine("Enter phone");
            CustomerPhoneIs = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Set password");
            CustomerPasswordIs = Console.ReadLine();
        }
        public void SendMail()
        {
            #region send-mail
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Online Orders Portal", "heman5502@gmail.com"));
            message.To.Add(MailboxAddress.Parse(CustomerEmailIs));

            message.Subject = "!!!Welcome!!!";
            message.Body = new TextPart("plain")
            {
                Text = $"Dear {CustomerFNameIs} {CustomerLNameIs}, Thanks for registering with us."
            };

            #region private data
            string email = "heman5502@gmail.com";
            string password = "ytrnamdknanthdth";
            #endregion

            SmtpClient smtpClient = new SmtpClient();
            try
            {
                smtpClient.Connect("smtp.gmail.com", 465, true);
                smtpClient.Authenticate(email, password);
                smtpClient.Send(message);
                Console.WriteLine($"!!Thanks dear  {CustomerFNameIs} {CustomerLNameIs} for registration with us!!");
                Console.WriteLine($"A 'Welcome Message' is just sent to your registered mail id from 'heman5502@gmail.com'");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                smtpClient.Disconnect(true);
                smtpClient.Dispose();
            }
            #endregion
        }
        public void CustomerMasterMethods()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to Customer portal.");
            Console.WriteLine();
        MAIN_MENU:
            Console.WriteLine("Enter 1 for registration in 'online order portal'.");
            Console.WriteLine("Enter 2 to login.");

            //CRUDManager crudManager = new CRUDManager();
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
            CustomerEmail:
                #region customer-registration
                Console.WriteLine("Enter your mail.");
                CustomerEmailIs = Console.ReadLine();
                if (string.IsNullOrEmpty(CustomerEmailIs))
                {
                    Console.WriteLine("Mail not found!");
                }
            
                string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
                Regex regex = new(pattern);

                Match match = regex.Match(CustomerEmailIs);
                if (!match.Success)
                {
                   Console.WriteLine($"{CustomerEmailIs} is not Valid Email Address");
                   goto CustomerEmail;
                }
                RegistrationInput();
                obj.Insert(new Customer { CustomerEmail = CustomerEmailIs, CustomerFName = CustomerFNameIs, CustomerLName = CustomerLNameIs, CustomerPhone = CustomerPhoneIs, CustomerPassword = CustomerPasswordIs });
                SendMail();

                Console.WriteLine("Enter 1 to go back.");
                Console.WriteLine("Enter 2 to exit.");
                int i = Convert.ToInt32(Console.ReadLine());
                if (i == 1)
                {
                    goto MAIN_MENU;
                }
                else if (i == 2)
                {
                    return;
                }
                #endregion
            }

            else if (choice == 2)
            {
                Console.WriteLine("Enter your mail");
                CustomerEmailIs = Console.ReadLine();
                if (CustomerEmailIs == null)
                {
                    Console.WriteLine("Mail not found!");
                }
                else
                {
                    if (obj.EmailPresent(CustomerEmailIs))
                    {
                    Pass1:
                        Console.WriteLine("Enter password.");
                        CustomerPasswordIs = Console.ReadLine();
                            if (obj.passwordPresent(CustomerPasswordIs))
                            {
                                Console.WriteLine();
                                Console.WriteLine("Welcome to your 'online order customer portal'.");
                                Console.WriteLine();
                            CustomerOp:
                                Console.WriteLine("Enter 1 to see your registration details.");
                                Console.WriteLine("Enter 2 to delete your account/registration details.");
                                Console.WriteLine("Enter 3 to update your account details.");
                                Console.WriteLine("Enter 4 to logout.");
                                int choiceInCustomer = Convert.ToInt32(Console.ReadLine());

                                switch (choiceInCustomer)
                                {
                                    case 1:
                                        {
                                            PrintCDetails(CustomerEmailIs);
                                            break;
                                        }
                                    case 2:
                                        {
                                            obj.Delete(CustomerEmailIs);
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.WriteLine("Enter new phone");
                                            int newPhone = Convert.ToInt32(Console.ReadLine());

                                            Console.WriteLine("Enter new password");
                                            CustomerPasswordIs = Console.ReadLine();

                                            obj.UpdateAccount(CustomerEmailIs, new Customer { CustomerPhone = newPhone, CustomerPassword = CustomerPasswordIs });
                                            break;
                                        }
                                   case 4:
                                        {
                                           goto MAIN_MENU;
                                        }
                                }
                            goto CustomerOp;
                            }
                            else
                            {
                                Console.WriteLine("Sorry wrong password.");
                                goto Pass1;
                            }
                    }
                    else
                    {
                        Console.WriteLine("Sorry you are no registered.");
                        goto MAIN_MENU;
                    }
                }


            }
        }
    }
}
