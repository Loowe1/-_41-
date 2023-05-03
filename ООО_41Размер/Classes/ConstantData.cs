using System;
using System.Collections.Generic;
using System.Text;

namespace ООО_41Размер.Classes
{
    class ConstantData
    {
        public static Windows.Autorization auth;
        public static string Atricle;
        public static MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection("server=localhost;user=root;pwd=Loowe;database=trade91");
    }
}
