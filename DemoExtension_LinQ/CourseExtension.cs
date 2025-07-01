﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExtension_LinQ
{
    static class CourseExtension
    {
        public static void display(this Course c, int count=1)
        {
            Console.WriteLine($"Course List {count} time(s):");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(c);
            }
        }
    }
}
