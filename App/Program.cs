using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomersGenerator;
using Domain;
using Microsoft.Office.Interop.Excel;

namespace App
{
    public class Program
    {
        public static void FormHotel()
        {
            Hotel.TakeClients(new Customer(typeof(Domain.Single), DateTime.Now.Date,3));
            Hotel.TakeClients(new Customer(typeof(Domain.Single), DateTime.Now.Date, 3));
            Hotel.TakeClients(new Customer(typeof(Domain.Double), DateTime.Now.Date, 4));
            Hotel.TakeClients(new Customer(typeof(Domain.Double), DateTime.Now.Date.AddDays(3), 3));
            Hotel.TakeClients(new Customer(typeof(Triple), DateTime.Now.Date, 3));
            Hotel.TakeClients(new Customer(typeof(Vip), DateTime.Now.Date, 4));
        }

        static void Main() 
        {
            FormHotel();
            ExcelWriter();
            Console.ReadKey();
            var cg = new CustomerGenerator();
            Hotel.TakeClients(cg.Generate());
            ExcelWriter();
        }

        public static void ExcelWriter()
        {
            Object missing = Type.Missing;
            Application ExcelApp = new Application();
            Workbook ExcelWorkBook;
            Worksheet ExcelWorkSheet;
            //Книга.
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            //Таблица.

            ExcelWorkSheet = (Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            ExcelWorkSheet.Cells[1, 1] = "Номера";
            for (var i = 0; i < 62; i++)
                ExcelWorkSheet.Cells[1, i + 2] = DateTime.Now.Date.AddDays(i);
            for (int i = 0; i < Hotel.Rooms.Count; i++)
            {
                var room = Hotel.Rooms[i];
                ExcelWorkSheet.Cells[i + 2, 1] = room.Number + " " + room.GetType().Name;
                for (int j = 0; j < 62; j++)
                    if (room.OcupDays.Contains(DateTime.Now.Date.AddDays(j)))
                    {
                        ExcelWorkSheet.Cells[i + 2, j + 2] = "Занято";
                    }
            }
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }
    }
}
