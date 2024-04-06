﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLabOOP2
{
    public class Constants
    {
        public const string DatabaseFilename = "Course.db3";
        public static string DatabasePath =>
            Path.Combine(Directory.GetParent(
                Directory.GetCurrentDirectory()).Parent.Parent.FullName, DatabaseFilename);

        public Constants()
        {
            
        }
    }
}