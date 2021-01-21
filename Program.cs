using System;

namespace BankAutomation
{
    class Program
    {
        static void Main(string[] args)
        {
            int selection, selection2, ID;
            string name, surname;
            Program pr1 = new Program();
            CustomerManager customerManager= new CustomerManager();
            Customer selectCustomer = new Customer();

            here:
            pr1.menu();

            selection = Convert.ToInt32(Console.ReadLine());

            if (selection == 1)
            {
                customerManager.addCustomer();
                Console.WriteLine("Müşteri eklendi.");
                goto here;
            }

            else if(selection == 2)
            {
                customerManager.listCustomers();
                goto here;
            }
            else if(selection == 3) {


            
                Console.WriteLine("Enter the customer ID: ");
                ID = Convert.ToInt32(Console.ReadLine());
                customerManager.findCustomer(ID, ref selectCustomer);
                Console.WriteLine("Müşteri Bulundu. Bilgiler aktarılıyor: ");
                customerManager.listCustomers(selectCustomer);

                again:

                Console.WriteLine("for the delete selected customer press ->1");
                Console.WriteLine("for the check credit limit       press ->2");
                selection2 = Convert.ToInt32(Console.ReadLine());

                if (selection2 == 1)
                    customerManager.DeleteCustomer(selectCustomer);
                if (selection2 == 2)
                {
                    Console.WriteLine("If you want definition a special credit constant, press -> 1");
                    Console.WriteLine("Else, press -> 0");

                    if (Convert.ToInt32(Console.ReadLine()) == 1)
                    {
                        Console.WriteLine("Enter the credit constant: ");
                        double constant = Convert.ToDouble(Console.ReadLine());
                        customerManager.CheckCreditLimit(selectCustomer, constant);
                    }

                    else
                        customerManager.CheckCreditLimit(selectCustomer);

                    Console.WriteLine("If you want to take action on this customer again, press -> 1");
                    Console.WriteLine("Else, press ->0");

                    selection2 = Convert.ToInt32(Console.ReadLine());

                    if (selection2 == 1)
                        goto again;
                    else
                        goto here;
                   

                }


            }

            


        }

        public void menu()
        {
            Console.WriteLine("*******Welcome the Customer Services*******");
            Console.WriteLine("for the add new customer, press      -> 1");
            Console.WriteLine("for the list all of customers, press -> 2");
            Console.WriteLine("for the find customer with ID, press -> 3");
        }
    }



}
