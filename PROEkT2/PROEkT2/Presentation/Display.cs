using PROEkT2.Business;
using PROEkT2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROEkT2.Presentation

    
    {
        class Display
        {
            
        private DishLogic dishLogic = new DishLogic();
        private int closeOperationId = 6;
        public Display()
            {
                Input();
            }

            private void ShowMenu()
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("1. ID:"+dishLogic);
                Console.WriteLine("2. Name:"+dishLogic);
                Console.WriteLine("3. Price:"+dishLogic);
                Console.WriteLine("4. Stock:"+dishLogic);
                Console.WriteLine("5. Delete entry by ID");
                Console.WriteLine("6. Exit");
            }

            private void Input()
            {
                var operation = -1;
                do
                {
                    ShowMenu();
                    operation = int.Parse(Console.ReadLine());
                    switch (operation)
                    {
                        case 1:
                            ListAll();
                            break;
                        case 2:
                            Add();
                            break;
                        case 3:
                            Update();
                            break;
                        case 4:
                            Fetch();
                            break;
                        case 5:
                            Delete();
                            break;
                        default:
                            break;
                    }
                } while (operation != closeOperationId);
            }
                

            private void Delete()
            {

                Console.WriteLine("Enter ID to delete: ");
                int id = int.Parse(Console.ReadLine());
                dishLogic.Delete(id);
                Console.WriteLine("Done.");
            }

            private void Fetch()
            {
                Console.WriteLine("Enter ID to fetch: ");
                int id = int.Parse(Console.ReadLine());
                Dishes dishes = dishLogic.Get(id);
                if (dishes != null)
                {
                    Console.WriteLine(new string('-', 40));
                    Console.WriteLine("ID: " + dishes.Id);
                    Console.WriteLine("Name: " + dishes.Name);
                    Console.WriteLine("Price: " + dishes.Price);
                    Console.WriteLine("Stock: " + dishes.Stock);
                    Console.WriteLine(new string('-', 40));
                }
            }

            private void Update()
            {
                Console.WriteLine("Enter ID to update: ");              
                int id = int.Parse(Console.ReadLine());
                Dishes dishes = dishLogic.Get(id);            
                if (dishes != null)
                {
                    Console.WriteLine("Enter name: ");
                    dishes.Name = Console.ReadLine();
                    Console.WriteLine("Enter price: ");
                    dishes.Price = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Enter availability: ");
                    dishes.Stock = int.Parse(Console.ReadLine());
                    dishLogic.Update(id,dishes);
                }
                else
                {
                    Console.WriteLine("Product not found!");
                }
            }

            private void Add()
            {
                Dishes dishes = new Dishes();
                Console.WriteLine("Enter name: ");
                dishes.Name = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                dishes.Price = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter availability: ");
                dishes.Stock = int.Parse(Console.ReadLine());
                dishLogic.Create(dishes);
        }


            private void ListAll()
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine(new string(' ', 16) + "DISHES" + new string(' ', 16));
                Console.WriteLine(new string('-', 40));
                var dishes = dishLogic.GetAll();
                foreach (var item in dishes)
                {
                    Console.WriteLine("{0} {1} {2} {3}", item.Id, item.Name, item.Price, item.Stock);
                }
            }

        }
    }

