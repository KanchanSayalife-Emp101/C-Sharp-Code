using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeChecker
{
    public class IcecreamSeller
    {
        public static void Main()
        {
            int People;
            
            Console.Write("Enter the total no. Of People Standing in Queue:= ");
            while(!int.TryParse(Console.ReadLine(), out People) )
            {
                Console.WriteLine("Enter the correct value....");
            }
            int[] change = new int[People];
            Console.Write("Enter the Change (5,10,20) collect from the Peoples Standing in Queue:= ");
            for (int i = 0; i < change.Length; i++)
            {
                Console.Write($"People {i + 1}: ");
                while(!int.TryParse(Console.ReadLine(),out change[i]) || (change[i] != 5 && change[i] != 10 && change[i] != 20))
                {
                    Console.WriteLine("Enter change value only 5,10,20");
                }
            }
            Console.Write("Available change is:= ");
            foreach (int i in change)
            {
                Console.Write( i + "     ");
                
            }
            int five = 0,ten = 0;
            bool CanGiveChange = true;
            foreach(int note in change)
            {
                if(note == 5)
                {
                    five++;
                }
                else if(note == 10)
                {
                    if(five > 0)
                    {
                        five--;
                        ten++;
                    }
                    else
                    {
                        CanGiveChange = false;
                        break;
                    }
                   
                }
                else if(note == 20)
                {
                    if (ten > 0 && five > 0)
                    {
                        ten--;
                        five--;
                    }
                    else if (five >= 3)
                    {
                        five = five - 3;
                    }
                    else
                    {
                        CanGiveChange = false;
                        break;
                    }
                }
            }
            Console.WriteLine("\nResult: " + (CanGiveChange ? "YES" : "NO"));

        }
    }
}
