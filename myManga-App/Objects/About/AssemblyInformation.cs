﻿using System;
using System.Reflection;

namespace myManga_App.Objects.About
{
    public sealed class AssemblyInformation
    {
        #region Instance
        private static AssemblyInformation _Instance;
        private static Object SyncObj = new Object();
        public static AssemblyInformation Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (SyncObj)
                    {
                        if (_Instance == null)
                        { _Instance = new AssemblyInformation(); }
                    }
                }
                return _Instance;
            }
        }
        #endregion

        public String Title { get; private set; }
        public String Product { get; private set; }
        public String Version { get; private set; }
        public String Description { get; private set; }
        public String Copyright { get; private set; }
        public String Company { get; private set; }

        public AssemblyInformation()
        {
            Object[] Attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(false);
            AssemblyName Name = Assembly.GetExecutingAssembly().GetName();
            foreach (Object Attr in Attributes)
            {
                if (Attr is AssemblyTitleAttribute)
                    this.Title = (Attr as AssemblyTitleAttribute).Title;
                else if (Attr is AssemblyProductAttribute)
                    this.Product = (Attr as AssemblyProductAttribute).Product;
                else if (Attr is AssemblyVersionAttribute)
                    this.Version = (Attr as AssemblyVersionAttribute).Version;
                else if (Attr is AssemblyDescriptionAttribute)
                    this.Description = (Attr as AssemblyDescriptionAttribute).Description;
                else if (Attr is AssemblyCopyrightAttribute)
                    this.Copyright = (Attr as AssemblyCopyrightAttribute).Copyright;
                else if (Attr is AssemblyCompanyAttribute)
                    this.Company = (Attr as AssemblyCompanyAttribute).Company;
            }
            if (String.Equals(this.Version, null)) this.Version = Name.Version.ToString();
        }
    }
}
