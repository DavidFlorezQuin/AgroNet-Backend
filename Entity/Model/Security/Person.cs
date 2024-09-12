namespace Entity.Model.Security
{
    public class Person : ABaseModel
    {

        public string first_name { get; set; }

        public string last_name { get; set; }
        
        public string email { get; set; }

        public string gender { get; set; }

        public string document { get; set; }

        public string type_document { get; set; }

        public string direction { get; set; }

        public string phone { get; set; }

        public DateTime birthday { get; set; }



    }
}
