using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfRegistrationApp.Model
{
    public partial class Client
    {

        public string GetPhotos
        {
            get
            {
                return Environment.CurrentDirectory + "\\" + Photo;
            }
            set
            {
                Photo = value;
            }
        }
    }
}



