using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Serialization
{
    [Serializable]
    public class SchoolBag
    {
        public bool Maths { get; set; }
        public bool Physics { get; set; }
        public bool Chemistry { get; set; }
        public bool History { get; set; }
        public bool Informatics { get; set; }
        public bool Literature { get; set; }
        public bool PencilCase { get; set; }
        public bool Lunch { get; set; }
        public bool IndoorShoes { get; set; }

        public SchoolBag()
        {
            this.Maths = false;
            this.Physics = false;
            this.Chemistry = false;
            this.History = false;
            this.Informatics = false;
            this.Literature = false;
            this.PencilCase = false;
            this.Lunch = false;
            this.IndoorShoes = false;
        }

        public void ShowBag()
        {
            Console.WriteLine("Содержимое рюкзака:");

            int k = 1;

            if (Maths)
            {
                Console.WriteLine($"{k}. Учебник по математике");
                k++;
            }

            if (Physics)
            {
                Console.WriteLine($"{k}. Учебник по физике");
                k++;
            }

            if (Chemistry)
            {
                Console.WriteLine($"{k}. Учебник по химии");
                k++;
            }

            if (History)
            {
                Console.WriteLine($"{k}. Учебник по истории");
                k++;
            }

            if (Informatics)
            {
                Console.WriteLine($"{k}. Учебник по информатике");
                k++;
            }

            if (Literature)
            {
                Console.WriteLine($"{k}. Учебник по литературе");
                k++;
            }

            if (PencilCase)
            {
                Console.WriteLine($"{k}. Пенал");
                k++;
            }

            if (Lunch)
            {
                Console.WriteLine($"{k}. Еда для перекуса");
                k++;
            }

            if (IndoorShoes)
            {
                Console.WriteLine($"{k}. Сменная обувь");
                k++;
            }
        }
    }

    interface Builder
    {
        void Reset();
        void PutMath();
        void PutPhysics();
        void PutChemistry();
        void PutHistory();
        void PutInformatics();
        void PutLiterature();
        void PutPencilCase();
        void PutLunch();
        void PutIndoorShoes();
    }

    class BagBuilder : Builder
    {
        private SchoolBag bag;

        public BagBuilder()
        {
            bag = new SchoolBag();
        }
        public SchoolBag GetBag()
        {
            return bag;
        }

        public void PutChemistry()
        {
            bag.Chemistry = true;
        }

        public void PutHistory()
        {
            bag.History = true;
        }

        public void PutIndoorShoes()
        {
            bag.IndoorShoes = true;
        }

        public void PutInformatics()
        {
            bag.Informatics = true;
        }

        public void PutLiterature()
        {
            bag.Literature = true;
        }

        public void PutLunch()
        {
            bag.Lunch = true;
        }

        public void PutMath()
        {
            bag.Maths = true;
        }

        public void PutPencilCase()
        {
            bag.PencilCase = true;
        }

        public void PutPhysics()
        {
            bag.Physics = true;
        }

        public void Reset()
        {
            bag = new SchoolBag();
        }
    }

    class TimetableBuilder : Builder
    {
        private StringBuilder listLessons;

        public TimetableBuilder()
        {
            listLessons = new StringBuilder("");
        }

        public StringBuilder GetResult()
        {
            return listLessons.Remove(listLessons.Length - 1, 1);
        }

        public void PutChemistry()
        {
            listLessons.Append("Химия\n");
        }

        public void PutHistory()
        {
            listLessons.Append("История\n");
        }

        public void PutIndoorShoes()
        {
        }

        public void PutInformatics()
        {
            listLessons.Append("Информатика\n");
        }

        public void PutLiterature()
        {
            listLessons.Append("Литература\n");
        }

        public void PutLunch()
        {
        }

        public void PutMath()
        {
            listLessons.Append("Математика\n");
        }

        public void PutPencilCase()
        {
        }

        public void PutPhysics()
        {
            listLessons.Append("Физика\n");
        }

        public void Reset()
        {
            listLessons = new StringBuilder("");
        }
    }

    class Director
    {
        public static void PackForMonday(Builder builder)
        {
            builder.Reset();

            builder.PutPencilCase();
            builder.PutLunch();
            builder.PutIndoorShoes();
            builder.PutHistory();
            builder.PutPhysics();
            builder.PutLiterature();
        }

        public static void PackForTuesday(Builder builder)
        {
            builder.Reset();

            builder.PutPencilCase();
            builder.PutLunch();
            builder.PutIndoorShoes();
            builder.PutMath();
            builder.PutChemistry();
            builder.PutLiterature();
        }

        public static void PackForWednesday(Builder builder)
        {
            builder.Reset();

            builder.PutPencilCase();
            builder.PutLunch();
            builder.PutIndoorShoes();
            builder.PutInformatics();
            builder.PutLiterature();
            builder.PutMath();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // создаем builder рюкзака
            BagBuilder bagBuilder = new BagBuilder();
            TimetableBuilder timetableBuilder = new TimetableBuilder();

            // просим директора составить расписание на понедельник
            Director.PackForMonday(timetableBuilder);
            // забираем результат у строителя расписания
            StringBuilder timeTable1 = timetableBuilder.GetResult();
            // просим директора собрать рюкзак для понедельника
            Director.PackForMonday(bagBuilder);
            // забираем результат у строителя рюкзака
            SchoolBag schoolBag1 = bagBuilder.GetBag();


            // просим директора составить расписание на вторник
            Director.PackForTuesday(timetableBuilder);
            // забираем результат у строителя расписания
            StringBuilder timeTable2 = timetableBuilder.GetResult();
            // просим директора собрать рюкзак для вторника
            Director.PackForTuesday(bagBuilder);
            // забираем результат у строителя рюкзака
            SchoolBag schoolBag2 = bagBuilder.GetBag();

            // просим директора составить расписание на среду
            Director.PackForWednesday(timetableBuilder);
            // забираем результат у строителя расписания
            StringBuilder timeTable3 = timetableBuilder.GetResult();
            // просим директора собрать рюкзак для среды
            Director.PackForWednesday(bagBuilder);
            // забираем результат у строителя рюкзака
            SchoolBag schoolBag3 = bagBuilder.GetBag();

            Console.WriteLine("до");
            Console.WriteLine();

            Console.WriteLine("ПОНЕДЕЛЬНИК:");
            Console.WriteLine(timeTable1);
            schoolBag1.ShowBag();
            Console.WriteLine();

            Console.WriteLine("ВТОРНИК:");
            Console.WriteLine(timeTable2);
            schoolBag2.ShowBag();
            Console.WriteLine();

            Console.WriteLine("СРЕДА:");
            Console.WriteLine(timeTable3);
            schoolBag3.ShowBag();

            Serialazer.BinSer("file", schoolBag3);
            Serialazer.BinDes("file", ref schoolBag3);
            schoolBag3.ShowBag();
        }
    }
}
