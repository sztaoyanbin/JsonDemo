using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using Newtonsoft.Json;
using System.Text.Json;

namespace JsonDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            DataColumn dcName = new DataColumn("Name");
            DataColumn dcSex = new DataColumn("Age");
            DataColumn dcAge = new DataColumn("City");
            dt.Columns.Add(dcName);
            dt.Columns.Add(dcSex);
            dt.Columns.Add(dcAge);

            //建立数据表和数据表列

            for (int i = 0; i < 10; i++)
            {
            
            // 向数据表增加行
                DataRow dr = dt.NewRow();
                dr[0] = "Name"+i;
                dr[1] = "Age"+i;
                dr[2] = "City"+i;
                dt.Rows.Add(dr);
            }

           // 数据表转为JSON对象， JSON序列化
            string json=JsonConvert.SerializeObject(dt);
            Console.WriteLine(json);
            //Console.ReadLine();

            //JSON反序列化

            DataTable dt2 = JsonConvert.DeserializeObject<DataTable>(json);
            for (int i = 0;i < dt2.Rows.Count;i++)
            {
                DataRow dr = dt2.Rows[i];
                Console.WriteLine("{0}\t{1}\t{2}\t", dr[0], dr[1], dr[2]);

            }




            Console.ReadLine();

        }
    }
}
