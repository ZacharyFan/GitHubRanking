using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Repository
    {
        public string name;
        public int forkCount;
        public string url;
        public DateTime createdAt;
        public DateTime updatedAt;
        public LicenseInfo licenseInfo;
        public Stargazers stargazers;
    }
}
