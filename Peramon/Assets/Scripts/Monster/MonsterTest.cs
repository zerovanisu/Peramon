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
                "�͂���", "������"
            };

            // Random�N���X�̃C���X�^���X���쐬
            Random r = new Random();

            Console.WriteLine("���݂����������ɂ́A�G���^�[�L�[�������Ă�������");
            String inputString = Console.ReadLine();

            while (inputString != "quit")
            {

                int idx = r.Next(2);
                Console.WriteLine(hairetu[idx] + "�ł��I");

                Console.WriteLine("���݂����������ɂ́A�G���^�[�L�[�������Ă�������");
                inputString = Console.ReadLine();
            }
        }
    }
}