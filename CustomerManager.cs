using System;
using System.Collections.Generic;
using System.Text;

namespace BankAutomation
{
    public class CustomerManager
    {
        int countCustomer = 0;
        Customer[] customers = new Customer[20];

        public void addCustomer()
        {
            if (countCustomer == 20)
            {
                Console.Write("Maksimum 20 müşteri kaydedebilirsiniz. ");
                return;
            }
            Customer customer = new Customer();
            customers[countCustomer] = customer;

            here:
            Console.Write("Enter the customer's ID: ");
            customer.id = Convert.ToInt32(Console.ReadLine());

            if (CheckSameID(customer) == 1)
                goto here;


            Console.Write("Enter the customer's Name: ");
            customer.name = Console.ReadLine();

            Console.Write("Enter the customer's Surname: ");
            customer.surName = Console.ReadLine();

            Console.Write("Enter the customer's phone number: ");
            customer.phoneNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the customer's Credit Rate: ");
            customer.creditRate = Convert.ToDouble(Console.ReadLine());

            customer.location = countCustomer;
            countCustomer++;
            
        }

        public void DeleteCustomer(Customer cs)  ///// eksik 
        {
            int ID;
            Console.WriteLine("Enter the ID of the customer who wants to be deleted ");
            ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Silindi.");
        }

        public void CheckCreditLimit(Customer customer)
        {


            string sentence = "Maksimum çekilebilecek kredi miktarı: ";
            double creditConstant = 22000;
            if (customer.creditRate <= 0.5)
            {
                Console.Write(sentence);
                Console.WriteLine(CreditCalculate(customer.creditRate, 24000) + " \n "s);
            }

            else if (customer.creditRate > 0.5 || customer.creditRate <= 1.5)
            {
                Console.Write(sentence);
                Console.WriteLine(CreditCalculate(customer.creditRate, creditConstant));
            }

            else if (customer.creditRate > 1.5 || customer.creditRate < 3)
            {
                Console.Write(sentence);
                Console.WriteLine(CreditCalculate(customer.creditRate, creditConstant));
            }
            else
            {
                Console.WriteLine(sentence);
                Console.WriteLine(CreditCalculate(customer.creditRate, 22000));
            }
        }


        public void CheckCreditLimit(Customer customer,double specialConstant) // if you want definition special credit constant for special customer, use this method
        {
            string sentence = "Maksimum çekilebilecek kredi miktarı:";

            if (customer.creditRate <= 0.5)
            {
                Console.Write(sentence);
                Console.WriteLine(CreditCalculate(customer.creditRate, specialConstant));
            }

            else if (customer.creditRate > 0.5 || customer.creditRate <= 1.5)
            {
                Console.Write(sentence);
                Console.WriteLine(CreditCalculate(customer.creditRate, specialConstant));
            }

            else if (customer.creditRate > 1.5 || customer.creditRate < 3)
            {
                Console.Write(sentence);
                Console.WriteLine(CreditCalculate(customer.creditRate, specialConstant));
            }
            else
            {
                Console.WriteLine(sentence);
                Console.WriteLine(CreditCalculate(customer.creditRate, specialConstant));
            }
        }

        private double CreditCalculate(double creditRate,double standartcreditConstant) // you can change credit constant to according credit rate
        {
            return creditRate * standartcreditConstant;
        }

        public void listCustomers()
        {
            int i = 0;
            foreach (Customer customer in customers){

                    Console.WriteLine("************************************");
                    Console.WriteLine("Customer ID: " + customer.id);
                    Console.WriteLine("Custome Name: " + customer.name);
                    Console.WriteLine("Customer Surname: " + customer.surName);
                    Console.WriteLine("Customer's phone number: " + customer.phoneNumber);
                    Console.WriteLine("************************************" + "\n");
                    i++;

                if (i == countCustomer)
                    break;
            }   
        }

        public void listCustomers(Customer customer)
        {
                Console.WriteLine("************************************");
                Console.WriteLine("Customer ID: " + customer.id);
                Console.WriteLine("Custome Name: " + customer.name);
                Console.WriteLine("Customer Surname: " + customer.surName);
                Console.WriteLine("Customer's phone number: " + customer.phoneNumber);
                Console.WriteLine("************************************" + "\n");
        }


        public void findCustomer(int id, ref Customer cs)
        {
            for (int i = 0; i < countCustomer; i++)
            {
               if (customers[i].id == id)
                {
                    cs = customers[i];
                }
                   
                    
            }
        }

        private int CheckSameID(Customer customer)
        {
            for (int i = 0; i < countCustomer; i++)
            {
                if (customers[i].id == customer.id)
                {
                    Console.WriteLine("Same ID error. Enter again. ");
                    return 1;
                }

            }
            return 0;
        }



    }



}
