using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DataTableMethod
{
    class Program
    {
        static void Main(string[] args)
        {

            //using data table that we made
            try
            {
                //create connection
                string constr = "data source=.; database=Employee; integrated security=SSPI";

                //create sql connection
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlDataAdapter sda = new SqlDataAdapter("select * from Employee", conn);

                    //create data table
                    DataTable dt = new DataTable();
                    //use fill method
                    sda.Fill(dt);

                    //access the rows
                    foreach (DataRow r in dt.Rows)
                    {
                        Console.WriteLine(r["name"] + "" + r["email"]);
                    }

                }

            }
            catch (Exception ee)
            {
                Console.WriteLine("not found", ee);
            }
            Console.ReadLine();

            /*output = roshiroshi@gmail.com
payalpayal@gmail.com
            */


            //----------------------------------------------
            //copy and clone data tabe

            //If you want to create a full copy of a data table, then you need to use the Copy method of the DataTable object which will copy not only the DataTable data but also its schema.
            // But if you want to copy the data table schema without data, then you need to use the Clone method of the data table. 

            try
            {
                //create connection
                string constr = "data source=.; database=Employee; integrated security=SSPI";

                //create sql connection
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlDataAdapter sda = new SqlDataAdapter("select * from Employee", conn);

                    //create data table
                    DataTable dt = new DataTable();
                    //use fill method
                    sda.Fill(dt);
                    Console.WriteLine("original data table");

                    //access the rows
                    foreach (DataRow r in dt.Rows)
                    {
                        Console.WriteLine(r["name"] + "" + r["email"]);
                    }
                    Console.WriteLine();
                    Console.WriteLine("copying data table");
                    //using Copy() method
                    DataTable copydt = dt.Copy();   //copies both structure and table of this data table

                    //if copy datatable is not null then access them in rows
                    if (copydt != null)
                    {
                        //access copydatatable in rows
                        foreach (DataRow r in copydt.Rows)
                        {
                            Console.WriteLine(r["name"] + "" + r["email"]);
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("clone data table");
                    //now clone it

                    DataTable clonedt = dt.Clone(); //clones both structure and  data table schemas

                    if (clonedt.Rows.Count > 0)
                    {
                        //access them
                        foreach (DataRow r in clonedt.Rows)
                        {
                            Console.WriteLine(r["name"] + "" + r["email"]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("clone data table is empty");
                        Console.WriteLine("add data to clone data table");
                        clonedt.Rows.Add(4, "ritik", "ritik@gmail.com");    //id given
                        clonedt.Rows.Add(5, "pallav", "pallav@gmail.com"); //id given
                        //access them now

                        //access clonedatatable in rows
                        foreach (DataRow r in clonedt.Rows)
                        {
                            Console.WriteLine(r["name"] + "" + r["email"]);
                        }
                    }

                }

            }

            catch (Exception ee)
            {
                Console.WriteLine("not found", ee);
            }

            Console.ReadLine();

            /*output = original data table
roshiroshi@gmail.com
payalpayal@gmail.com

copying data table
roshiroshi@gmail.com
payalpayal@gmail.com

clone data table
clone data table is empty
add data to clone data table
ritikritik@gmail.com
pallavpallav@gmail.com
            */


            //---------------------------------------------
            //delete data row from data table

            //create original data table
            try
            {
                //create connection
                string constr = "data source=.; database=Employee; integrated security=SSPI";

                //create sql connection
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlDataAdapter sda = new SqlDataAdapter("select * from Employee", conn);

                    //create data table
                    DataTable dt = new DataTable();
                    //use fill method
                    sda.Fill(dt);
                    Console.WriteLine("original data table");

                    //access the rows
                    foreach (DataRow r in dt.Rows)
                    {
                        Console.WriteLine(r["name"] + "" + r["email"]);
                    }
                    Console.WriteLine();

                    //access data rows in data table
                    foreach (DataRow r in dt.Rows)
                    {
                        if (Convert.ToInt32(r["id"]) == 2)   //row with id 2(i.e. payal) will get deleted
                        {
                            //delete that row with id 4

                            r.Delete();
                            Console.WriteLine("row deleted");
                        }
                    }
                    //accept changes
                    dt.AcceptChanges();
                    Console.WriteLine();
                    Console.WriteLine("print them after changes");

                    //access them
                    //access the rows
                    foreach (DataRow r in dt.Rows)
                    {
                        Console.WriteLine(r["name"] + "" + r["email"]);
                    }

                }
            }
            catch (Exception et)
            {
                Console.WriteLine("not found", et);
            }
            Console.ReadLine();

            /*output = original data table
roshiroshi@gmail.com
payalpayal@gmail.com

row deleted

print them after changes
roshiroshi@gmail.com
            */


            //-------------------------------------------------------
            //Reject changes method

            //create original data table
            try
            {
                //create connection
                string constr = "data source=.; database=Employee; integrated security=SSPI";

                //create sql connection
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlDataAdapter sda = new SqlDataAdapter("select * from Employee", conn);

                    //create data table
                    DataTable dt = new DataTable();
                    //use fill method
                    sda.Fill(dt);
                    Console.WriteLine("original data table");

                    //access the rows
                    foreach (DataRow r in dt.Rows)
                    {
                        Console.WriteLine(r["name"] + "" + r["email"]);
                    }
                    Console.WriteLine();

                    //access them
                    foreach (DataRow r in dt.Rows)
                    {
                        if (Convert.ToInt32(r["id"]) == 2)   //row with id 2(i.e. payal) will get deleted
                        {
                            //delete that row with id 4

                            r.Delete();
                            Console.WriteLine("row deleted");
                        }
                    }

                    //now we are restoring the database 
                    dt.RejectChanges();
                    Console.WriteLine();
                    Console.WriteLine("reject changes and restore data deleted again");

                    //access the rows
                    foreach (DataRow r in dt.Rows)
                    {
                        Console.WriteLine(r["name"] + "" + r["email"]);
                    }

                }
            }
            catch (Exception ed)
            {
                Console.WriteLine("not allowed", ed);
            }
            Console.ReadLine();

            /*output = original data table
roshiroshi@gmail.com
payalpayal@gmail.com

row deleted

reject changes
roshiroshi@gmail.com
payalpayal@gmail.com
            */
        }
    }
}
      


