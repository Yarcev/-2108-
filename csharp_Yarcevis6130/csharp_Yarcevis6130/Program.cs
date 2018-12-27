using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Common;

namespace csharp_Yarcevis6130
{
    class Program
    {
        public static string constr =
@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";
        static void select_task1()
        {
            SqlConnection Conn = new SqlConnection(Program.constr);
            Conn.Open();

            DataSet ds = new DataSet();

            Console.Write(" Пожалуйства введите наименование типа (значения в диапазоне[type_1 - type_10]): ");
            string word = Console.ReadLine();
            string commStr = "SELECT distinct mark FROM Clock where type ='"+word+"'";

            SqlDataAdapter adapter = new SqlDataAdapter(commStr, Conn);
            adapter.MissingSchemaAction = System.Data.MissingSchemaAction.AddWithKey;
            adapter.Fill(ds);

            DataTable table = ds.Tables[0];
            foreach (DataColumn column in table.Columns)
            {
                Console.Write("[" + column.ColumnName + "] ");
            }
            Console.WriteLine("\n" + new string('-', 80));
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    Console.Write("[" + row[column] + "] ");
                }
                Console.WriteLine();
            }

            Conn.Close();
        }
        static void select()
        {
            SqlConnection Conn = new SqlConnection(Program.constr);
            Conn.Open();

            DataSet ds = new DataSet();
            string commStr = "SELECT country FROM Producer";

            SqlDataAdapter adapter = new SqlDataAdapter(commStr, Conn);
            adapter.MissingSchemaAction = System.Data.MissingSchemaAction.AddWithKey;
            adapter.Fill(ds);

            DataTable table = ds.Tables[0];
            foreach (DataColumn column in table.Columns)
            {
                Console.Write("[" + column.ColumnName + "] ");
            }
            Console.WriteLine("\n" + new string('-', 80));
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    Console.Write("[" + row[column] + "] ");
                }
                Console.WriteLine();
            }

            Conn.Close();
        }
        static void select_task2() {
            SqlConnection Conn = new SqlConnection(Program.constr);
            Conn.Open();

            DataSet ds = new DataSet();
            Console.WriteLine(" Механические часы");
            Console.Write(" Пожалуйства введите максимальную цену( диапазон [1000;10000]): ");
            string word = Console.ReadLine();
            string commStr = "SELECT * FROM Clock where price <='" + word + "'";

            SqlDataAdapter adapter = new SqlDataAdapter(commStr, Conn);
            adapter.MissingSchemaAction = System.Data.MissingSchemaAction.AddWithKey;
            adapter.Fill(ds);

            DataTable table = ds.Tables[0];
            foreach (DataColumn column in table.Columns)
            {
                Console.Write("[" + column.ColumnName + "] ");
            }
            Console.WriteLine("\n" + new string('-', 80));
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    Console.Write("[" + row[column] + "] ");
                }
                Console.WriteLine();
            }

            Conn.Close();
        }
        static void select_task3() {
            SqlConnection Conn = new SqlConnection(Program.constr);
            Conn.Open();

            DataSet ds = new DataSet();
            Console.WriteLine(" марки часов в заданной стране");
            Console.Write(" введите название страны (из таблицы выше): ");
            string word = Console.ReadLine();
            string commStr = "select  * FROM Clock a1 inner join Producer a2 on a1.fk_producer = a2.pk_producer where country = '"+word+"'";

            SqlDataAdapter adapter = new SqlDataAdapter(commStr, Conn);
            adapter.MissingSchemaAction = System.Data.MissingSchemaAction.AddWithKey;
            adapter.Fill(ds);

            DataTable table = ds.Tables[0];
            foreach (DataColumn column in table.Columns)
            {
                Console.Write("[" + column.ColumnName + "] ");
            }
            Console.WriteLine("\n" + new string('-', 80));
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    Console.Write("[" + row[column] + "] ");
                }
                Console.WriteLine();
            }

            Conn.Close();
        }
        static void select_task4() {
            SqlConnection Conn = new SqlConnection(Program.constr);
            Conn.Open();

            DataSet ds = new DataSet();
            Console.WriteLine(" Механические часы");
            Console.Write(" Пожалуйства введите максимальную цену( диапазон [1000;infinite]): ");
            string word = Console.ReadLine();
            string commStr = "select name, sum(price) as sum_price FROM Clock a1 inner join Producer a2 on a1.fk_producer = a2.pk_producer group by name having sum(price) <= "+word+";";

            SqlDataAdapter adapter = new SqlDataAdapter(commStr, Conn);
            adapter.MissingSchemaAction = System.Data.MissingSchemaAction.AddWithKey;
            adapter.Fill(ds);

            DataTable table = ds.Tables[0];
            foreach (DataColumn column in table.Columns)
            {
                Console.Write("[" + column.ColumnName + "] ");
            }
            Console.WriteLine("\n" + new string('-', 80));
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    Console.Write("[" + row[column] + "] ");
                }
                Console.WriteLine();
            }

            Conn.Close();
        }
        
        static void lineCh(char s)
        {
            for (int i = 0; i < 80; i++)
                Console.Write(s);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("zachot variant 9 Yarcev DA is6130");
            lineCh('=');
            //управляющий алгоритм
            {
                int i = 0;
                bool key = true;
                while (key)
                {
                    bool key_input = true;
                    while (key_input)
                    {
                        key_input = false;
                        Console.WriteLine(" Выберите действие:");
                        Console.WriteLine(" 1 - Вивести всі марки для заданого типу годинників");
                        Console.WriteLine(" 2 - Вивести інформацію про механічні годинники, ціна на які не перевищує задану");
                        Console.WriteLine(" 3 - Вивести марки годинників, які виготовлені в заданій країні");
                        Console.WriteLine(" 4 - Вивести виробників, загальна сума годинників яких є  в наявності в магазині не перевищує задану");
                        Console.WriteLine(" 5 - завершити програму");
                        Console.Write(" № действия:");
                        i = Int32.Parse(Console.ReadLine());
                        if (i < 1 || i > 5)
                        {
                            Console.WriteLine(" Не верно, повторите ввод.");
                            key_input = true;
                        }
                    }
                    lineCh('-');
                    switch (i)
                    {
                        case 1: select_task1(); break;
                        case 2: select_task2(); break;
                        case 3:
                            select();
                            lineCh('-');
                            select_task3(); break;
                        case 4: select_task4(); break;
                        case 5: key = false; break;
                    }
                    lineCh('=');
                }

            }
            Console.WriteLine("Program is ending...");
            Console.ReadLine();
        }
    }
}
