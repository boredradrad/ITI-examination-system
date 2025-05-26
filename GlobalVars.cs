// Fares
using Microsoft.ReportingServices.Diagnostics.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_GUI
{
    public static class GlobalVars
    {
        // Fares
        public static string ConnectionString { get; }
            = "Data Source = DESKTOP-UVAA6CQ\\SQL2022;Initial Catalog=Examination_System;Integrated Security=True;";
        public static string RDlFolder { get; } = @"D:\Downloads\Examination System Project2\Reports\";
        public static int Std { get; set; } = -1;
        public static int InsID { get; set; } = -1;
    }
}

// 1@1234


