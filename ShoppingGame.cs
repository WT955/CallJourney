/*
The interface to our checkout looks like this (shown in .Net):

```.Net
 Checkout co = new Checkout(pricingRules);
 co.scan(item1);
 co.scan(item2);
 co.total();
```
*/

using System;
using System.Data;
using System.Collections.Generic;

namespace Shopping_Game
{
    class Checkout
    {
        static void Main(string[] args)
        {
            Checkout co = new Checkout(3); // enter the deal here !!
            
            /*co.scan("atv");
            co.scan("atv");
            co.scan("atv");
            co.scan("vga");*/
            
            /*co.scan("atv");
            co.scan("ipd");
            co.scan("ipd");
            co.scan("atv");
            co.scan("ipd");
            co.scan("ipd");
            co.scan("ipd");*/

            /*co.scan("mbp");
            co.scan("ipd");
            co.scan("vga");*/

            co.total();
            Console.ReadLine();

        }

        // Data table for products of the computer store
        static DataTable GetTable()
        {
            using (DataTable dt = new DataTable("shoppingList"))
            {
                dt.Columns.Add("ID", typeof(int));
                dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };
                dt.Columns.Add("SKU", typeof(string));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Price", typeof(double));
                dt.Rows.Add("1", "ipd", "Super Ipad", 549.99);
                dt.Rows.Add("2", "mbp", "MacBook Pro", 1399.99);
                dt.Rows.Add("3", "atv", "Apple TV", 109.5);
                dt.Rows.Add("4", "vga", "VGA adapter", 30.00);

                return dt;
            }
        }
        //
        private List<string> Items = new List<string>();
        private int itemCount = 0;
        private string freeItem;
        private string promoItem;
        private int deals = 0;
        public Checkout(int pricingRules)
        {

            if (pricingRules == 1)
            {
                promoItem = "atv";
                freeItem = "atv";
                deals = 1;
            }
            else if (pricingRules == 2)
            {
                promoItem = "ipd";
                deals = 2;
            }
            else if (pricingRules == 3)
            {
                promoItem = "mbp";
                freeItem = "vga";
                deals = 3;
            }

        }
        //
        public void scan(string item)
        {
            Items.Add(item);
            itemCount++;
        }
        //
        public void total()

            {
                var data = GetTable();
                var totalPrice = 0.0;
                var promoItemCount = 0;


                for (int i = 0; i < Items.Count; i++) // calucate total amount of the order
                {
                    var expression = Items[i];
                    DataRow[] result = data.Select("SKU = '" + Convert.ToString(expression) + "'");
                    foreach (DataRow row in result)
                    {
                        totalPrice += (double)row[3];
                    }

                }

                for (int i = 0; i < Items.Count; i++) // check total number of Item in the basket
                {
                    if (promoItem == Items[i] && deals == 1)
                    {
                        promoItemCount++;

                        if (promoItemCount == 3) // remove price of the 3rd product when deals applied
                        {
                            totalPrice -= 109.5;
                            promoItemCount = 0;
                        }
                    }
                    else if (promoItem == Items[i] && deals == 2)
                    {
                        promoItemCount++;
                    }
                    else if (promoItem == Items[i] && deals == 3)
                    {
                        promoItemCount++;

                        for (int j = 0; j < Items.Count; j++) // remove free item from the order, duduct free item price; will add free item on the next stage
                        {
                            if (Items[j] == freeItem) 
                            {
                                totalPrice -= 30;
                                Items.Remove(freeItem);
                                break;
                            }

                        }
                    }
                }

                if (promoItemCount > 4 && deals == 2) // deduct price for deal 2
                {
                    totalPrice -= promoItemCount * 50;
                }
                else if (deals == 3)
                {
                    for (int n = 0; n < promoItemCount; n++) // for deal 3, adding free item into the order
                    {
                        Items.Add(freeItem);
                    }
                }
                /*
                // order list checking
                for (int i = 0; i < Items.Count; i++) 
                {
                    var expression = Items[i];
                    DataRow[] result = data.Select("SKU = '" + Convert.ToString(expression) + "'");
                    foreach (DataRow row in result)
                    {
                        Console.WriteLine("{0}, {1}", row[2], row[3]);

                    }

                }
                */
            Console.WriteLine("SKUs Scanned: {0}", String.Join(", ", Items));
            Console.WriteLine("Total expected: ${0}", Math.Round(totalPrice, 2));
        }        
        //
    } 
}

    


