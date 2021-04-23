using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using WindowsConsoleData;
using WindowsConsoleUtility;
using WindowsConsoleEntity;

namespace FirstWindowsConsoleApp
{
    class GetXMLData
    {
        static void Main(string[] args)

        {
            DBHelper.defaultConnectionString = ConfigurationManager.AppSettings["FirstWebDBConn"];
            List<string> lst = new List<string>();

            DataTable dt = new DataTable();
            dt = DBHelper.ExecuteQuery("select * from Emp");
            List<Emp> emplist = new List<Emp>();

            string xml = string.Empty;

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Emp emps = new Emp();

                    emps.EmpID = int.Parse(dt.Rows[i][0].ToString());
                    emps.EmpName = dt.Rows[i][1].ToString();
                    emps.deptno = int.Parse(dt.Rows[i][2].ToString());
                    emps.salary = decimal.Parse(dt.Rows[i][3].ToString());

                    emplist.Add(emps);

                    //xml = "<Root>";
                    //for (int i=0; i<dt.Rows.Count; i++)
                    //{
                    //    xml += "<EmpDetails><EmpID>" + dt.Rows[i][0].ToString() + "</EmpID><EmpName>" + dt.Rows[i][1].ToString().Trim() + "</EmpName></EmpDetails>";
                    //}

                    //xml = xml + "</Root>";

                }

            }

            xml = "<Root>";
            foreach (Emp e in emplist)
            {
                xml += "<EmpDetails>" + Utility.Serialize<Emp>(e) + "</EmpDetails>";
            }
            xml = xml + "</Root>";

            System.IO.File.WriteAllText("C:\\tempr\\DisplayXML.xml", xml);

        }
    }
}
