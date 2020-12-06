namespace MailSender.Models
{
    public class Server
    {
        public string Address { get; set; }

        public int Port { get; set; }

        public bool IsSSL { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        public string FullAddress { get { return $"{Address} : {Port}"; } }
    }
}
