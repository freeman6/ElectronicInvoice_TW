﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Infrastructure.Helper;

namespace ElectronicInvoice.Produce
{
    public class ApiTypeProvider
    {
        private static ApiTypeProvider _instance;
        public static ApiTypeProvider Instance => _instance ?? (_instance = new ApiTypeProvider());
        
        private ApiTypeProvider()
        {
            AssemblyList = new List<Assembly>()
            {
                Assembly.Load("ElectronicInvoice.Produce")
            };
        }

        public List<Assembly> AssemblyList { get; }

        public void RegistertAssembly(Assembly assembly)
        {
            AssemblyList.Add(assembly);
        }

        internal IEnumerable<Type> GetTypeFromAssembly<T>() where T : Attribute
        {
            return AssemblyList
                .SelectMany(x => x.ExportedTypes, (a, b) => b)
                .Where(x => x.GetCustomAttribute<T>() != null);
        }
    }
}
