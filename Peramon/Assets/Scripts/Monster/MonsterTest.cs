using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jp.Artm.Blog.Csarp.BeginnerQ2
{
    class Program
    {
        static void Main(string[] args)
        {

            String[] hairetu = {
                "はずれ", "当たり"
            };

            // Randomクラスのインスタンスを作成
            Random r = new Random();

            Console.WriteLine("おみくじを引くには、エンターキーを押してください");
            String inputString = Console.ReadLine();

            while (inputString != "quit")
            {

                int idx = r.Next(2);
                Console.WriteLine(hairetu[idx] + "です！");

                Console.WriteLine("おみくじを引くには、エンターキーを押してください");
                inputString = Console.ReadLine();
            }
        }
    }
}