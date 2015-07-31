using System;
//Include this if it is not included
using System.Data;

namespace DataTableManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializes a new instance of the DataTable With Name
            DataTable dTable = new DataTable("Students");

            // Add columns with datatype in students datatable
            dTable.Columns.Add("StudentId", typeof(int));
            dTable.Columns.Add("StudentName", typeof(string));
            dTable.Columns.Add("StudentClass", typeof(string));
            dTable.Columns.Add("StudentSection", typeof(string));
            dTable.Columns.Add("StudentRank", typeof(int));

            // Add new Row to students datatable
            DataRow newRow = dTable.NewRow();
            newRow["StudentId"] = 1;
            newRow["StudentName"] = "Kannadasan";
            newRow["StudentClass"] = "10";
            newRow["StudentSection"] = "A";
            newRow["StudentRank"] = 1;
            dTable.Rows.Add(newRow);

            // Add new Row to students datatable
            newRow = dTable.NewRow();
            newRow["StudentId"] = 2;
            newRow["StudentName"] = "Kaviyarasan";
            newRow["StudentClass"] = "10";
            newRow["StudentSection"] = "C";
            newRow["StudentRank"] = 4;
            dTable.Rows.Add(newRow);

            // Add new Row to students datatable
            newRow = dTable.NewRow();
            newRow["StudentId"] = 3;
            newRow["StudentName"] = "Xavier";
            newRow["StudentClass"] = "10";
            newRow["StudentSection"] = "D";
            newRow["StudentRank"] = 3;
            dTable.Rows.Add(newRow);

            // Add new Row to students datatable
            newRow = dTable.NewRow();
            newRow["StudentId"] = 4;
            newRow["StudentName"] = "Manju";
            newRow["StudentClass"] = "10";
            newRow["StudentSection"] = "B";
            newRow["StudentRank"] = 2;
            dTable.Rows.Add(newRow);

            //Table Initial Data
            Console.WriteLine("");
            Console.WriteLine("Table Initial Data");
            Console.WriteLine("=========================");
            foreach (DataRow dRow in dTable.Rows)
            {
                Console.WriteLine("Id : " + dRow["StudentId"].ToString() + ", Name : " + dRow["StudentName"].ToString() + ", Class : " + dRow["StudentClass"].ToString() + ", Section : " + dRow["StudentSection"].ToString() + ", Rank : " + dRow["StudentRank"].ToString());
            }
            Console.WriteLine("");

            //Sorting Datatable
            DataView dv = dTable.DefaultView;
            dv.Sort = "StudentRank asc";
            DataTable sortedTable = dv.ToTable();
            Console.WriteLine("Sorted Data Table By Rank");
            Console.WriteLine("=========================");
            foreach (DataRow dRow in sortedTable.Rows)
            {
                Console.WriteLine("Rank : " + dRow["StudentRank"].ToString()+", Id : " + dRow["StudentId"].ToString() + ", Name : " + dRow["StudentName"].ToString() + ", Class : " + dRow["StudentClass"].ToString() + ", Section : " + dRow["StudentSection"].ToString());
            }
            Console.WriteLine("");

            // Updating Student Record With Id 4
            foreach (DataRow dRow in dTable.Rows)
            {
                if (dRow["StudentId"].ToString() == "4")
                {
                    dRow["StudentSection"] = "A";
                    dRow["StudentName"] = "Manju Kannadasan";
                    dRow["StudentRank"] = 1;

                    Console.WriteLine("Modified Data");
                    Console.WriteLine("=========================");
                    Console.WriteLine("Id : " + dRow["StudentId"].ToString() + ", Name : " + dRow["StudentName"].ToString() + ", Class : " + dRow["StudentClass"].ToString() + ", Section : " + dRow["StudentSection"].ToString() + ", Rank : " + dRow["StudentRank"].ToString());
                }
            }
            Console.WriteLine("");

            // Deleting Data With Id 2 & 3
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                if (dTable.Rows[i]["StudentId"].ToString() == "2" || dTable.Rows[i]["StudentId"].ToString() == "3")
                {
                    dTable.Rows[i].Delete();
                }
            }

            //Printing Remaining Data
            Console.WriteLine("Remaining Data After Deletion");
            Console.WriteLine("=========================");
            foreach (DataRow dRow in dTable.Rows)
            {
                Console.WriteLine("Id : " + dRow["StudentId"].ToString() + ", Name : " + dRow["StudentName"].ToString() + ", Class : " + dRow["StudentClass"].ToString() + ", Section : " + dRow["StudentSection"].ToString() + ", Rank : " + dRow["StudentRank"].ToString());
            }

            Console.ReadLine();
        }
    }
}
