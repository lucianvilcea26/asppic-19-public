using System;
using System.IO;

namespace ASPPIC.Public.Business.Helpers
{
    public static class FileHelper
    {
        public static string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Guid.NewGuid().ToString() + Path.GetExtension(fileName);
        }
    }
}
