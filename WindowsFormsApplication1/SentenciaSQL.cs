using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace WindowsFormsApplication1
{
  public   class SentenciaSQL
    {


        public SQLiteConnection conexion = new SQLiteConnection("Data Source=C:/Users/user/Desktop/Sistema Ventas C#SQLITE/Ventas_Producto_Sqlite.s3db");


      public bool InsertSQL(string sql)
{
      try
         {

    conexion.Open();

    SQLiteCommand Command = new SQLiteCommand(sql, conexion);


    int i = Command.ExecuteNonQuery();

    return true;

      
       }
      catch  (Exception e)

     {
    string  n= e.Message;
    return false;



     }
    finally 
    {

   conexion.Close();

    }
}
    }
}