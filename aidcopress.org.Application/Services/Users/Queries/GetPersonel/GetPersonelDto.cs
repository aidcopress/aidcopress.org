namespace aidcopress.org.Application.Services.Users.Queries.GetUser
{
    public class GetPersonelDto     //لیست اطلاعاتی را که لازم داریم را دراین کلاس  وارد میکنیم(دی تی او یعنی حمل کننده اطلاعات بین لایه های مختلف)
    {
        public int Id {  get; set; }  
        public int Rahkaran_cod { get; set; }    
        public int Personel_code { get; set; }
        
        public string First_name { get; set; } 
        
        public string Last_name { get; set; }
        public string Semat { get; set; }
        public string Shoghl { get; set; }


    }

}
