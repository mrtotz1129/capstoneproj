using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SLS
{
    class SQLStatement
    {
        /**
         * This class is used for all data access
         * This class includes methods to execute sql statements
         * that does not return any values (INSERT, UPDATE)
         * and also to execute sql statement that returns values
         * (SELECT, VIEW)
         * */
        SqlConnection con;
        SqlCommand com;
        SqlDataReader reader;

        SqlDataAdapter adapter;
        DataSet ds;


        /**
         * This constructor accepts a string parameter, which is the connection string to the database
         * upon contruction of this class, the conncetion to the database in opened.
         * */

        public SQLStatement(String Server, String Database)
        {
            try
            {
                con = new SqlConnection("Integrated Security = true; Data Source = " + Server + "; Initial Catalog = " + Database + "");
                con.Open();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        } //End of Constructor

        /**
         * This method is used for executing sql statement
         * with conditions
         * e.g. INSERT, UPDATE, DELETE INTO table VALUES (@value1, @value2)
         * */

        public int executeNonQuery(String sql, Dictionary<String, Object> parameters)
        {
            int rowsAffected = 0;
            try
            {
                //Com yung pangalan ng SqlCommand na dineclare sa taas
                com = new SqlCommand(sql, con);
                foreach (KeyValuePair<String, Object> row in parameters)
                {
                    com.Parameters.AddWithValue(row.Key, row.Value);
                }
                rowsAffected = com.ExecuteNonQuery();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            return rowsAffected;
        }

        /*This method is used for executing select statements
         * and using SQLDataReader to read the data return.
         * Use this method only for select statements w/o conditions
         * e.g. SELECT * FROM Employees
         * */
        public SqlDataReader executeReader(String sql)
        {
            try
            {
                com = new SqlCommand(sql, con);
                reader = com.ExecuteReader();
            }

            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

            return reader;
        }

        /*This method is used for executing select statements
        * and using SQLDataReader to read the data return.
        * Use this method only for select statements with conditions
        * e.g. SELECT * FROM Employees WHERE EmployeeNumber = 'Churba'
        * */
        public SqlDataReader executeReader(String sql, Dictionary<String, Object> parameters)
        {
            try
            {
                com = new SqlCommand(sql, con);
                foreach (KeyValuePair<String, Object> row in parameters)
                {
                    com.Parameters.AddWithValue(row.Key, row.Value);
                }
                reader = com.ExecuteReader();
            }

            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

            return reader;
        }

        /*This method is used for executing select statements
         * and using DataSet to read the data return.
         * Use this method only for select statements w/o conditions
         * e.g. SELECT * FROM Employees
         * */

        public DataSet executeDataSet(String sql, String Member)
        {
            try
            {
                com = new SqlCommand(sql, con);
                ds = new DataSet();
                adapter = new SqlDataAdapter(com);
                adapter.Fill(ds, Member);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            return ds;
        }

        /*This method is used for executing select statements
         * and using DataSet to read the data return.
         * Use this method only for select statements w/ conditions
         * e.g. SELECT * FROM Employees WHERE EmployeeNumber = 'Churba'
         * */
        public DataSet executeDataSet(String sql, Dictionary<String, Object> parameters, String Member)
        {
            try
            {
                com = new SqlCommand(sql, con);
                foreach (KeyValuePair<String, Object> row in parameters)
                {
                    com.Parameters.AddWithValue(row.Key, row.Value);
                }
                ds = new DataSet();
                adapter = new SqlDataAdapter(com);
                adapter.Fill(ds, Member);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            return ds;
        }

        /* Desctructor closes the connection
         * upon garbage collection
         * */
        ~SQLStatement()
        {
            try
            {

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }//destructor
    }
}
