using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Exceptions {
    public class AssetExistedException : Exception {
        public AssetExistedException(string message, string name) : base(message) {
            ViolentName = new string(name);
        }
        public AssetExistedException(string message) : base(message) {

        }
        public string ViolentName { get; }
    }
}
