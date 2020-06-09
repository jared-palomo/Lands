using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.Helpers
{
    public class PlatformCulture
    {
        #region Properties
        public string PlatformString { get; set; }
        public string LanguageCode { get; set; }
        public string LocaleCode { get; set; }
        #endregion

        #region Constructors
        public PlatformCulture(string platformCultureString)
        {
            if (String.IsNullOrEmpty(platformCultureString)) {
                throw new ArgumentException("Expected culture identified","platformCultureString");
            }

            PlatformString = platformCultureString.Replace("_","-");
            var dashIndex = PlatformString.IndexOf("-",StringComparison.Ordinal);

            if (dashIndex > 0) {
                var parts = PlatformString.Split('-');
                LanguageCode = parts[0];
                LocaleCode = parts[1];
            }
            else
            {
                LanguageCode = PlatformString;
                LocaleCode = "";
            }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return PlatformString;
        }
        #endregion
    }
}
