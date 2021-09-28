using System;
using System.Collections.Generic;
using System.Linq;
namespace InternTest
{
    class Program
    {
        static readonly DateTime baseDate = new DateTime(2018, 2, 1);
        static string customerData = "greg  R  hopper,0123654,24.25,255\n  Sam  Smith,000126,(24.25),421\n maximus   WHITE  ,000025,(12),\n Bill   Masters,000526,6.5,11\n Frank      Berg,000527,6.75,1";
        static void Main(string[] args)
        {
            List<Model> models = new List<Model>();
            List<string> records = customerData.Split('\n').ToList();
            foreach (var record in records)
            {
                List<string> data = record.Split(',').ToList();
                List<string> names = data[0].Trim().Split(' ').ToList();
                //remove the empty string/whitespace before calling the hasmiddlename bool
                names.RemoveAll(customerData => string.IsNullOrEmpty(customerData));

                //int sum = 3;

                //for (int row = 1; row < 3; row+=3)
                //{
                //    for (int i = row + 1; i < row + 3; i++)
                //    {
                //        sum = sum + i;
                //    }
                //    sum = 0;
                //}

                bool hasMiddleName = HasMiddleName(names);
                //second variable names[2] get names[2] to always have three positions
                List<string> FullName = new List<string>(new string[3]);
                //assign the if-else statement, checking hasmiddlename bool variable, then just plug in first position of full name is FirstName
                FullName[0] = names[0];
                if (hasMiddleName == true)
                {
                    FullName[1] = names[1];
                    FullName[2] = names[2];
                    //Console.WriteLine("names[1]:" + names[1].ToString());
                }
                else
                {
                    FullName[1] = "";
                    FullName[2] = names[1];
                    //Console.WriteLine("names[1]:" + names[1].ToString());
                }
                //(this has been solved) instantiate model below, grab from names position in names[2], if hasmiddlenames do one thing, if not do other

                var m = new Model
                {
                    FirstName = FullName[0].ToUpper() ?? "",
                    MiddleName = FullName[1].ToUpper() ?? " ",
                    LastName = FullName[2].ToUpper() ?? "",
                    TransactionNumber = int.TryParse(data[1], out int txNumber) ? txNumber : 0,
                    TransactionAmount = float.TryParse(data[2], out float txAmount) ? txAmount : 0,
                    TransactionDate = baseDate.AddDays(-(int.TryParse(data[3], out int days) ? days : 0))
                };
                Console.WriteLine(m.FirstName + "\n" + m.MiddleName + "\n" + m.LastName + "\n" + m.TransactionNumber + "\n" + m.TransactionAmount + "\n" + m.TransactionDate + "\n");
                models.Add(m);
            }
            int a = 5;
            //Console.WriteLine(models[3].FirstName);
            //when adding transaction numbers, may have to use FormatNumber and UseParensForNegativeNumbers, which may include .True at the end -> () = negative


            static bool HasMiddleName(List<string> names) => names.Count >= 3;

        }

        class Model
        {
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public int TransactionNumber { get; set; }
            public float TransactionAmount { get; set; }
            public DateTime TransactionDate { get; set; }
        }

    }
}